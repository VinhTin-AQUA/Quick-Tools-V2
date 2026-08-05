using QuickTools.Modules.LoaderManager;
using QuickTools.Modules.WebUI;
using QuickTools.Modules.WebUI.Methods;

namespace QuickTools;

class Program
{
    static void Main(string[] args)
    {
        // NativeLibraryManager.Initialize();
        //
        // Console.WriteLine("Hello, World!");
        //
        // WebUIManager app = new();
        //
        // WebUIWindow window = app.CreateWindow();
        // bool result = window.ShowBrowser("https://www.google.com/", Browser.Default);
        // Console.WriteLine($"Show result: {result}");
        //
        // window.Close();
        // app.Wait();
        // WebUIManager.Clean();
        
        NativeLibraryManager.Initialize();
        
        // Tạo window
        var window = WindowManagementMethods.webui_new_window();
        
        // Bind callback
        WebUIManager.Bind(window, "myFunction", MyCallback);
        
        // Set event blocking
        ConfigMethods.webui_set_event_blocking(window, true);
        
        // Show window
        WebUIManager.Show(window, @"
            <html>
            <body>
                <button onclick='myFunction()'>Click me</button>
                <button onclick='myFunction(\""Hello\"", 123)'>Send data</button>
            </body>
            </html>
        ");
        
        // Wait
        WindowManagementMethods.webui_wait();
        
        // Cleanup
        WebUIManager.Cleanup();
    }
    
    static void MyCallback(ref webui_event_t e)
    {
        Console.WriteLine($"Event: {e.event_type}");
        Console.WriteLine($"Element: {e.GetElement()}");
        Console.WriteLine($"Window: {e.window}");
        
        // Lấy arguments
        long count = (long)EventArgumentMethods.webui_get_count(ref e);
        Console.WriteLine($"Arguments count: {count}");
        
        if (count > 0)
        {
            // Lấy string argument
            string? arg1 = WebUIManager.GetStringAt(ref e, UIntPtr.Zero);
            Console.WriteLine($"Arg 0: {arg1}");
            
            if (count > 1)
            {
                long arg2 = EventArgumentMethods.webui_get_int_at(ref e, (UIntPtr)1);
                Console.WriteLine($"Arg 1: {arg2}");
            }
        }
        
        // Trả về response
        ReturnResponseMethos.webui_return_string(ref e, "Hello from C#!");
    }
}