using System.Text.Json;
using QuickTools.Services.Iloveimg;
using QuickTools.Windows.Constants;
using QuickTools.Windows.Helpers;
using QuickTools.Windows.Models.Iloveimg;
using QuickTools.Windows.Modules.WebUI;
using QuickTools.Windows.Modules.WebUI.Methods;

namespace QuickTools.Windows.Handlers.IloveimgHandlers
{
    public static class UpscaleImageHandler
    {
        public static async Task<object?> UpscaleImage(UIntPtr window, UIntPtr event_type, IntPtr element, UIntPtr event_number, UIntPtr bind_id)
        {
            IntPtr dataPtr = InterfaceMethods.webui_interface_get_string_at(window, event_number, UIntPtr.Zero);
            string jsonData = MarshalHelper.PtrToString(dataPtr);
            
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true 
            };
            List<UpscaleImageRequest> upscaleImageRequests = JsonSerializer.Deserialize<List<UpscaleImageRequest>>(jsonData, options) ?? [];
            List<string> imagePaths = [];
            foreach (UpscaleImageRequest upscaleImageRequest in upscaleImageRequests)
            {
                string path = await FilesHelper.SaveBase64File(upscaleImageRequest.Base64, upscaleImageRequest.Name,
                    EFolder.Iloveimg_Upscale);
                imagePaths.Add(path);
            }

            await UpscaleImageService.Upscale(imagePaths);
            
            return upscaleImageRequests;
        }
    }
}