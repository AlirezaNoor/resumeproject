using Microsoft.AspNetCore.Mvc;
using RES.ApplicationContract.About;
using RES.ApplicationContract.Idowhat;
using RES.ApplicationContract.PersonalInformation;
using RES.Domin.Aboutsme;
using RES.Domin.PersonalInformation;
using RES.Domin.Whatido;
using RES.Services.Class.CustomRepository;
using RES.Services.Interface;
using RES.Services.Interface.CustomRepository;
using RES.Services.Interface.UploadFile;

namespace Resume.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class AdminHomeController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IFilenames _filenames;
        private readonly IUplodCvFile _uplodCvFile;
        private readonly IIdoRepository _idoRepository;
        public AdminHomeController(IUnitOfWork context, IFilenames filenames, IUplodCvFile uplodCvFile, IIdoRepository idoRepository)
        {
            _context = context;
            _filenames = filenames;
            _uplodCvFile = uplodCvFile;
            _idoRepository = idoRepository;
        }
        [Route("Administrator/adminhome/index")]
        public IActionResult Index()
        {
            var test = _context.PersonalUW.Get().FirstOrDefault();

            return View(test);
        }
        [Route("Administrator/adminhome/personalinformation")]
        public IActionResult personalinformation()
        {
            CreatePersonal create = new();
            return View(create);

        }

        [HttpPost]
        [Route("Administrator/adminhome/personalinformation")]
        public IActionResult personalinformation(CreatePersonal e)
        {
            var info = _context.PersonalUW.Get().ToList();
            if (info.Count() > 0)
            {
                ViewBag.error = "شما اطلاعات ثبت نموده ایید ،لطفا قبلی را اصلاح نمایید";
                return View();
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
                ViewBag.error = "اطلاعات یافت نشد";
                return View();

            }

            var res = _context.PersonalUW.getbyid(id);
            if (res == null)
            {
                ViewBag.error = "اطلاعات یافت نشد";
                return View();
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
                ViewBag.error = "اطلاعات یافت نشد";
                return View();
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

        [HttpGet]
        [Route("Administrator/AdminHome/updaodmycvs")]
        public IActionResult updaodmycvs()
        {
            return View();
        }
        [HttpPost]
        [Route("Administrator/AdminHome/updaodmycvs")]

        public IActionResult updaodmycvs(IFormFile cv)
        {
            _uplodCvFile.upladmycv(cv);
            return Redirect("index");
        }
        [Route("Administrator/AdminHome/aboutme")]
        public IActionResult aboutme()
        {
            var mydes = _context.aboutmeUw.Get().ToList();
            if (mydes.Count() > 0)
            {
                var description = _context.aboutmeUw.Get().OrderByDescending(x => x.Id).Take(1).Single();
                aboutViewmodel e = new()
                {
                    Description = description.Description,
                    ID = description.Id,
                };
                return View(e);
            }

            aboutViewmodel e2 = new();
            return View(e2);
        }
        [HttpPost]
        [Route("Administrator/AdminHome/aboutme")]
        public IActionResult aboutme(aboutViewmodel e)
        {
            aboutme e2 = new()
            {
                Description = e.Description
             };
            _context.aboutmeUw.insert(e2);
            _context.save();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddData()
        {
            return View();
        }


        [HttpPost]
        [Route("Administrator/AdminHome/AddData")]
        public IActionResult AddData([FromBody]List<idoview> e)
        {
            var ido = new List<Ido>();
            foreach (var i in e)
            {
                ido.Add(new Ido(){title = i.title,descrrripton = i.descrrripton,img = i.img});
            }
            _idoRepository.create(ido);

            return RedirectToAction("Index");
        }

    }
}
