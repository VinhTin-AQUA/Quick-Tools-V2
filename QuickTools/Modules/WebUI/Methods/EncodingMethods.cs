using System.Runtime.InteropServices;

namespace QuickTools.Modules.WebUI.Methods
{
    public static class EncodingMethods
    {
        private const string Library = "webui";
        
        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr webui_encode(string str);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr webui_decode(string str);
    }
}