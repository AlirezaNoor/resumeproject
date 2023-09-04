using Microsoft.AspNetCore.Http;

namespace RES.Services.Interface.UploadFile
{
    public interface IFilenames
    {
        string imagename(string fileName);
        string UploadFile(IFormFile MyImage);
    }
}
