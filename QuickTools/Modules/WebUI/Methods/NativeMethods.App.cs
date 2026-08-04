using System.Runtime.InteropServices;

namespace QuickTools.Modules.WebUI.Methods
{
    public static class NativeMethodApps
    {
        private const string Library = "webui";
            
        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_wait();

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_exit();

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_clean();
    }
}