using System.Runtime.InteropServices;

namespace QuickTools.Modules.WebUI.Methods
{
    public static class IconMethods
    {
        private const string Library = "webui";
        
        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_set_icon(UIntPtr window, string icon, string icon_type);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_set_icon_file(UIntPtr window, string path);
    }
}