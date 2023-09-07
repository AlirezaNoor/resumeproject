using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using RES.Services.Interface.UploadFile;

namespace RES.Services.Class.UploadFile
{
    public class UplodCvFile: IUplodCvFile
    {
        public virtual void upladmycv(IFormFile cv)
        {
            string name = "MyCv.pdf";
            var savepath=Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Cv", name);
            var filepath=Path.Combine(savepath);
            File.Delete(filepath);

            cv.CopyTo(new FileStream(filepath,FileMode.Create));
        }
    }
}
