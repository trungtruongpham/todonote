using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using todonote.ViewModels;
using todonote.Models;

namespace todonote.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            // if (Url.IsLocalUrl(returnUrl))
            // {
            //     return Redirect(returnUrl);
            // }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    // if (string.IsNullOrEmpty(returnUrl))
                    // {
                    //     return Redirect(returnUrl);
                    // }
                    // else
                    // {
                    //     return RedirectToAction("Index", "note");
                    // }
                    return RedirectToAction("Index", "note");
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt");
            }
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Location = model.Location,
                };

                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "note");
                }

                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, err.Description);
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "note");
        }

        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsEmailUsed(string email)
        {
            var user = await userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Email {email} is already used");
            }
        }
    }
}