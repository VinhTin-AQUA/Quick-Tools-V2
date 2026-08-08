using System.Runtime.InteropServices;

namespace QuickTools.Windows.Modules.WebUI.Methods
{
    public static class EventArgumentMethods
    {
        private const string Library = "webui";
        
        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern UIntPtr webui_get_count(ref webui_event_t e);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern long webui_get_int_at(ref webui_event_t e, UIntPtr index);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern long webui_get_int(ref webui_event_t e);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern double webui_get_float_at(ref webui_event_t e, UIntPtr index);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern double webui_get_float(ref webui_event_t e);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr webui_get_string_at(ref webui_event_t e, UIntPtr index);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr webui_get_string(ref webui_event_t e);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool webui_get_bool_at(ref webui_event_t e, UIntPtr index);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool webui_get_bool(ref webui_event_t e);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern UIntPtr webui_get_size_at(ref webui_event_t e, UIntPtr index);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern UIntPtr webui_get_size(ref webui_event_t e);
    }
}