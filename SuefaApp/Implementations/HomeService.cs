using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SuefaApp.Interfaces;
using SuefaApp.Models;
using SuefaApp.ViewModels.LoginVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SuefaApp.Implementations
{
    public class HomeService : IHomeService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public HomeService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<List<string>> Login(LoginVM loginVM)
        {
            List<string> errors = new List<string>();

            if (!await CheckLogin(loginVM.Login))
            {
                errors.Add("Nömrənizi düzgün qeyd edin!");

                return errors;
            }

            AppUser appUser = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == "+994" + loginVM.Login);

            if (appUser == null)
            {
                AppUser newUser = new AppUser()
                {
                    UserName = "+994" + loginVM.Login,
                    PhoneNumber = "+994" + loginVM.Login,
                    PhoneNumberConfirmed = true,
                    IsAdmin = false,
                    CreatedAt = DateTime.UtcNow.AddHours(4),
                    WinTimes = 0,
                    PlayTimes = 0,
                    LoginTimes = 1,
                };

                IdentityResult result = await _userManager.CreateAsync(newUser);

                if (!result.Succeeded)
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        errors.Add(error.Description);
                    }

                    return errors;
                }

                result = await _userManager.AddToRoleAsync(newUser, "Member");

                await _signInManager.SignInAsync(newUser, true);
            }

            if (appUser != null)
            {
                appUser.LoginTimes += 1;
                await _userManager.UpdateAsync(appUser);

                await _signInManager.SignInAsync(appUser, true);
            }

            return errors;
        }

        public async Task<bool> CheckLogin(string phone)
        {
            Regex regexNumber = new Regex("^[0-9]+$");

            if (regexNumber.IsMatch(phone.ToString()))
            {
                if (!(phone.StartsWith("50") ||
                    phone.StartsWith("10") ||
                    phone.StartsWith("51") ||
                    phone.StartsWith("70") ||
                    phone.StartsWith("77") ||
                    phone.StartsWith("99") ||
                    phone.StartsWith("55")))
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}
