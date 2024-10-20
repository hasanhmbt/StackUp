using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StackUp.Domain.Entities.IdentityEntites;

namespace StackUp.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AccountController : Controller
    {
        #region Dependencies

        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        #endregion


        public IActionResult Index()
        {
            return View();
        }


    }
}
