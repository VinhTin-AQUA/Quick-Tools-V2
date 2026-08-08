using System.Runtime.InteropServices;

namespace QuickTools.Windows.Modules.WebUI.Methods
{
    public static class NavigationMethods
    {
        private const string Library = "webui";
        
        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_navigate(UIntPtr window, string url);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_navigate_client(ref webui_event_t e, string url);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_open_url(string url);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr webui_get_url(UIntPtr window);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_set_public(UIntPtr window, [MarshalAs(UnmanagedType.I1)] bool status);

    }
}