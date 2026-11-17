using DAANAY.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DAANAY.Controllers;

public class AccountController : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        return View(new LoginViewModel());
    }

    [HttpPost]
    public IActionResult Login(LoginViewModel model)
    {
        // UI only — no authentication
        return View(model);
    }

    [HttpGet]
    public IActionResult Signup()
    {
        return View(new SignupViewModel());
    }

    [HttpPost]
    public IActionResult Signup(SignupViewModel model)
    {
        // UI only — no registration
        return View(model);
    }
}
