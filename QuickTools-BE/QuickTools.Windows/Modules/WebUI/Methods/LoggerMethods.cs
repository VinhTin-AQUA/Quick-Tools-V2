using System.Runtime.InteropServices;

namespace QuickTools.Windows.Modules.WebUI.Methods
{
    public static class LoggerMethods
    {
        private const string Library = "webui";
        
        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_set_logger(IntPtr func, IntPtr user_data);
    }
}