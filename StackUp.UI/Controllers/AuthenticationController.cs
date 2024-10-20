using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StackUp.Domain.Entities.IdentityEntites;
using StackUp.UI.Models.IdentityModels;

namespace StackUp.UI.Controllers
{
    [AllowAnonymous]
    public class AuthenticationController : Controller
    {
        #region ctor

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly EmailService _emailService;
        public AuthenticationController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, EmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailService = emailService;
        }
        #endregion

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);

            if (result.Succeeded)
                return RedirectToAction("Index", "Home");

            ModelState.AddModelError("", "Invalid login attempt.");
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = new AppUser
            {
                UserName = model.UserName,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Login", "Authentication");
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return View(model);
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.FindByEmailAsync(model.Email);

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var callbackUrl = Url.Action("ResetPassword", "Authentication",
                                        new { token, email = user.Email }, protocol: Request.Scheme);

            var subject = "Reset your password";
            var body = $"<p>Please reset your password by <a href='{callbackUrl}'>clicking here</a>.</p>";

            try
            {
                await _emailService.SendEmailAsync(model.Email, subject, body);
                return RedirectToAction("ForgotPasswordConfirmation");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "There was an error sending the email. Please try again later.");
                return View(model);
            }
        }


        public IActionResult ForgotPasswordConfirmation()
        {
            return View();

        }

        [HttpGet]
        public IActionResult ResetPassword(string token, string email)
        {
            if (token == null || email == null)
            {
                ModelState.AddModelError("", "Invalid password reset token.");
                return RedirectToAction("Login", "Authentication");
            }

            var model = new ResetPasswordViewModel { Token = token, Email = email };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);

            var resetPassResult = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
            if (resetPassResult.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation");
            }

            foreach (var error in resetPassResult.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }




        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Authentication");
        }

        [Route("Authentication/AccessDenied")]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
