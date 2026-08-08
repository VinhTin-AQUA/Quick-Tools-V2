using System.Runtime.InteropServices;

namespace QuickTools.Windows.Modules.WebUI.Methods
{
    public static class ErrorMethods
    {
        private const string Library = "webui";
        
        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern UIntPtr webui_get_last_error_number();

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr webui_get_last_error_message();
    }
}