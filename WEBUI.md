# WebUI

## Download

- download binary

```txt
https://github.com/webui-dev/webui/releases/tag/nightly

webui-linux-gcc-x64.zip

webui-windows-msvc-x64.zip
```

- đổi tên file

```txt
QuickTools/Native/webui/linux-x64/libwebui-2.so thành QuickTools/Native/webui/linux-x64/libwebui.so

QuickTools/Native/webui/win-x64/webui-2.dll thành QuickTools/Native/webui/win-x64/webui.dll

nếu dùng secure thì đổi file secure
QuickTools/Native/webui/win-x64/webui-2-secure.dll thành QuickTools/Native/webui/win-x64/webui.dll
```

## Code Invoke C++ webUI

```txt
QuickTools\Modules\WebUI
```

## JS call BE

- Tạo các Invoke native

```txt
QuickTools\Modules\WebUI
```

- Tạo interfaceBinder

```txt
QuickTools\Modules\WebUI\InterfaceBinder.cs
```

- BE setup config async, tạo các hàm, Bind các hàm

```cs
private static void Main(string[] args)
{
    NativeLibraryManager.Initialize();

    // Tạo window
    var window = WindowManagementMethods.webui_new_window();

    InterfaceBinder.Bind(window, "longTask", LongTaskHandler);
    InterfaceBinder.Bind(window, "getData", GetDataHandler);
    InterfaceBinder.Bind(window, "sendData", SendDataHandler);
    InterfaceBinder.Bind(window, "requestData", RequestDataHandler);
    InterfaceBinder.BindAsyncFunction(window, "asyncFunction", MyAsyncFunction);

    // Cấu hình async
    ConfigMethods.webui_set_config(webui_config.asynchronous_response, true);
    ConfigMethods.webui_set_event_blocking(window, false);

    // Show window
    WebUIManager.Show(window, "/wwwroot/index.html");


    // Wait
    WindowManagementMethods.webui_wait();

    // Cleanup
    WebUIManager.Cleanup();
}
```

### Setup FE

- Cấu trúc thư mục

```txt
QuickTools/
└── wwwroot/
    ├── index.html
    └── webui.js
```

- Lưu ý phải có file webui.js và import vào header html

```html
<!doctype html>
<html lang="en">
	<head>
		<meta charset="UTF-8" />
		<meta name="viewport" content="width=device-width, initial-scale=1.0" />
		<title>Document</title>

		<script src="webui.js"></script>

		...
	</head>
</html>
```

- FE Call các hàm, gửi và nhận dữ liệu

```html
<!doctype html>
<html lang="en">
	<head>
		<meta charset="UTF-8" />
		<meta name="viewport" content="width=device-width, initial-scale=1.0" />
		<title>Document</title>

		<script src="webui.js"></script>

		<style>
			body {
				font-family: Arial;
				padding: 20px;
				background: #f0f0f0;
			}
			.container {
				max-width: 800px;
				margin: 0 auto;
				background: white;
				padding: 20px;
				border-radius: 10px;
			}
			button {
				padding: 10px 20px;
				margin: 5px;
				border: none;
				border-radius: 5px;
				cursor: pointer;
			}
			.btn-primary {
				background: #007bff;
				color: white;
			}
			.btn-success {
				background: #28a745;
				color: white;
			}
			.btn-warning {
				background: #ffc107;
				color: black;
			}
			.btn-danger {
				background: #dc3545;
				color: white;
			}
			#result {
				margin-top: 20px;
				padding: 15px;
				background: #f8f9fa;
				border-radius: 5px;
				min-height: 50px;
			}
			.loading {
				color: #007bff;
				font-weight: bold;
			}
		</style>
	</head>
	<body>
		<div class="container">
			<h1>WebUI Async Examples</h1>

			<div>
				<h3>1. Non-blocking Long Task</h3>
				<button class="btn-primary" onclick="runLongTask()">Run 5s Task</button>
				<span id="status1"></span>
			</div>

			<div>
				<h3>2. Fetch Data</h3>
				<button class="btn-success" onclick="fetchData()">Fetch Data</button>
				<div id="dataResult"></div>
			</div>

			<div>
				<h3>3. Send Data</h3>
				<button class="btn-warning" onclick="sendData()">Send Data</button>
				<div id="sendResult"></div>
			</div>

			<div>
				<h3>4. Request-Response</h3>
				<button class="btn-danger" onclick="requestResponse()">Request Response</button>
				<div id="responseResult"></div>
			</div>

			<div id="result">Ready...</div>

			<button onclick="runAsync()">Run Async</button>
			<div id="result"></div>
		</div>

		<script>
			// 1. Non-blocking Long Task
			async function runLongTask() {
				document.getElementById('status1').textContent = ' Running...';
				document.getElementById('status1').className = 'loading';
				const result = await webui.call('longTask', 42);
				document.getElementById('status1').textContent = ' Done: ' + result;
				document.getElementById('status1').className = '';
			}

			// 2. Fetch Data
			async function fetchData() {
				document.getElementById('dataResult').textContent = 'Loading...';
				const data = await webui.call('getData');
				document.getElementById('dataResult').textContent = JSON.stringify(data, null, 2);
			}

			// 3. Send Data
			async function sendData() {
				const data = {
					name: 'Test User',
					email: 'test@example.com',
					message: 'Hello from browser!',
				};
				document.getElementById('sendResult').textContent = 'Sending...';
				const result = await webui.call('sendData', JSON.stringify(data));
				document.getElementById('sendResult').textContent = result;
			}

			// 4. Request-Response
			async function requestResponse() {
				const requestId = Date.now().toString();
				document.getElementById('responseResult').textContent = 'Requesting...';
				const result = await webui.call('requestData', requestId);
				document.getElementById('responseResult').textContent = result;
			}

			async function runAsync() {
				const result = await webui.call('asyncFunction');
				document.getElementById('result').textContent = JSON.stringify(result);
			}
		</script>
	</body>
</html>
```

### Setup Angular
