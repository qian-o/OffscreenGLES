using OffscreenGLES;
using Silk.NET.Core.Contexts;
using Silk.NET.OpenGLES;
using SkiaSharp;

internal unsafe class Program
{
    private static readonly int[] Configs =
    [
        Egl.RedSize, 8,
        Egl.GreenSize, 8,
        Egl.BlueSize, 8,
        Egl.AlphaSize, 8,
        Egl.DepthSize, 24,
        Egl.StencilSize, 8,
        Egl.None
    ];

    private static readonly int Width = 1000;
    private static readonly int Height = 1000;

    private static readonly string OutputFilePath = "output.png";

    private static readonly string VS = """
        #version 300 es

        in vec3 position;
        in vec3 color;

        out vec3 fragColor;

        void main()
        {
            gl_Position = vec4(position, 1.0);
            fragColor = color;
        }
        """;
    private static readonly string FS = """
        #version 300 es

        precision mediump float;

        in vec3 fragColor;

        out vec4 outColor;

        void main()
        {
            outColor = vec4(fragColor, 1.0);
        }
        """;

    private static uint program;

    private static void Main(string[] _)
    {
        EglDisplay display = Egl.GetDisplay(0);
        if (display.Handle == Egl.NoDisplay)
        {
            throw new Exception("Failed to get EGL display");
        }

        if (!Egl.Initialize(display, out int major, out int minor))
        {
            throw new Exception("Failed to initialize EGL");
        }

        EglConfig[] config = new EglConfig[1];
        if (!Egl.ChooseConfig(display, Configs, config, out int _))
        {
            throw new Exception("Failed to choose EGL config");
        }

        EglContext context = Egl.CreateContext(display, config[0], Egl.NoContext, [Egl.ContextClientVersion, 3, Egl.None]);
        if (context.Handle == Egl.NoContext)
        {
            throw new Exception("Failed to create EGL context");
        }

        EglSurface surface = Egl.CreatePbufferSurface(display, config[0], [Egl.Width, Width, Egl.Height, Height, Egl.None]);
        if (surface.Handle == Egl.NoSurface)
        {
            throw new Exception("Failed to create EGL surface");
        }

        if (!Egl.MakeCurrent(display, surface, surface, context))
        {
            throw new Exception("Failed to make EGL context current");
        }

        GL gl = GL.GetApi(new LamdaNativeContext(Egl.GetProcAddress));

        Init(gl);
        Render(gl);
        ReadPixels(gl);

        Console.WriteLine($"Output file saved to: {Path.GetFullPath(OutputFilePath)}");
    }

    private static void Init(GL gl)
    {
        uint vertexShader = gl.CreateShader(ShaderType.VertexShader);
        gl.ShaderSource(vertexShader, VS);
        gl.CompileShader(vertexShader);

        uint fragmentShader = gl.CreateShader(ShaderType.FragmentShader);
        gl.ShaderSource(fragmentShader, FS);
        gl.CompileShader(fragmentShader);

        program = gl.CreateProgram();
        gl.AttachShader(program, vertexShader);
        gl.AttachShader(program, fragmentShader);
        gl.LinkProgram(program);

        gl.DeleteShader(vertexShader);
        gl.DeleteShader(fragmentShader);

        gl.UseProgram(program);
        gl.EnableVertexAttribArray(0);
        gl.EnableVertexAttribArray(1);
        gl.UseProgram(0);
    }

    private static void Render(GL gl)
    {
        float[] vertices =
        [
            -0.5f, -0.5f, 0.0f,
             0.5f, -0.5f, 0.0f,
             0.0f,  0.5f, 0.0f
        ];

        float[] colors =
        [
            1.0f, 0.0f, 0.0f,
            0.0f, 1.0f, 0.0f,
            0.0f, 0.0f, 1.0f
        ];

        gl.UseProgram(program);
        gl.Viewport(0, 0, (uint)Width, (uint)Height);
        gl.ClearColor(0.0f, 0.5f, 0.5f, 1.0f);
        gl.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit | ClearBufferMask.StencilBufferBit);

        fixed (float* verticesPtr = vertices)
        fixed (float* colorsPtr = colors)
        {
            gl.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, (nint)verticesPtr);
            gl.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 0, (nint)colorsPtr);

            gl.DrawArrays(PrimitiveType.Triangles, 0, 3);
        }
    }

    private static void ReadPixels(GL gl)
    {
        SKImageInfo imageInfo = new(Width, Height, SKColorType.Rgba8888);

        byte[] pixels = new byte[Width * Height * 4];

        fixed (byte* pixelsPtr = pixels)
        {
            gl.ReadPixels(0, 0, (uint)Width, (uint)Height, PixelFormat.Rgba, PixelType.UnsignedByte, pixelsPtr);

            SKSurface surface = SKSurface.Create(imageInfo);

            surface.Canvas.Scale(1, -1, Width / 2, Height / 2);
            surface.Canvas.DrawImage(SKImage.FromPixels(imageInfo, (nint)pixelsPtr), 0, 0);

            surface.Snapshot().Encode(SKEncodedImageFormat.Png, 100).SaveTo(File.Create(OutputFilePath));
        }
    }
}