using QuickTools.Modules.LoaderManager;
using QuickTools.Modules.WebUI.Methods;

namespace QuickTools.Modules.WebUI
{
    /*
     * Quản lý toàn bộ thư viện WebUI
     */
    public sealed class WebUI
    {
        private const string Library = "webui";

        public WebUI()
        {
        }
        
        public WebUIWindow CreateWindow()
        {
            return new WebUIWindow();
        }

        public void Wait()
        {
            NativeMethodApps.webui_wait();
        }

        public void Exit()
        {
            NativeMethodApps.webui_exit();
        }

        public static void Clean()
        {
            NativeMethodApps.webui_clean();
        }
    }
}