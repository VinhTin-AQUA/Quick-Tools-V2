using System.Runtime.InteropServices;

namespace QuickTools.Modules.WebUI.Methods
{
    public static class WindowSettingMethods
    {
        private const string Library = "webui";
        
        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_set_kiosk(UIntPtr window, [MarshalAs(UnmanagedType.I1)] bool status);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_focus(UIntPtr window);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_set_custom_parameters(UIntPtr window, string @params);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_set_high_contrast(UIntPtr window, [MarshalAs(UnmanagedType.I1)] bool status);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_set_resizable(UIntPtr window, [MarshalAs(UnmanagedType.I1)] bool status);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool webui_is_high_contrast();

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_set_hide(UIntPtr window, [MarshalAs(UnmanagedType.I1)] bool status);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_set_size(UIntPtr window, uint width, uint height);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_set_minimum_size(UIntPtr window, uint width, uint height);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_set_position(UIntPtr window, uint x, uint y);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_set_center(UIntPtr window);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_set_profile(UIntPtr window, string name, string path);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_set_proxy(UIntPtr window, string proxy_server);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_set_frameless(UIntPtr window, [MarshalAs(UnmanagedType.I1)] bool status);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_set_transparent(UIntPtr window, [MarshalAs(UnmanagedType.I1)] bool status);
    }
}