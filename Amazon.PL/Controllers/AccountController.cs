using Amazon.BL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Amazon.PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            var Auth = _signInManager.IsSignedIn(User);
            if (Auth == true)
            {
                var AuthUser = _userManager.FindByEmailAsync(User.Identity.Name);
                return RedirectToAction("Index", new RouteValueDictionary(new { controller = "Home", action = "Index" }));

            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM user)
        {
            if (ModelState.IsValid)
            {
                var User = new IdentityUser()
                {
                    Email = user.Email,
                    UserName = user.Email
                };

                var newUser = await _userManager.CreateAsync(User, user.Password);
                if (newUser.Succeeded)
                {
                    var redirectToLogin = await _signInManager.PasswordSignInAsync(user.Email, user.Password, true, false);
                    if (redirectToLogin.Succeeded)
                        return RedirectToAction("index", "Home");
                }
                else
                {
                    foreach (var item in newUser.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
                return RedirectToAction("Register", new RouteValueDictionary(new { controller = "Account", action = "Register" }));

            }
            else
            {
                return RedirectToAction("Register", new RouteValueDictionary(new { controller = "Account", action = "Register" }));

            }
        }


        [HttpGet]
        public IActionResult Login()
        {
            var Auth = _signInManager.IsSignedIn(User);
            if (Auth == true)
            {
                var AuthUser = _userManager.FindByEmailAsync(User.Identity.Name);
                return RedirectToAction("Index", new RouteValueDictionary(new { controller = "Home", action = "Index"}));

            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginVM user)
        {
            if (ModelState.IsValid)
            {
                var checkIfUserFounded = await _userManager.FindByEmailAsync(user.Email);
                if(checkIfUserFounded == null)
                {
                    TempData["ErrorMessage"] = "Invalid Email or Password";
                    return RedirectToAction("Login", new RouteValueDictionary(new { controller = "Account", action = "Login" }));

                }
                var checkUserPassword = await _signInManager.PasswordSignInAsync(checkIfUserFounded, user.Password, true, false);
                if (checkUserPassword.Succeeded)
                {
                    return RedirectToAction("Index", new RouteValueDictionary(new { controller = "Home", action = "Index" }));
                }
                else
                {
                    ModelState.AddModelError("", "Invalid UserName or Password");
                }
                return RedirectToAction("Index", new RouteValueDictionary(new { controller = "Home", action = "Index" }));
            }
            else
            {
                TempData["ErrorMessage"] = "Invalid Email or Password";
                return RedirectToAction("Login", new RouteValueDictionary(new { controller = "Account", action = "Login" }));

            }
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

    }
}
