using Microsoft.AspNetCore.Mvc;
using SuefaApp.Interfaces;
using SuefaApp.ViewModels.AdminAccountVMs;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SuefaApp.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class AccountController : Controller
    {
        private readonly IAdminAccountService _adminAccountService;

        public AccountController(IAdminAccountService adminAccountService)
        {
            _adminAccountService = adminAccountService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AdminLoginVM adminLoginVM)
        {
            if (!ModelState.IsValid) return View(adminLoginVM);

            List<string> errors = await _adminAccountService.Login(adminLoginVM);

            if (errors != null)
            {
                foreach (string error in errors)
                {
                    ModelState.AddModelError("", error);
                }

                return View(adminLoginVM);
            }

            return RedirectToAction("Index", "Home", new { area = "Manage" });
        }

        public async Task<IActionResult> Logout()
        {
            await _adminAccountService.Logout();

            return RedirectToAction("Login");
        }
    }
}
