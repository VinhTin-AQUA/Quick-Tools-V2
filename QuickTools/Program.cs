using QuickTools.Modules.WebUI;

namespace QuickTools;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        
        WebUI app = new();

        WebUIWindow window = app.CreateWindow();
        bool result = window.ShowBrowser("https://www.facebook.com/", Browser.Default);
        Console.WriteLine($"Show result: {result}");
        
        window.Close();
        app.Wait();
        WebUI.Clean();
    }
}