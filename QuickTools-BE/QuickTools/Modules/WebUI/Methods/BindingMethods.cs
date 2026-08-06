using System.Runtime.InteropServices;

namespace QuickTools.Modules.WebUI.Methods
{
    public static class BindingMethods
    {
        private const string Library = "webui";
        
        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern UIntPtr webui_bind(UIntPtr window, string element, IntPtr func);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_set_context(UIntPtr window, string element, IntPtr context);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr webui_get_context(ref webui_event_t e);
    }
}