
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ORION.Admin.Models.Account;
using ORION.DataAccess.Models;

namespace ORION.Admin.Controllers
{
    // [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<MasterUser> _userManager;
        private readonly SignInManager<MasterUser> _singInManager;
        private IPasswordHasher<MasterUser> _passwordHasher;

        public AccountController(UserManager<MasterUser> userManager,
                                 SignInManager<MasterUser> signInManager,
                                 IPasswordHasher<MasterUser> passwordHasher)
        {
            _userManager = userManager;
            _singInManager = signInManager;
            _passwordHasher = passwordHasher;
        }

        [AllowAnonymous]
        public IActionResult Register() => View();

        [HttpPost, ValidateAntiForgeryToken, AllowAnonymous]
        public async Task<IActionResult> Register(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                MasterUser appUser = new MasterUser { UserName = user.UserName, Email = user.Email };

                IdentityResult result = await _userManager.CreateAsync(appUser, user.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View(user);
        }

        [AllowAnonymous]
        public IActionResult LogIn(string returnUrl)
        {
            LoginViewModel login = new LoginViewModel { ReturnUrl = returnUrl };

            return View(login);
        }

        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                var appUser = await _userManager.FindByNameAsync(login.UserName);

                if (appUser != null)
                {
                    Microsoft.AspNetCore.Identity.SignInResult signInResult = await _singInManager.PasswordSignInAsync(appUser.UserName, login.Password, false, false);

                    if (signInResult.Succeeded)
                    {
                        //return Redirect("login.ReturnUrl" ?? "/");
                        return Redirect("login.ReturnUrl" ?? "/Home");
                    }

                    ModelState.AddModelError("", "The login failed because of wrong credential information..!");
                }
            }
            return View(login);
        }

        public async Task<IActionResult> LogOut()
        {
            await _singInManager.SignOutAsync();

            return RedirectToAction("LogIn");
        }

        public async Task<IActionResult> Edit()
        {
            MasterUser appUser = await _userManager.FindByNameAsync(User.Identity.Name);

            MasterUserEditViewModel userEdit = new MasterUserEditViewModel(appUser);

            return View(userEdit);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserEdit userEdit)
        {
            if (ModelState.IsValid)
            {
                MasterUser appUser = await _userManager.FindByNameAsync(User.Identity.Name);

                appUser.UserName = userEdit.UserName;
                if (userEdit.Password != null)
                {
                    appUser.PasswordHash = _passwordHasher.HashPassword(appUser, userEdit.Password);
                }

                IdentityResult ıdentityResult = await _userManager.UpdateAsync(appUser);
                if (ıdentityResult.Succeeded)
                {
                    TempData["Success"] = "Your information has been edited..!";
                }
                else
                {
                    TempData["Warning"] = "Your information has been wrong..!";
                }
            }

            return View(userEdit);


        }
    }
}
