using System.Runtime.InteropServices;

namespace QuickTools.Windows.Modules.WebUI.Methods
{
    public static class TimeoutMethods
    {  
        private const string Library = "webui";
        
        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_set_timeout(UIntPtr second);
    }
}