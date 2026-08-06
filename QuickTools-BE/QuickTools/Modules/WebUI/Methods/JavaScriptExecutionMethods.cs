using System.Runtime.InteropServices;
using System.Text;

namespace QuickTools.Modules.WebUI.Methods
{
    public static class JavaScriptExecutionMethods
    {
        private const string Library = "webui";
        
        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_run(UIntPtr window, string script);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_run_client(ref webui_event_t e, string script);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool webui_script(UIntPtr window, string script, UIntPtr timeout, StringBuilder buffer,
            UIntPtr buffer_length);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool webui_script_client(ref webui_event_t e, string script, UIntPtr timeout,
            StringBuilder buffer, UIntPtr buffer_length);
    }
}