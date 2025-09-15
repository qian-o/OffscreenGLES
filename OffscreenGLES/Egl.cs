using System.Runtime.InteropServices;
using EglNativeDisplayType = nint;
using EglNativePixmapType = nint;
using EglNativeWindowType = nint;

namespace OffscreenGLES;
public struct EglBoolean
{
    public int Value;

    public static implicit operator bool(EglBoolean value) => value.Value is not 0;
}

public struct EglConfig
{
    public nint Handle;

    public static implicit operator nint(EglConfig value) => value.Handle;

    public static implicit operator EglConfig(nint value) => new() { Handle = value };
}

public struct EglContext
{
    public nint Handle;

    public static implicit operator nint(EglContext value) => value.Handle;

    public static implicit operator EglContext(nint value) => new() { Handle = value };
}

public struct EglDisplay
{
    public nint Handle;
}

public struct EglSurface
{
    public nint Handle;
}

public unsafe partial class Egl
{
    // EGL 1.0
    public const int AlphaSize = 0x3021;
    public const int BadAccess = 0x3002;
    public const int BadAlloc = 0x3003;
    public const int BadAttribute = 0x3004;
    public const int BadConfig = 0x3005;
    public const int BadContext = 0x3006;
    public const int BadCurrentSurface = 0x3007;
    public const int BadDisplay = 0x3008;
    public const int BadMatch = 0x3009;
    public const int BadNativePixmap = 0x300A;
    public const int BadNativeWindow = 0x300B;
    public const int BadParameter = 0x300C;
    public const int BadSurface = 0x300D;
    public const int BlueSize = 0x3022;
    public const int BufferSize = 0x3020;
    public const int ConfigCaveat = 0x3027;
    public const int ConfigId = 0x3028;
    public const int CoreNativeEngine = 0x305B;
    public const int DepthSize = 0x3025;
    public const int DontCare = -1;
    public const int Draw = 0x3059;
    public const int Extensions = 0x3055;
    public const int False = 0;
    public const int GreenSize = 0x3023;
    public const int Height = 0x3056;
    public const int LargestPbuffer = 0x3058;
    public const int Level = 0x3029;
    public const int MaxPbufferHeight = 0x302A;
    public const int MaxPbufferPixels = 0x302B;
    public const int MaxPbufferWidth = 0x302C;
    public const int NativeRenderable = 0x302D;
    public const int NativeVisualId = 0x302E;
    public const int NativeVisualType = 0x302F;
    public const int None = 0x3038;
    public const int NonConformantConfig = 0x3051;
    public const int NotInitialized = 0x3001;
    public const nint NoContext = 0;
    public const nint NoDisplay = 0;
    public const nint NoSurface = 0;
    public const int PbufferBit = 0x0001;
    public const int PixmapBit = 0x0002;
    public const int Read = 0x305A;
    public const int RedSize = 0x3024;
    public const int Samples = 0x3031;
    public const int SampleBuffers = 0x3032;
    public const int SlowConfig = 0x3050;
    public const int StencilSize = 0x3026;
    public const int Success = 0x3000;
    public const int SurfaceType = 0x3033;
    public const int TransparentBlueValue = 0x3035;
    public const int TransparentGreenValue = 0x3036;
    public const int TransparentRedValue = 0x3037;
    public const int TransparentRgb = 0x3052;
    public const int TransparentType = 0x3034;
    public const int True = 1;
    public const int Vendor = 0x3053;
    public const int Version = 0x3054;
    public const int Width = 0x3057;
    public const int WindowBit = 0x0004;

    // EGL 1.1
    public const int BackBuffer = 0x3084;
    public const int BindToTextureRgb = 0x3039;
    public const int BindToTextureRgba = 0x303A;
    public const int ContextLost = 0x300E;
    public const int MinSwapInterval = 0x303B;
    public const int MaxSwapInterval = 0x303C;
    public const int MipmapTexture = 0x3082;
    public const int MipmapLevel = 0x3083;
    public const int NoTexture = 0x305C;
    public const int Texture2D = 0x305F;
    public const int TextureFormat = 0x3080;
    public const int TextureRgb = 0x305D;
    public const int TextureRgba = 0x305E;
    public const int TextureTarget = 0x3081;

    // EGL 1.2
    public const int AlphaFormat = 0x3088;
    public const int AlphaFormatNonpre = 0x308B;
    public const int AlphaFormatPre = 0x308C;
    public const int AlphaMaskSize = 0x303E;
    public const int BufferPreserved = 0x3094;
    public const int BufferDestroyed = 0x3095;
    public const int ClientApis = 0x308D;
    public const int Colorspace = 0x3087;
    public const int ColorspaceSrgb = 0x3089;
    public const int ColorspaceLinear = 0x308A;
    public const int ColorBufferType = 0x303F;
    public const int ContextClientType = 0x3097;
    public const int DisplayScaling = 10000;
    public const int HorizontalResolution = 0x3090;
    public const int LuminanceBuffer = 0x308F;
    public const int LuminanceSize = 0x303D;
    public const int OpenglEsBit = 0x0001;
    public const int OpenvgBit = 0x0002;
    public const int OpenglEsApi = 0x30A0;
    public const int OpenvgApi = 0x30A1;
    public const int OpenvgImage = 0x3096;
    public const int PixelAspectRatio = 0x3092;
    public const int RenderableType = 0x3040;
    public const int RenderBuffer = 0x3086;
    public const int RgbBuffer = 0x308E;
    public const int SingleBuffer = 0x3085;
    public const int SwapBehavior = 0x3093;
    public const int Unknown = -1;
    public const int VerticalResolution = 0x3091;

    // EGL 1.3
    public const int Conformant = 0x3042;
    public const int ContextClientVersion = 0x3098;
    public const int MatchNativePixmap = 0x3041;
    public const int OpenglEs2Bit = 0x0004;
    public const int VgAlphaFormat = 0x3088;
    public const int VgAlphaFormatNonpre = 0x308B;
    public const int VgAlphaFormatPre = 0x308C;
    public const int VgAlphaFormatPreBit = 0x0040;
    public const int VgColorspace = 0x3087;
    public const int VgColorspaceSrgb = 0x3089;
    public const int VgColorspaceLinear = 0x308A;
    public const int VgColorspaceLinearBit = 0x0020;

    // EGL 1.4
    public const int DefaultDisplay = 0;
    public const int MultisampleResolveBoxBit = 0x0200;
    public const int MultisampleResolve = 0x3099;
    public const int MultisampleResolveDefault = 0x309A;
    public const int MultisampleResolveBox = 0x309B;
    public const int OpenglApi = 0x30A2;
    public const int OpenglBit = 0x0008;
    public const int SwapBehaviorPreservedBit = 0x0400;

    // EGL 1.5
    public const int ContextMajorVersion = 0x3098;
    public const int ContextMinorVersion = 0x30FB;
    public const int ContextOpenglProfileMask = 0x30FD;
    public const int ContextOpenglResetNotificationStrategy = 0x31BD;
    public const int NoResetNotification = 0x31BE;
    public const int LoseContextOnReset = 0x31BF;
    public const int ContextOpenglCoreProfileBit = 0x00000001;
    public const int ContextOpenglCompatibilityProfileBit = 0x00000002;
    public const int ContextOpenglDebug = 0x31B0;
    public const int ContextOpenglForwardCompatible = 0x31B1;
    public const int ContextOpenglRobustAccess = 0x31B2;
    public const int OpenglEs3Bit = 0x00000040;
    public const int ClEventHandle = 0x309C;
    public const int SyncClEvent = 0x30FE;
    public const int SyncClEventComplete = 0x30FF;
    public const int SyncPriorCommandsComplete = 0x30F0;
    public const int SyncType = 0x30F7;
    public const int SyncStatus = 0x30F1;
    public const int SyncCondition = 0x30F8;
    public const int Signaled = 0x30F2;
    public const int Unsignaled = 0x30F3;
    public const int SyncFlushCommandsBit = 0x0001;
    public const ulong Forever = 0xFFFFFFFFFFFFFFFF;
    public const int TimeoutExpired = 0x30F5;
    public const int ConditionSatisfied = 0x30F6;
    public const nint NoSync = 0;
    public const int SyncFence = 0x30F9;
    public const int GlColorspace = 0x309D;
    public const int GlColorspaceSrgb = 0x3089;
    public const int GlColorspaceLinear = 0x308A;
    public const int GlRenderbuffer = 0x30B9;
    public const int GlTexture2D = 0x30B1;
    public const int GlTextureLevel = 0x30BC;
    public const int GlTexture3D = 0x30B2;
    public const int GlTextureZoffset = 0x30BD;
    public const int GlTextureCubeMapPositiveX = 0x30B3;
    public const int GlTextureCubeMapNegativeX = 0x30B4;
    public const int GlTextureCubeMapPositiveY = 0x30B5;
    public const int GlTextureCubeMapNegativeY = 0x30B6;
    public const int GlTextureCubeMapPositiveZ = 0x30B7;
    public const int GlTextureCubeMapNegativeZ = 0x30B8;
    public const int ImagePreserved = 0x30D2;
    public const nint NoImage = 0;

    static Egl()
    {
        string architecture = RuntimeInformation.ProcessArchitecture.ToString().ToLowerInvariant();

        if (OperatingSystem.IsWindows())
        {
            string runtimePath = Path.Combine(AppContext.BaseDirectory, "runtimes", $"win-{architecture}", "native");

            NativeLibrary.Load(Path.Combine(runtimePath, "libGLESv2.dll"));
            NativeLibrary.Load(Path.Combine(runtimePath, "libEGL.dll"));
        }
        else if (OperatingSystem.IsLinux())
        {
            string runtimePath = Path.Combine(AppContext.BaseDirectory, "runtimes", $"linux-{architecture}", "native");

            NativeLibrary.Load(Path.Combine(runtimePath, "libGLESv2.so"));
            NativeLibrary.Load(Path.Combine(runtimePath, "libEGL.so"));
        }
        else if (OperatingSystem.IsMacOS())
        {
            string runtimePath = Path.Combine(AppContext.BaseDirectory, "runtimes", $"osx-{architecture}", "native");

            NativeLibrary.Load(Path.Combine(runtimePath, "libGLESv2.dylib"));
            NativeLibrary.Load(Path.Combine(runtimePath, "libEGL.dylib"));
        }
        else
        {
            throw new PlatformNotSupportedException("Only Windows, Linux and macOS are supported.");
        }
    }

    [LibraryImport("libEGL")]
    private static partial EglBoolean eglChooseConfig(EglDisplay dpy, int* attribList, EglConfig* configs, int configSize, int* numConfig);

    [LibraryImport("libEGL")]
    private static partial EglBoolean eglCopyBuffers(EglDisplay dpy, EglSurface surface, EglNativePixmapType target);

    [LibraryImport("libEGL")]
    private static partial EglContext eglCreateContext(EglDisplay dpy, EglConfig config, EglContext shareContext, int* attribList);

    [LibraryImport("libEGL")]
    private static partial EglSurface eglCreatePbufferSurface(EglDisplay dpy, EglConfig config, int* attribList);

    [LibraryImport("libEGL")]
    private static partial EglSurface eglCreatePixmapSurface(EglDisplay dpy, EglConfig config, EglNativePixmapType pixmap, int* attribList);

    [LibraryImport("libEGL")]
    private static partial EglSurface eglCreateWindowSurface(EglDisplay dpy, EglConfig config, EglNativeWindowType win, int* attribList);

    [LibraryImport("libEGL")]
    private static partial EglBoolean eglDestroyContext(EglDisplay dpy, EglContext ctx);

    [LibraryImport("libEGL")]
    private static partial EglBoolean eglDestroySurface(EglDisplay dpy, EglSurface surface);

    [LibraryImport("libEGL")]
    private static partial EglBoolean eglGetConfigAttrib(EglDisplay dpy, EglConfig config, int attribute, int* value);

    [LibraryImport("libEGL")]
    private static partial EglBoolean eglGetConfigs(EglDisplay dpy, EglConfig* configs, int configSize, int* numConfig);

    [LibraryImport("libEGL")]
    private static partial EglDisplay eglGetCurrentDisplay();

    [LibraryImport("libEGL")]
    private static partial EglSurface eglGetCurrentSurface(int readdraw);

    [LibraryImport("libEGL")]
    private static partial EglDisplay eglGetDisplay(EglNativeDisplayType displayId);

    [LibraryImport("libEGL")]
    private static partial int eglGetError();

    [LibraryImport("libEGL")]
    private static partial nint eglGetProcAddress(char* procname);

    [LibraryImport("libEGL")]
    private static partial EglBoolean eglInitialize(EglDisplay dpy, int* major, int* minor);

    [LibraryImport("libEGL")]
    private static partial EglBoolean eglMakeCurrent(EglDisplay dpy, EglSurface draw, EglSurface read, EglContext ctx);

    [LibraryImport("libEGL")]
    private static partial EglBoolean eglQueryContext(EglDisplay dpy, EglContext ctx, int attribute, int* value);

    [LibraryImport("libEGL")]
    private static partial byte* eglQueryString(EglDisplay dpy, int name);

    [LibraryImport("libEGL")]
    private static partial EglBoolean eglQuerySurface(EglDisplay dpy, EglSurface surface, int attribute, int* value);

    [LibraryImport("libEGL")]
    private static partial EglBoolean eglSwapBuffers(EglDisplay dpy, EglSurface surface);

    [LibraryImport("libEGL")]
    private static partial EglBoolean eglTerminate(EglDisplay dpy);

    [LibraryImport("libEGL")]
    private static partial EglBoolean eglWaitGL();

    [LibraryImport("libEGL")]
    private static partial EglBoolean eglWaitNative(int engine);

    public static bool ChooseConfig(EglDisplay dpy, int[] attribList, EglConfig[] configs, out int numConfig)
    {
        fixed (int* attribListPtr = attribList)
        fixed (EglConfig* configsPtr = configs)
        fixed (int* numConfigPtr = &numConfig)
        {
            return eglChooseConfig(dpy, attribListPtr, configsPtr, configs.Length, numConfigPtr);
        }
    }

    public static bool CopyBuffers(EglDisplay dpy, EglSurface surface, EglNativeDisplayType target)
    {
        return eglCopyBuffers(dpy, surface, target);
    }

    public static EglContext CreateContext(EglDisplay dpy, EglConfig config, EglContext shareContext, int[] attribList)
    {
        fixed (int* attribListPtr = attribList)
        {
            return eglCreateContext(dpy, config, shareContext, attribListPtr);
        }
    }

    public static EglSurface CreatePbufferSurface(EglDisplay dpy, EglConfig config, int[] attribList)
    {
        fixed (int* attribListPtr = attribList)
        {
            return eglCreatePbufferSurface(dpy, config, attribListPtr);
        }
    }

    public static EglSurface CreatePixmapSurface(EglDisplay dpy, EglConfig config, EglNativeDisplayType pixmap, int[] attribList)
    {
        fixed (int* attribListPtr = attribList)
        {
            return eglCreatePixmapSurface(dpy, config, pixmap, attribListPtr);
        }
    }

    public static EglSurface CreateWindowSurface(EglDisplay dpy, EglConfig config, EglNativeDisplayType win, int[] attribList)
    {
        fixed (int* attribListPtr = attribList)
        {
            return eglCreateWindowSurface(dpy, config, win, attribListPtr);
        }
    }

    public static bool DestroyContext(EglDisplay dpy, EglContext ctx)
    {
        return eglDestroyContext(dpy, ctx);
    }

    public static bool DestroySurface(EglDisplay dpy, EglSurface surface)
    {
        return eglDestroySurface(dpy, surface);
    }

    public static bool GetConfigAttrib(EglDisplay dpy, EglConfig config, int attribute, out int value)
    {
        fixed (int* valuePtr = &value)
        {
            return eglGetConfigAttrib(dpy, config, attribute, valuePtr);
        }
    }

    public static bool GetConfigs(EglDisplay dpy, EglConfig[] configs, out int numConfig)
    {
        fixed (EglConfig* configsPtr = configs)
        fixed (int* numConfigPtr = &numConfig)
        {
            return eglGetConfigs(dpy, configsPtr, configs.Length, numConfigPtr);
        }
    }

    public static EglDisplay GetCurrentDisplay()
    {
        return eglGetCurrentDisplay();
    }

    public static EglSurface GetCurrentSurface(int readdraw)
    {
        return eglGetCurrentSurface(readdraw);
    }

    public static EglDisplay GetDisplay(EglNativeDisplayType displayId)
    {
        return eglGetDisplay(displayId);
    }

    public static int GetError()
    {
        return eglGetError();
    }

    public static nint GetProcAddress(string procname)
    {
        fixed (byte* procnamePtr = System.Text.Encoding.UTF8.GetBytes(procname + '\0'))
        {
            return eglGetProcAddress((char*)procnamePtr);
        }
    }

    public static bool Initialize(EglDisplay dpy, out int major, out int minor)
    {
        fixed (int* majorPtr = &major)
        fixed (int* minorPtr = &minor)
        {
            return eglInitialize(dpy, majorPtr, minorPtr);
        }
    }

    public static bool MakeCurrent(EglDisplay dpy, EglSurface draw, EglSurface read, EglContext ctx)
    {
        return eglMakeCurrent(dpy, draw, read, ctx);
    }

    public static bool QueryContext(EglDisplay dpy, EglContext ctx, int attribute, out int value)
    {
        fixed (int* valuePtr = &value)
        {
            return eglQueryContext(dpy, ctx, attribute, valuePtr);
        }
    }

    public static string? QueryString(EglDisplay dpy, int name)
    {
        byte* ptr = eglQueryString(dpy, name);
        if (ptr == null)
            return null;
        return Marshal.PtrToStringUTF8((nint)ptr);
    }

    public static bool QuerySurface(EglDisplay dpy, EglSurface surface, int attribute, out int value)
    {
        fixed (int* valuePtr = &value)
        {
            return eglQuerySurface(dpy, surface, attribute, valuePtr);
        }
    }

    public static bool SwapBuffers(EglDisplay dpy, EglSurface surface)
    {
        return eglSwapBuffers(dpy, surface);
    }

    public static bool Terminate(EglDisplay dpy)
    {
        return eglTerminate(dpy);
    }

    public static bool WaitGL()
    {
        return eglWaitGL();
    }

    public static bool WaitNative(int engine)
    {
        return eglWaitNative(engine);
    }
}
