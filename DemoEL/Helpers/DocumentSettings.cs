using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace DemoEL.Helpers
{
    public static class DocumentSettings
    {
        public static async Task<string> UploadFile( IFormFile File , string FolderName)
        {    
          
            string FolderPath = Path.Combine(Directory.GetCurrentDirectory() , "wwwroot\\files" , FolderName);

    
            string FileName = $"{Guid.NewGuid()}{File.FileName}";
           

            string FilePathe = Path.Combine(FolderPath, FileName);

            //Save File
            using var FS = new FileStream(FilePathe, FileMode.Create);
            File.CopyTo(FS);

            return  FileName;
        }
  
        public static void DeleteFile(string FileName , string FolderName)
        {
            string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files" , FolderName , FileName);

            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
            }
        }
    }
}
