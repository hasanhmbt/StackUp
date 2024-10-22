using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StackUp.Domain.Entities.IdentityEntites;
using StackUp.UI.Models.IdentityModels;

public class SettingsController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public SettingsController(UserManager<AppUser> userManager, IWebHostEnvironment webHostEnvironment)
    {
        _userManager = userManager;
        _webHostEnvironment = webHostEnvironment;
    }

    [HttpGet]
    public async Task<IActionResult> EditProfile()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
            return RedirectToAction("Index", "Home");

        var model = new EditProfileViewModel
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            UserName = user.UserName,
            PhoneNumber = user.PhoneNumber,
            ImageUrl = user.ImageUrl
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditProfile(EditProfileViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var user = await _userManager.GetUserAsync(User);
        if (user == null)
            return RedirectToAction("Index", "Home");

        user.FirstName = model.FirstName;
        user.LastName = model.LastName;
        user.Email = model.Email;
        user.UserName = model.UserName;
        user.PhoneNumber = model.PhoneNumber;

        if (model.ImageFile != null && model.ImageFile.Length > 0)
        {
            var uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(model.ImageFile.FileName);
            var uploads = Path.Combine(_webHostEnvironment.WebRootPath, "images/profiles");

            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }

            var filePath = Path.Combine(uploads, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await model.ImageFile.CopyToAsync(fileStream);
            }

            DeleteOldImage(user.ImageUrl);

            user.ImageUrl = "/images/profiles/" + uniqueFileName;
        }

        var result = await _userManager.UpdateAsync(user);
        if (result.Succeeded)
        {
            TempData["SuccessMessage"] = "Profile updated successfully.";
            return RedirectToAction("EditProfile");
        }

        foreach (var error in result.Errors)
            ModelState.AddModelError("", error.Description);

        return View(model);
    }



    public IActionResult TwoFactorAuthentication()
    {
        return View();
    }


    public IActionResult PreferenceSettings()
    {
        return View();
    }



















    private void DeleteOldImage(string imageUrl)
    {
        if (!string.IsNullOrEmpty(imageUrl))
        {
            var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, imageUrl.TrimStart('/'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
        }
    }
}
