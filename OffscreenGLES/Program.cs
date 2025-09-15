using OffscreenGLES;
using Silk.NET.Core.Contexts;
using Silk.NET.OpenGLES;
using SkiaSharp;

internal unsafe class Program
{
    private readonly static int[] Configs =
    [
        Egl.RedSize, 8,
        Egl.GreenSize, 8,
        Egl.BlueSize, 8,
        Egl.AlphaSize, 8,
        Egl.DepthSize, 24,
        Egl.StencilSize, 8,
        Egl.None
    ];

    private readonly static int Width = 1000;
    private readonly static int Height = 1000;
    private readonly static string OutputFilePath = "output.bmp";

    private readonly static string vs = """
        attribute vec3 position;

        void main()
        {
            gl_Position = vec4(position, 1.0);
        }
        """;

    private readonly static string fs = """
        precision mediump float;

        void main()
        {
            gl_FragColor = vec4(1.0, 0.0, 0.0, 1.0);
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
        gl.ShaderSource(vertexShader, vs);
        gl.CompileShader(vertexShader);

        uint fragmentShader = gl.CreateShader(ShaderType.FragmentShader);
        gl.ShaderSource(fragmentShader, fs);
        gl.CompileShader(fragmentShader);

        program = gl.CreateProgram();
        gl.AttachShader(program, vertexShader);
        gl.AttachShader(program, fragmentShader);
        gl.LinkProgram(program);

        gl.DeleteShader(vertexShader);
        gl.DeleteShader(fragmentShader);
    }

    private static void Render(GL gl)
    {
        float[] vertices =
        [
            -0.5f, -0.5f, 0.0f,
             0.5f, -0.5f, 0.0f,
             0.0f,  0.5f, 0.0f
        ];

        gl.Viewport(0, 0, (uint)Width, (uint)Height);
        gl.ClearColor(0.0f, 0.5f, 0.5f, 1.0f);
        gl.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit | ClearBufferMask.StencilBufferBit);

        gl.UseProgram(program);

        fixed (float* verticesPtr = vertices)
        {
            gl.EnableVertexAttribArray(0);
            gl.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, (nint)verticesPtr);
            gl.DrawArrays(PrimitiveType.Triangles, 0, 3);
            gl.DisableVertexAttribArray(0);
        }
    }

    private static void ReadPixels(GL gl)
    {
        byte[] pixels = new byte[Width * Height * 4];

        fixed (byte* pixelsPtr = pixels)
        {
            gl.ReadPixels(0, 0, (uint)Width, (uint)Height, PixelFormat.Rgba, PixelType.UnsignedByte, pixelsPtr);

            SKImage image = SKImage.FromPixels(new SKImageInfo(Width, Height, SKColorType.Rgba8888), (nint)pixelsPtr);

            using SKData data = image.Encode();

            using FileStream stream = File.Create(OutputFilePath);

            data.SaveTo(stream);
        }
    }
}