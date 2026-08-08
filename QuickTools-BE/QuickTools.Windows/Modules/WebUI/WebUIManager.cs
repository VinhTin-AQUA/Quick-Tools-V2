using System.Runtime.InteropServices;
using System.Text;
using QuickTools.Windows.Modules.WebUI.Methods;

namespace QuickTools.Windows.Modules.WebUI
{
    /*
     * Quản lý toàn bộ thư viện WebUI
     */

    public static class WebUIManager
    {
        // Store delegates to prevent GC
        private static readonly Dictionary<UIntPtr, webui_callback_t> _callbacks = new();
        private static readonly Dictionary<UIntPtr, webui_close_handler_t> _closeHandlers = new();
        private static readonly Dictionary<UIntPtr, webui_file_handler_t> _fileHandlers = new();
        private static readonly Dictionary<UIntPtr, webui_file_handler_window_t> _fileHandlersWindow = new();
        private static readonly Dictionary<UIntPtr, webui_interface_callback_t> _interfaceCallbacks = new();
        private static readonly List<GCHandle> _gcHandles = new();

        // ==================== Binding Methods ====================

        public static UIntPtr Bind(UIntPtr window, string element, webui_callback_t callback)
        {
            var handle = GCHandle.Alloc(callback);
            _gcHandles.Add(handle);
            var ptr = Marshal.GetFunctionPointerForDelegate(callback);
            _callbacks[window] = callback;
            return BindingMethods.webui_bind(window, element, ptr);
        }

        public static UIntPtr InterfaceBind(UIntPtr window, string element, webui_interface_callback_t callback)
        {
            var handle = GCHandle.Alloc(callback);
            _gcHandles.Add(handle);
            var ptr = Marshal.GetFunctionPointerForDelegate(callback);
            _interfaceCallbacks[window] = callback;
            return InterfaceMethods.webui_interface_bind(window, element, ptr);
        }

        public static void SetCloseHandler(UIntPtr window, webui_close_handler_t handler)
        {
            var handle = GCHandle.Alloc(handler);
            _gcHandles.Add(handle);
            var ptr = Marshal.GetFunctionPointerForDelegate(handler);
            _closeHandlers[window] = handler;
            CloseHandlerMethods.webui_set_close_handler_wv(window, ptr);
        }

        public static void SetFileHandler(UIntPtr window, webui_file_handler_t handler)
        {
            var handle = GCHandle.Alloc(handler);
            _gcHandles.Add(handle);
            var ptr = Marshal.GetFunctionPointerForDelegate(handler);
            _fileHandlers[window] = handler;
            FileAndFolderMethods.webui_set_file_handler(window, ptr);
        }

        public static void SetFileHandlerWindow(UIntPtr window, webui_file_handler_window_t handler)
        {
            var handle = GCHandle.Alloc(handler);
            _gcHandles.Add(handle);
            var ptr = Marshal.GetFunctionPointerForDelegate(handler);
            _fileHandlersWindow[window] = handler;
            FileAndFolderMethods.webui_set_file_handler_window(window, ptr);
        }

        public static void SetLogger(webui_logger_t logger, IntPtr userData)
        {
            var handle = GCHandle.Alloc(logger);
            _gcHandles.Add(handle);
            var ptr = Marshal.GetFunctionPointerForDelegate(logger);
            LoggerMethods.webui_set_logger(ptr, userData);
        }

        // ==================== String Helper Methods ====================

        public static string? GetString(IntPtr ptr)
        {
            return ptr != IntPtr.Zero ? Marshal.PtrToStringAnsi(ptr) : null;
        }

        public static string? GetStringFromEvent(ref webui_event_t e)
        {
            return GetString(EventArgumentMethods.webui_get_string(ref e));
        }

        public static string? GetStringAt(ref webui_event_t e, UIntPtr index)
        {
            return GetString(EventArgumentMethods.webui_get_string_at(ref e, index));
        }

        public static string? GetUrl(UIntPtr window)
        {
            return GetString(NavigationMethods.webui_get_url(window));
        }

        public static string? GetLastErrorMessage()
        {
            return GetString(ErrorMethods.webui_get_last_error_message());
        }

        public static string? GetMimeType(string file)
        {
            return GetString(FileAndFolderMethods.webui_get_mime_type(file));
        }

        public static string? Encode(string str)
        {
            return GetString(EncodingMethods.webui_encode(str));
        }

        public static string? Decode(string str)
        {
            return GetString(EncodingMethods.webui_decode(str));
        }

        public static string? StartServer(UIntPtr window, string content)
        {
            return GetString(WindowManagementMethods.webui_start_server(window, content));
        }

        // ==================== Raw Data Helper Methods (Safe version) ====================

        public static void SendRaw<T>(UIntPtr window, string function, T[] data) where T : struct
        {
            var size = Marshal.SizeOf(typeof(T));
            var totalSize = data.Length * size;
            var ptr = Marshal.AllocHGlobal(totalSize);

            try
            {
                for (var i = 0; i < data.Length; i++)
                {
                    var elementPtr = IntPtr.Add(ptr, i * size);
                    Marshal.StructureToPtr(data[i], elementPtr, false);
                }

                SendDataMethods.webui_send_raw(window, function, ptr, (UIntPtr)totalSize);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        public static void SendRawClient<T>(ref webui_event_t e, string function, T[] data) where T : struct
        {
            var size = Marshal.SizeOf(typeof(T));
            var totalSize = data.Length * size;
            var ptr = Marshal.AllocHGlobal(totalSize);

            try
            {
                for (var i = 0; i < data.Length; i++)
                {
                    var elementPtr = IntPtr.Add(ptr, i * size);
                    Marshal.StructureToPtr(data[i], elementPtr, false);
                }

                SendDataMethods.webui_send_raw_client(ref e, function, ptr, (UIntPtr)totalSize);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        // Overload for byte arrays (most common use case)
        public static void SendRaw(UIntPtr window, string function, byte[] data)
        {
            var ptr = Marshal.AllocHGlobal(data.Length);
            try
            {
                Marshal.Copy(data, 0, ptr, data.Length);
                SendDataMethods.webui_send_raw(window, function, ptr, (UIntPtr)data.Length);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        public static void SendRawClient(ref webui_event_t e, string function, byte[] data)
        {
            var ptr = Marshal.AllocHGlobal(data.Length);
            try
            {
                Marshal.Copy(data, 0, ptr, data.Length);
                SendDataMethods.webui_send_raw_client(ref e, function, ptr, (UIntPtr)data.Length);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        // Overload for string (UTF-8)
        public static void SendRawString(UIntPtr window, string function, string data)
        {
            var bytes = Encoding.UTF8.GetBytes(data);
            SendRaw(window, function, bytes);
        }

        public static void SendRawStringClient(ref webui_event_t e, string function, string data)
        {
            var bytes = Encoding.UTF8.GetBytes(data);
            SendRawClient(ref e, function, bytes);
        }

        // ==================== Script Helper Methods ====================

        public static bool Script(UIntPtr window, string script, out string? result, uint timeout = 0)
        {
            const int bufferSize = 65536;
            var buffer = new StringBuilder(bufferSize);
            var success = JavaScriptExecutionMethods.webui_script(window, script, timeout, buffer, bufferSize);
            result = success ? buffer.ToString() : null;
            return success;
        }

        public static bool ScriptClient(ref webui_event_t e, string script, out string? result, uint timeout = 0)
        {
            const int bufferSize = 65536;
            var buffer = new StringBuilder(bufferSize);
            var success = JavaScriptExecutionMethods.webui_script_client(ref e, script, timeout, buffer, bufferSize);
            result = success ? buffer.ToString() : null;
            return success;
        }

        // ==================== Window Helper Methods ====================

        public static bool Show(UIntPtr window, string content, webui_browser browser = webui_browser.AnyBrowser)
        {
            if (browser == webui_browser.AnyBrowser)
                return WindowManagementMethods.webui_show(window, content);
            return WindowManagementMethods.webui_show_browser(window, content, (UIntPtr)browser);
        }

        public static IntPtr GetHWND(UIntPtr window)
        {
            return WindowManagementMethods.webui_get_hwnd(window);
        }

        // ==================== Memory Management ====================

        public static IntPtr Malloc(UIntPtr size)
        {
            return MemoryMethods.webui_malloc(size);
        }

        public static void Free(IntPtr ptr)
        {
            MemoryMethods.webui_free(ptr);
        }

        public static void MemCpy(IntPtr dest, IntPtr src, UIntPtr count)
        {
            MemoryMethods.webui_memcpy(dest, src, count);
        }

        // ==================== Cleanup ====================

        public static void Cleanup()
        {
            // Free all GCHandles
            foreach (var handle in _gcHandles)
                if (handle.IsAllocated)
                    handle.Free();
            _gcHandles.Clear();

            _callbacks.Clear();
            _closeHandlers.Clear();
            _fileHandlers.Clear();
            _fileHandlersWindow.Clear();
            _interfaceCallbacks.Clear();

            WindowManagementMethods.webui_clean();
        }
    }
}
