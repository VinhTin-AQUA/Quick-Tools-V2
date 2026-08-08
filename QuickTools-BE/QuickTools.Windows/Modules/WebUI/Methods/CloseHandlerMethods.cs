using System.Runtime.InteropServices;

namespace QuickTools.Windows.Modules.WebUI.Methods
{
    public static class CloseHandlerMethods
    {
        private const string Library = "webui";


        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_set_close_handler_wv(UIntPtr window, IntPtr close_handler);
    }
}