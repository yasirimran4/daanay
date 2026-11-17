using DAANAY.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DAANAY.Controllers;

public class CustomerController : Controller
{
    [HttpGet]
    public IActionResult Dashboard()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Profile()
    {
        return View(new ProfileViewModel());
    }

    [HttpPost]
    public IActionResult Profile(ProfileViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        TempData["SuccessMessage"] = "Profile saved (UI only — not stored in a database yet).";
        return View(model);
    }
}
