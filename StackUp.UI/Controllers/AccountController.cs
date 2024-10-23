using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StackUp.Domain.Entities.IdentityEntites;
using StackUp.UI.Models.IdentityModels;

namespace StackUp.UI.Controllers;

[Authorize(Roles = "Admin")]
public class AccountController : Controller
{

    #region Dependencies

    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AccountController(
        UserManager<AppUser> userManager,
        RoleManager<IdentityRole> roleManager
        )
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }
    #endregion

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var users = await _userManager.Users.ToListAsync();

        var userRoles = new Dictionary<string, IList<string>>();
        foreach (var user in users)
        {
            userRoles[user.Id] = await _userManager.GetRolesAsync(user);
        }

        ViewBag.UserRoles = userRoles;

        return View(users);
    }

    [HttpGet]
    public async Task<IActionResult> EditUser(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
            return RedirectToAction("Index");

        var userRoles = await _userManager.GetRolesAsync(user);

        var allRoles = await _roleManager.Roles.ToListAsync();

        var model = new EditUserViewModel
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            UserName = user.UserName,
            Roles = allRoles.Select(role => new RoleViewModel
            {
                RoleId = role.Id,
                RoleName = role.Name,
                IsSelected = userRoles.Contains(role.Name)
            }).ToList()
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> EditUser(EditUserViewModel model)
    {
        if (!ModelState.IsValid)
        {
            var allRoles = await _roleManager.Roles.ToListAsync();
            model.Roles = allRoles.Select(role => new RoleViewModel
            {
                RoleId = role.Id,
                RoleName = role.Name,
                IsSelected = model.Roles?.Any(r => r.RoleId == role.Id && r.IsSelected) ?? false
            }).ToList();

        }

        var user = await _userManager.FindByIdAsync(model.Id);
        if (user == null)
            return RedirectToAction("Index");

        user.FirstName = model.FirstName;
        user.LastName = model.LastName;
        user.Email = model.Email;
        user.UserName = model.UserName;

        var result = await _userManager.UpdateAsync(user);
        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            var allRoles = await _roleManager.Roles.ToListAsync();
            model.Roles = allRoles.Select(role => new RoleViewModel
            {
                RoleId = role.Id,
                RoleName = role.Name,
                IsSelected = model.Roles?.Any(r => r.RoleId == role.Id && r.IsSelected) ?? false
            }).ToList();

        }

        var userRoles = await _userManager.GetRolesAsync(user);
        var selectedRoles = model.Roles.Where(r => r.IsSelected).Select(r => r.RoleName).ToList();

        var rolesToAdd = selectedRoles.Except(userRoles);
        var rolesToRemove = userRoles.Except(selectedRoles);

        await _userManager.AddToRolesAsync(user, rolesToAdd);
        await _userManager.RemoveFromRolesAsync(user, rolesToRemove);

        return RedirectToAction("Index");
    }



    [HttpPost]
    public async Task<IActionResult> DeleteUser(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
            return RedirectToAction("Index");

        var result = await _userManager.DeleteAsync(user);
        if (result.Succeeded)
            return RedirectToAction("Index");

        return RedirectToAction("Index");
    }


    [HttpGet]
    public async Task<IActionResult> UserRoles()
    {
        var roles = await _roleManager.Roles.ToListAsync();
        return View(roles);
    }



    [HttpGet]
    public IActionResult AddRole()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddRole(IdentityRole model)
    {
        if (string.IsNullOrWhiteSpace(model.Name))
            return View(model);

        await _roleManager.CreateAsync(new IdentityRole(model.Name));
        return RedirectToAction("UserRoles");
    }



    [HttpGet]
    public async Task<IActionResult> EditRole(string id)
    {
        var role = await _roleManager.FindByIdAsync(id);
        if (role == null)
        {
            return RedirectToAction("UserRoles");
        }

        var model = new IdentityRole
        {
            Id = role.Id,
            Name = role.Name
        };

        return View(model);
    }
    [HttpPost]
    public async Task<IActionResult> EditRole(IdentityRole model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var role = await _roleManager.FindByIdAsync(model.Id);
        if (role == null)
        {
            return RedirectToAction("UserRoles");
        }

        role.Name = model.Name;
        var result = await _roleManager.UpdateAsync(role);

        if (result.Succeeded)
        {
            return RedirectToAction("UserRoles");
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError("", error.Description);
        }

        return View(model);
    }



    [HttpPost]
    public async Task<IActionResult> DeleteRole(IdentityRole model)
    {
        var role = await _roleManager.FindByIdAsync(model.Id);
        if (role != null)
        {
            await _roleManager.DeleteAsync(role);
        }
        return RedirectToAction("UserRoles");
    }
}
