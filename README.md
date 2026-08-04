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
```