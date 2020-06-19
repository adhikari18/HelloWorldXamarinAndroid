
namespace MyUserManager
{
    public class FileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            var applicationFolderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return System.IO.Path.Combine(applicationFolderPath, filename);
        }
    }
}