using Microsoft.AspNetCore.Http;

namespace RES.ApplicationContract.blogs
{
    public class CreateBlogview
    {
        public string tiltle { get; set; }
        public string descrrpition { get; set; }
        public IFormFile img { get; set; }
        public DateTime time { get; set; }
    }
}
