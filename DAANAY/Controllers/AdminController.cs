using DAANAY.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DAANAY.Controllers;

// Only users in the Admin role can open these pages.
[Authorize(Roles = AppRoles.Admin)]
public class AdminController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;

    public AdminController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    // GET: /Admin/Dashboard
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
}
