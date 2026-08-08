using QuickTools.Windows.Constants;

namespace QuickTools.Windows.Helpers
{
    public static class FilesHelper
    {
        public static async Task<string> SaveBase64File(string base64String, string fileName, EFolder folder)
        {
            try
            {
                string tempFolder = FolderConstant.GetFolder(EFolder.Temps);
                string subDirectory = FolderConstant.GetFolder(folder);
                    
                // Lấy đường dẫn thư mục ứng dụng
                string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string uploadFolder = Path.Combine(appDirectory, tempFolder);
        
                // Xây dựng đường dẫn đầy đủ với thư mục con
                string fullDirectory = string.IsNullOrEmpty(subDirectory) 
                    ? uploadFolder 
                    : Path.Combine(uploadFolder, subDirectory);
        
                // Tạo thư mục nếu chưa tồn tại (kể cả thư mục con)
                Directory.CreateDirectory(fullDirectory);
        
                // Xử lý base64 (loại bỏ phần header nếu có)
                string cleanBase64 = base64String;
                if (base64String.Contains(","))
                {
                    cleanBase64 = base64String.Substring(base64String.IndexOf(",") + 1);
                }
        
                // Chuyển đổi base64 sang byte array
                byte[] fileBytes = Convert.FromBase64String(cleanBase64);
        
                // Tạo đường dẫn file đầy đủ
                string filePath = Path.Combine(fullDirectory, fileName);
        
                // Lưu file
                await File.WriteAllBytesAsync(filePath, fileBytes);
        
                return filePath; // Trả về đường dẫn đã lưu
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lưu file: {ex.Message}");
            }
        }
    }
}