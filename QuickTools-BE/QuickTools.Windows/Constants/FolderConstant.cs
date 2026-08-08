namespace QuickTools.Windows.Constants
{
    public class FolderConstant
    {
        public static string GetFolder(EFolder folder)
        {
            return folder switch
            {
                EFolder.Temps => "Temps",
                EFolder.Iloveimg_Upscale => "Iloveimg_Upscale",
                
                _ => string.Empty
            };
        }
        
    }

    public enum EFolder
    {
        Temps,
        Iloveimg_Upscale,
    }
}