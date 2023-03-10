using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SuefaApp.Interfaces;
using SuefaApp.Models;
using SuefaApp.ViewModels.GameVMs;
using SuefaApp.ViewModels.LoginVMs;
using System;
using System.Threading.Tasks;

namespace SuefaApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public HomeController(IHomeService homeService, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _homeService = homeService;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login");
            }

            await _homeService.CreateEvent();

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            foreach (string err in await _homeService.Login(loginVM))
            {
                ModelState.AddModelError("", err);
                return View();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ResponseVM> Game([FromBody] RequestVM requestVM)
        {
            return await _homeService.Game(requestVM);
        }

        public async Task<IActionResult> CreateEvent()
        {
            await _homeService.CreateEvent();

            return Ok();
        }


















        #region Created Roles

        //public async Task<IActionResult> CreateRole()
        //{
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "Member" });

        //    return Content("Roli yest");
        //}

        #endregion

        #region Created Super Admin

        //public async Task<IActionResult> CreateAdmin()
        //{
        //    AppUser newUser = new AppUser()
        //    {
        //        UserName = "+994505788901",
        //        PhoneNumber = "+994505788901",
        //        PhoneNumberConfirmed = true,
        //        IsAdmin = true,
        //        CreatedAt = DateTime.UtcNow.AddHours(4),
        //        WinTimes = 0,
        //        PlayTimes = 0,
        //        LoginTimes = 0
        //    };

        //    await _userManager.CreateAsync(newUser, "Admin123");

        //    await _userManager.AddToRoleAsync(newUser, "Admin");

        //    return Content("Admin est");
        //}

        #endregion

        #region Created user

        //public async Task<IActionResult> Createuser()
        //{
        //    AppUser newUser = new AppUser()
        //    {
        //        UserName = "+994555555555",
        //        PhoneNumber = "+994555555555",
        //        PhoneNumberConfirmed = true,
        //        IsAdmin = false,
        //        CreatedAt = DateTime.UtcNow.AddHours(4),
        //        WinTimes = 0,
        //        LoginTimes = 0,
        //        PlayTimes = 0
        //    };

        //    IdentityResult result = await _userManager.CreateAsync(newUser);

        //    await _userManager.AddToRoleAsync(newUser, "Member");

        //    return Content("member est");
        //}

        #endregion
    }
}
