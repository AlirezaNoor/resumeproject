using Microsoft.AspNetCore.Mvc;

namespace Resume.Controllers
{
    public class FileController1 : Controller
    {
        public FileResult DownloadFile() // can also be IActionResult
        {
            // this file is in the wwwroot folder
            string filePath = "~/Cv/MyCv.pdf";
            Response.Headers.Add("Content-Disposition", "inline; filename=test.pdf");
            return File(filePath, "application/pdf");
        }
    }
}
