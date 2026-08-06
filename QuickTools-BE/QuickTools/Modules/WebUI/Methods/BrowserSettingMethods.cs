using System.Runtime.InteropServices;

namespace QuickTools.Modules.WebUI.Methods
{
    public static class BrowserSettingMethods
    {
        private const string Library = "webui";
        
        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern UIntPtr webui_get_best_browser(UIntPtr window);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool webui_browser_exist(UIntPtr browser);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_set_browser_folder(string path);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_set_runtime(UIntPtr window, UIntPtr runtime);
    }
}