using System.Runtime.InteropServices;

namespace QuickTools.Windows.Modules.WebUI.Methods
{
    public static class MemoryMethods
    {
        private const string Library = "webui";
        
        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_free(IntPtr ptr);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr webui_malloc(UIntPtr size);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void webui_memcpy(IntPtr dest, IntPtr src, UIntPtr count);
    }
}