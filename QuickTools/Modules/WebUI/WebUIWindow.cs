using QuickTools.Modules.WebUI.Methods;

namespace QuickTools.Modules.WebUI
{
    /*
     * Quản lý 1 cửa sổ
     * sử dụng các NativeMethods ở đây
     */
    public sealed class WebUIWindow : IDisposable
    {
        private bool _disposed;

        internal WebUIWindow()
        {
            Id = NativeMethods_Window.webui_new_window();
        }

        /// <summary> /// Native window id. /// </summary>
        public nuint Id { get; }

        public void Show(string html)
        {
            ThrowIfDisposed();
            NativeMethods_Window.webui_show(Id, html);
        }

        public bool ShowBrowser(string url, Browser browser = Browser.Default)
        {
            ThrowIfDisposed();
            bool result = NativeMethods_Window.webui_show_browser(Id, url, (nuint)browser);
            
            // if (!result)
            // {
            //     throw new InvalidOperationException($"Không thể hiển thị trình duyệt với URL: {url}");
            // }
            return result;
        }


        public void Navigate(string url)
        {
            ThrowIfDisposed();
            NativeMethods_Window.webui_navigate(Id, url);
        }

        public void Close()
        {
            ThrowIfDisposed();
            NativeMethods_Window.webui_close(Id);
        }

        public void SetSize(uint width, uint height)
        {
            ThrowIfDisposed();
            NativeMethods_Window.webui_set_size(Id, width, height);
        }

        public void SetPosition(uint x, uint y)
        {
            ThrowIfDisposed();
            NativeMethods_Window.webui_set_position(Id, x, y);
        }

        public void SetBrowser(Browser browser)
        {
            ThrowIfDisposed();
            NativeMethods_Window.webui_set_browser(Id, (int)browser);
        }

        public void SetTitle(string title)
        {
            ThrowIfDisposed();
            NativeMethods_Window.webui_set_title(Id, title);
        }

        public void SetRootFolder(string folder)
        {
            ThrowIfDisposed();
            NativeMethods_Window.webui_set_root_folder(Id, folder);
        }

        public bool IsShown()
        {
            ThrowIfDisposed();
            return NativeMethods_Window.webui_is_shown(Id);
        }

        public void Destroy()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (_disposed) return;
            NativeMethods_Window.webui_destroy(Id);
            _disposed = true;
            GC.SuppressFinalize(this);
        }

        ~WebUIWindow()
        {
            Dispose();
        }

        private void ThrowIfDisposed()
        {
            ObjectDisposedException.ThrowIf(_disposed, this);
        }
    }
}