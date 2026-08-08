using System.Runtime.InteropServices;

namespace QuickTools.Windows.Modules.WebUI.Methods
{
    public static class ConfigMethods
    {
        private const string Library = "webui";
        
        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_set_config(webui_config option, [MarshalAs(UnmanagedType.I1)] bool status);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_set_event_blocking(UIntPtr window, [MarshalAs(UnmanagedType.I1)] bool status);

    }
}