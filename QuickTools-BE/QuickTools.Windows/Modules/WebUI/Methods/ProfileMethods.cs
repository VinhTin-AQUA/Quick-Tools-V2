using System.Runtime.InteropServices;

namespace QuickTools.Windows.Modules.WebUI.Methods
{
    public static class ProfileMethods
    {
        private const string Library = "webui";
        

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_delete_all_profiles();

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_delete_profile(UIntPtr window);
    }
}