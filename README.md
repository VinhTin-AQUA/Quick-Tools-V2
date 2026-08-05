## Download binary

- download binary

```txt
https://github.com/webui-dev/webui/releases/tag/nightly

webui-linux-gcc-x64.zip

webui-windows-msvc-x64.zip
```

- đổi tên file

```txt
QuickTools/Native/webui/linux/libwebui-2.so thành QuickTools/Native/webui/linux/libwebui.so

QuickTools/Native/webui/windows/webui-2.dll thành QuickTools/Native/webui/windows/webui.dll

nếu dùng secure thì đổi file secure
QuickTools/Native/webui/windows/webui-2-secure.dll thành QuickTools/Native/webui/windows/webui.dll
```

- Cấu trúc thư mục Native

```txt
Native/
├── linux-x64/
│   ├── ffmpeg/
│   │   ├── libavutil.so
│   │   ├── libswresample.so
│   │   ├── libswscale.so
│   │   ├── libavcodec.so
│   │   ├── libavformat.so
│   │   ├── libavfilter.so
│   │   └── libavdevice.so
│   └── webui/
├── win-x64/
│   ├── ffmpeg/
│   │   ├── avutil.dll
│   │   ├── swresample.dll
│   │   ├── swscale.dll
│   │   ├── avcodec.dll
│   │   ├── avformat.dll
│   │   ├── avfilter.dll
│   │   └── avdevice.dll
│   └── webui/
├── linux-arm64/
└── win-arm64/
```

- Tên thư mục phải trùng với tên trong DllImport. Ví dụ "webui"

## Load binaries

- Vào QuickTools/Modules/LoaderManager/NativeLibraryManager.cs, thêm thư mục thư viện

```cs
private static void RegisterLibraries()
{
    // Đăng ký từng thư viện
    RegisterLibrary("webui", "webui");
    RegisterLibrary("ffmpeg", "ffmpeg");
    // Thêm các thư viện khác nếu cần
    // RegisterLibrary("opencv", "opencv");
    // RegisterLibrary("tensorflow", "tensorflow");
}
```

## build

```txt
dotnet publish QuickTools\QuickTools.csproj -c Release -r win-x64 -p:SelfContained=true  -o ./publish

dotnet publish QuickTools/QuickTools.csproj -c Release -r linux-x64 -p:SelfContained=true  -o ./publish
```

```cs
private const string Library = "webui";
```

## WebUI

### Code Invoke C++ webUI

### JS call BE

- Tạo các Invoke native
- Tạo interfaceBinder
- BE setup config async, tạo các hàm, Bind các hàm
- FE Call các hàm, gửi và nhận dữ liệu
