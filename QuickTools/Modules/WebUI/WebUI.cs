using QuickTools.Modules.WebUI.Methods;

namespace QuickTools.Modules.WebUI
{
    /*
     * Quản lý toàn bộ thư viện WebUI
     */
    public sealed class WebUI
    {
        public WebUIWindow CreateWindow()
        {
            return new WebUIWindow();
        }

        public void Wait()
        {
            NativeMethods.webui_wait();
        }

        public void Exit()
        {
            NativeMethods.webui_exit();
        }

        public static void Clean()
        {
            NativeMethods.webui_clean();
        }
    }
}