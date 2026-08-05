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

- build

```txt
dotnet publish QuickTools\QuickTools.csproj -c Release -r win-x64 -p:SelfContained=true  -o ./publish

dotnet publish QuickTools/QuickTools.csproj -c Release -r linux-x64 -p:SelfContained=true  -o ./publish

```

## Setup binary

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

```cs
private const string Library = "webui";
```


