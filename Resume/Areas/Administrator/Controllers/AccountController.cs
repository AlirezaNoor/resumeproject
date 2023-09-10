using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RES.ApplicationContract.Account;
using RES.Domin.Identity;

namespace Resume.Areas.Administrator.Controllers
{
    [Area("Administrator")]

    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signManager;

        public AccountController(SignInManager<ApplicationUser> signManager)
        {
            _signManager = signManager;
        }
        [HttpGet]
        [Route("Administrator/Account/index")]
        public IActionResult Index()
        {
           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signManager.PasswordSignInAsync(model.Username,
                    model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                  
                        return RedirectToAction("Index", "AdminHome");
                   
                }
            }
            ModelState.AddModelError("", "Invalid login attempt");
            return View(model);
        }
        [HttpPost]
        [Route("Administrator/Account/Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signManager.SignOutAsync();
            return RedirectToAction("Index", "AdminHome");
        }
    }
}
