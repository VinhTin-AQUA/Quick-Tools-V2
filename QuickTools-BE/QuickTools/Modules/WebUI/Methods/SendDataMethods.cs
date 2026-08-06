using System.Runtime.InteropServices;

namespace QuickTools.Modules.WebUI.Methods
{
    public static class SendDataMethods
    {
        private const string Library = "webui";
        
        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_send_raw(UIntPtr window, string function, IntPtr raw, UIntPtr size);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_send_raw_client(ref webui_event_t e, string function, IntPtr raw, UIntPtr size);

    }
}