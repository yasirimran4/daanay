using DAANAY.Models;
using DAANAY.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DAANAY.Controllers;

[Authorize(Roles = AppRoles.Customer)]
public class CustomerController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;

    public CustomerController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    // GET: /Customer/Dashboard
    public async Task<IActionResult> Dashboard()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return RedirectToAction("Login", "Account");
        }

        ViewBag.FullName = user.FullName;
        ViewBag.Email = user.Email;
        return View();
    }

    // GET: /Customer/Profile
    public async Task<IActionResult> Profile()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return RedirectToAction("Login", "Account");
        }

        var model = new ProfileViewModel
        {
            FullName = user.FullName,
            Email = user.Email ?? string.Empty,
            PhoneNumber = user.PhoneNumber,
            Address = user.Address
        };

        return View(model);
    }

    // POST: /Customer/Profile
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Profile(ProfileViewModel model)
    {
        // Email is display-only; keep it on the form after validation errors
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return RedirectToAction("Login", "Account");
        }

        model.Email = user.Email ?? string.Empty;

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        user.FullName = model.FullName;
        user.PhoneNumber = model.PhoneNumber;
        user.Address = model.Address;

        var result = await _userManager.UpdateAsync(user);
        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }

        TempData["SuccessMessage"] = "Your profile was updated successfully.";
        return RedirectToAction(nameof(Profile));
    }
}
