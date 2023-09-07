using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using RES.Services.Interface.UploadFile;

namespace RES.Services.Class.UploadFile
{
    public class Filenames : IFilenames
    {
        public string imagename(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return fileName;
        }


        public string UploadFile(IFormFile MyImage)
        {
            var uniqueFileName = imagename(MyImage.FileName);
            string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", uniqueFileName);
            var filePath = Path.Combine(SavePath);
            MyImage.CopyTo(new FileStream(filePath, FileMode.Create));
            return uniqueFileName;
        }
    }
}
