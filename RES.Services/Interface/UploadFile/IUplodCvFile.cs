using Microsoft.AspNetCore.Http;

namespace RES.Services.Interface.UploadFile
{
    public interface IUplodCvFile
    {
        void upladmycv(IFormFile cv);
    }
}
