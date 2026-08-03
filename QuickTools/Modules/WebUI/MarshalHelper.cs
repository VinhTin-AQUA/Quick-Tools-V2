using System.Runtime.InteropServices;

namespace QuickTools.Modules.WebUI
{
    public static class MarshalHelper
    {
        public static string PtrToString(IntPtr ptr)
        {
            return Marshal.PtrToStringUTF8(ptr)
                   ?? string.Empty;
        }
    }
}