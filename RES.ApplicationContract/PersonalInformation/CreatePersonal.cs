using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace RES.ApplicationContract.PersonalInformation
{
    public class CreatePersonal
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "مقادیر معتبر نمی باشند")]

        public string Name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "مقادیر معتبر نمی باشند")]

        public string Expertise { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "مقادیر معتبر نمی باشند")]

        public DateTime BrithdatDateTime { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "مقادیر معتبر نمی باشند")]

        public string Adress { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "مقادیر معتبر نمی باشند")]

        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "مقادیر معتبر نمی باشند")]

        public string skype { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "مقادیر معتبر نمی باشند")]

        public IFormFile Image { get; set; }

    }
}
