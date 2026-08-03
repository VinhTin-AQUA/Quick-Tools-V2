using System.Runtime.InteropServices;

namespace QuickTools.Modules.WebUI.Methods
{
    public static partial class NativeMethods_Window
    {
        private const string Library = "webui";
        

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern nuint webui_new_window();

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_destroy(nuint window);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_close(nuint window);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool webui_show(
            nuint window,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string content);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool webui_show_browser(nuint window, [MarshalAs(UnmanagedType.LPUTF8Str)] string content, nuint browser);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_navigate(
            nuint window,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string url);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_set_size(
            nuint window,
            uint width,
            uint height);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_set_position(
            nuint window,
            uint x,
            uint y);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool webui_is_shown(
            nuint window);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_set_title(
            nuint window,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string title);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool webui_set_root_folder(
            nuint window,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string path);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_set_browser(
            nuint window,
            int browser);
    }
}