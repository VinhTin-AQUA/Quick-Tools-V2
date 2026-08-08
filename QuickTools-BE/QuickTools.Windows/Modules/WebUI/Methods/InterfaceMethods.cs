using System.Runtime.InteropServices;
using System.Text;

namespace QuickTools.Windows.Modules.WebUI.Methods
{
    public static class InterfaceMethods
    {
        private const string Library = "webui";

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern UIntPtr webui_interface_bind(UIntPtr window, string element, IntPtr func);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_interface_set_response(UIntPtr window, UIntPtr event_number, string response);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool webui_interface_is_app_running();

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern UIntPtr webui_interface_get_window_id(UIntPtr window);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr webui_interface_get_string_at(UIntPtr window, UIntPtr event_number, UIntPtr index);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern long webui_interface_get_int_at(UIntPtr window, UIntPtr event_number, UIntPtr index);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern double webui_interface_get_float_at(UIntPtr window, UIntPtr event_number, UIntPtr index);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool webui_interface_get_bool_at(UIntPtr window, UIntPtr event_number, UIntPtr index);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern UIntPtr webui_interface_get_size_at(UIntPtr window, UIntPtr event_number, UIntPtr index);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool webui_interface_show_client(UIntPtr window, UIntPtr event_number, string content);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_interface_close_client(UIntPtr window, UIntPtr event_number);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_interface_send_raw_client(UIntPtr window, UIntPtr event_number,
            string function, IntPtr raw, UIntPtr size);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_interface_navigate_client(UIntPtr window, UIntPtr event_number,
            string url);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_interface_run_client(UIntPtr window, UIntPtr event_number,
            string script);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool webui_interface_script_client(UIntPtr window, UIntPtr event_number,
            string script, UIntPtr timeout, StringBuilder buffer, UIntPtr buffer_length);
    }
}