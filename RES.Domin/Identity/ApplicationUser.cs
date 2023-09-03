using Microsoft.AspNetCore.Identity;

namespace RES.Domin.Identity
{
    public class ApplicationUser : IdentityUser<string>
    {
        public string  Fullname   { get; set; }
    }
}
