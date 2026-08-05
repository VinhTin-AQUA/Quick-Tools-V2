using System.Runtime.InteropServices;

namespace QuickTools.Modules.WebUI.Methods
{
    public static class WindowManagementMethods
    {
        private const string Library = "webui";
        
        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern UIntPtr webui_new_window();

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern UIntPtr webui_new_window_id(UIntPtr window_number);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern UIntPtr webui_get_new_window_id();

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool webui_show(UIntPtr window, string content);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool webui_show_client(ref webui_event_t e, string content);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool webui_show_browser(UIntPtr window, string content, UIntPtr browser);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr webui_start_server(UIntPtr window, string content);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool webui_show_wv(UIntPtr window, string content);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_close(UIntPtr window);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_close_client(ref webui_event_t e);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_destroy(UIntPtr window);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_exit();

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_wait();

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool webui_wait_async();

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_clean();

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool webui_is_shown(UIntPtr window);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_minimize(UIntPtr window);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_maximize(UIntPtr window);
        
        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern UIntPtr webui_get_port(UIntPtr window);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool webui_set_port(UIntPtr window, UIntPtr port);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern UIntPtr webui_get_free_port();

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern UIntPtr webui_get_parent_process_id(UIntPtr window);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern UIntPtr webui_get_child_process_id(UIntPtr window);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr webui_win32_get_hwnd(UIntPtr window);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr webui_get_hwnd(UIntPtr window);
    }
}