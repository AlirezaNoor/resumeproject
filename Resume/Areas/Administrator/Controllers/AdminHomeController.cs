using Microsoft.AspNetCore.Mvc;
using RES.ApplicationContract.PersonalInformation;
using RES.Domin.PersonalInformation;
using RES.Services.Interface;
using RES.Services.Interface.UploadFile;

namespace Resume.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class AdminHomeController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IFilenames _filenames;
        public AdminHomeController(IUnitOfWork context, IFilenames filenames)
        {
            _context = context;
            _filenames = filenames;
        }

        public IActionResult Index()
        {
            var test = _context.PersonalUW.Get().FirstOrDefault();

            return View(test);
        }

        public IActionResult personalinformation()
        {
            CreatePersonal create = new();
            return View(create);

        }

        [HttpPost]
        public IActionResult personalinformation(CreatePersonal e)
        {
            var info = _context.PersonalUW.Get();
            if (info.Count() > 0)
            {
                return View(ViewBag.error = "شما اطلاعات ثبت نموده ایید ،لطفا قبلی را اصلاح نمایید");
            }

            if (!ModelState.IsValid)
            {
                return View(e);
            }

            var file = _filenames.UploadFile(e.Image);
            if (file == null)
            {
                return (ViewBag.error);
            }

            ;

            Personal p = new()
            {
                Name = e.Name,
                Adress = e.Adress,
                BrithdatDateTime = e.BrithdatDateTime,
                Email = e.Email,
                Expertise = e.Expertise,
                Image = file,
                skype = e.skype

            };
            _context.PersonalUW.insert(p);
            _context.save();
            return Redirect("AdminHome/index");
        }

        [HttpGet]
        
        public IActionResult EditedPersonalinfo(long id)
        {
            if (id == null)
            {
                return View(ViewBag.error = "اطلاعات یافت نشد");
            }

            var res = _context.PersonalUW.getbyid(id);
            if (res == null)
            {
                return View(ViewBag.error = "اطلاعات یافت نشد");
            }

            EdietPersonal e = new()
            {
                Email = res.Email,
                Name = res.Name,
                Expertise = res.Expertise,
                BrithdatDateTime = res.BrithdatDateTime,
                Adress = res.Adress,
                skype = res.skype,
                Id = res.Id,
            };
            return View(e);
        }
        [HttpPost]
        [Route("Administrator/AdminHome/EditedPersonalinfo")]
         public IActionResult EditedPersonalinfo(EdietPersonal e)
        {
            if (!ModelState.IsValid)
            {
                return View(ViewBag.error = "اطلاعات یافت نشد");
            }
            var file = _filenames.UploadFile(e.Image);
            if (file == null)
            {
                return (ViewBag.error);
            }

            ;

            Personal p = new()
            {
                Name = e.Name,
                Adress = e.Adress,
                BrithdatDateTime = e.BrithdatDateTime,
                Email = e.Email,
                Expertise = e.Expertise,
                Image = file,
                skype = e.skype,
                Id = e.Id

            };
            _context.PersonalUW.update(p);
            _context.save();
            return Redirect("index");
        }

 

    }
}
