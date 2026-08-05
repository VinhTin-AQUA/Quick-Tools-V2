- Kiến trúc

```txt
Browser (JS)
        │
        ▼
 WebUI Bind
        │
        ▼
Command Dispatcher
        │
        ├─────────────── UI Thread (WebUI API)
        │
        └─────────────── Worker Thread(s)
                            │
                            ▼
                    Business Logic
                            │
                            ▼
                       Native DLL
```

- Native Wrapper

```cs
public static class Native
{
    private const string Lib = "webui";

    [DllImport(Lib, CallingConvention = CallingConvention.Cdecl)]
    internal static extern void webui_show();

    [DllImport(Lib, CallingConvention = CallingConvention.Cdecl)]
    internal static extern void webui_close();

    [DllImport(Lib, CallingConvention = CallingConvention.Cdecl)]
    internal static extern void webui_wait();

    [DllImport(Lib, CallingConvention = CallingConvention.Cdecl)]
    internal static extern void webui_exit();
}
```

- Dispatcher

```cs
public sealed class Dispatcher
{
    private readonly TaskFactory _worker =
        new(TaskScheduler.Default);

    public void Run(Action action)
    {
        action();
    }

    public Task RunAsync(Action action)
    {
        return _worker.StartNew(action);
    }

    public Task<T> RunAsync<T>(Func<T> func)
    {
        return _worker.StartNew(func);
    }

    public Task<T> RunAsync<T>(Func<Task<T>> func)
    {
        return _worker
            .StartNew(func)
            .Unwrap();
    }
}
```

- Singleton

```cs
public static class AppDispatcher
{
    public static Dispatcher Default { get; }
        = new Dispatcher();
}
```

- WebUI Wrapper

```cs
public static class WebUI
{
    public static void Show()
    {
        Native.webui_show();
    }

    public static void Close()
    {
        Native.webui_close();
    }

    public static void Wait()
    {
        Native.webui_wait();
    }

    public static void Exit()
    {
        Native.webui_exit();
    }
}
```

- Business Service

```cs
public class AIService
{
    public string Generate()
    {
        Thread.Sleep(5000);

        return "Done";
    }
}
```

- Command Dispatcher
```cs
public class CommandDispatcher
{
    private readonly AIService _ai =
        new();

    public async Task<string> RunAI()
    {
        return await AppDispatcher.Default
            .RunAsync(() =>
            {
                return _ai.Generate();
            });
    }
}
```

- Nếu sau này có OCR

```cs
public async Task<string> OCR()
{
    return await AppDispatcher.Default
        .RunAsync(() =>
        {
            return ocr.Run();
        });
}
```

- Bind

```cs
var dispatcher = new CommandDispatcher();

window.Bind("runAI", async e =>
{
    var result = await dispatcher.RunAI();

    e.Return(result);
});
```

- Nếu cần progress

```cs
window.Bind("runAI", e =>
{
    _ = Task.Run(async () =>
    {
        for(int i=0;i<=100;i+=10)
        {
            window.Script($"""
                progress({i});
            """);

            await Task.Delay(500);
        }

        window.Script("""
            finish();
        """);
    });

    e.Return("started");
});
```

- JS

```js
await api.runAI();

function progress(v)
{
    bar.value = v;
}

function finish()
{
    alert("Done");
}
```

- Frontend

```js
async function generate()
{
    button.disabled = true;

    try
    {
        const result =
            await backend.runAI();

        console.log(result);
    }
    finally
    {
        button.disabled = false;
    }
}
```

- Nếu task rất dài

```js
await backend.startAI();
```

```cs
window.Bind("startAI", e =>
{
    _ = Task.Run(() =>
    {
        var result = ai.Generate();

        window.Script($"""
            aiFinished("{result}");
        """);
    });

    e.Return("ok");
});
```

```js
await backend.startAI();

function aiFinished(result)
{
    console.log(result);
}
```


- kiến trúc cuối cùng

```txt
JS
 │
 ▼
Bridge
 │
 ▼
Bind
 │
 ▼
Command Dispatcher
 │
 ├─────────────── UI Command
 │                     │
 │                     ▼
 │               Native.webui_*
 │
 └─────────────── Background Command
                       │
                       ▼
                 Business Service
                       │
                       ▼
                    Native DLL
```





## Call trong angular

- Tạo file: src/types/webui.d.ts

```ts
interface Window {
    runAI: () => Promise<string>;
    progress: (value: number) => void;
    finish: () => void;
}
```

- Gọi từ Angular component

```ts
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  template: `
    <button (click)="startAI()">
      Run AI
    </button>

    <div>
      Progress: {{progress}}%
    </div>
  `
})
export class AppComponent {

  progress = 0;

  constructor() {

    window.progress = (value: number) => {
      this.progress = value;
    };

    window.finish = () => {
      console.log("AI finished");
    };
  }


  async startAI() {
    const result = await window.runAI();

    console.log(result);
  }
}
```



