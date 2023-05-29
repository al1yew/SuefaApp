using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SuefaApp.Interfaces;
using SuefaApp.Models;
using SuefaApp.ViewModels.GameVMs;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
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

                var time = DateTime.UtcNow.AddHours(4);

                Event userEvent = new Event()
                {
                    AppUser = newUser,
                    CreatedAt = DateTime.UtcNow.AddHours(4)
                };

                await _unitOfWork.EventRepository.AddAsync(userEvent);
                await _unitOfWork.CommitAsync();

                await _signInManager.SignInAsync(newUser, true);
            }

            if (appUser != null)
            {
                var time = DateTime.UtcNow.AddHours(4);

                if (appUser.Events != null && appUser.Events.Count > 0)
                {
                    Event currentEvent = appUser.Events.Last();

                    if (currentEvent.Message != null && currentEvent.Message.Length > 0)
                    {
                        Event userEvent = new Event()
                        {
                            AppUser = appUser,
                            CreatedAt = DateTime.UtcNow.AddHours(4)
                        };

                        await _unitOfWork.EventRepository.AddAsync(userEvent);
                    }
                }
                else
                {
                    Event newEvent = new Event()
                    {
                        AppUser = appUser,
                        CreatedAt = DateTime.UtcNow.AddHours(4)
                    };

                    await _unitOfWork.EventRepository.AddAsync(newEvent);
                }

                appUser.LoginTimes += 1;

                await _unitOfWork.CommitAsync();

                await _signInManager.SignInAsync(appUser, true);
            }

            return errors;
        }

        public async Task<bool> CheckLogin(string phone)
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

            return true;
        }

        public async Task<ResponseVM> Game(RequestVM requestVM)
        {
            #region random

            Random random = new Random();

            int comp = random.Next(1, 4);

            string[] userBeats = { "Partdadırsan!", "Bax Belə!", "Bizi Bankrot Edersen a!", "Ay Sağol!",
                "Saxlama!", "Sükanı belə saxla!", "Möhtəşəm!", "Vışşı!", "Biraz yavaş...", "İnanılmaz!",
                "Qadanalaram e!", "Bu uşaq dağıdır da!", "Yaxinsan!", "Udacağsan!", "Davam Davam Davam!" };
            int userRandom = random.Next(0, userBeats.Length);

            string[] compBeats = { "Olanda olurda...", "Bəxtivi yenə sına...", "Məğlub oldun...",
                "Tələsmə Zaur...", "Tələsən Təndirə Düşər!" };
            int compRandom = random.Next(0, compBeats.Length);

            string[] draw = { "Heç heçə", "Heçnə itirmədin!" };
            int drawRandom = random.Next(0, draw.Length);

            #endregion

            ResponseVM responseVM = new ResponseVM()
            {
                UserScore = requestVM.UserScore,
                CompScore = requestVM.CompScore,
                CompSelected = comp,
                HasWon = 0
            };

            #region game

            if (requestVM.Selected == comp) //draw
            {
                responseVM.Result = 0;
                responseVM.HasWon = 0;
                responseVM.Message = draw[drawRandom];
            }
            else if (requestVM.Selected == 1 && comp == 2) //user rock loses to comp paper
            {
                responseVM.Result = -1;
                responseVM.CompScore += 1;
                responseVM.HasWon = 0;
                responseVM.Message = compBeats[compRandom];
            }
            else if (requestVM.Selected == 1 && comp == 3) //user rock beats comp scissors
            {
                responseVM.Result = 1;
                responseVM.UserScore += 1;
                responseVM.HasWon = 0;
                responseVM.Message = userBeats[userRandom];
            }
            else if (requestVM.Selected == 2 && comp == 1) //user paper beats comp rock
            {
                responseVM.Result = 1;
                responseVM.UserScore += 1;
                responseVM.HasWon = 0;
                responseVM.Message = userBeats[userRandom];
            }
            else if (requestVM.Selected == 2 && comp == 3) //user paper loses to comp scissors
            {
                responseVM.Result = -1;
                responseVM.CompScore += 1;
                responseVM.HasWon = 0;
                responseVM.Message = compBeats[compRandom];
            }
            else if (requestVM.Selected == 3 && comp == 1) //user scissors loses to comp rock
            {
                responseVM.Result = -1;
                responseVM.CompScore += 1;
                responseVM.HasWon = 0;
                responseVM.Message = compBeats[compRandom];
            }
            else if (requestVM.Selected == 3 && comp == 2) //user scissors beats comp paper
            {
                responseVM.Result = 1;
                responseVM.UserScore += 1;
                responseVM.HasWon = 0;
                responseVM.Message = userBeats[userRandom];
            }

            #endregion

            if (responseVM.UserScore == 7 && responseVM.CompScore == 0)
            {
                responseVM.HasWon = 1;
            }

            if (responseVM.UserScore == 10 && responseVM.CompScore == 0)
            {
                responseVM.HasWon = 2;
            }

            AppUser appUser = await _unitOfWork.AppUserRepository.GetAsync(x =>
            x.UserName == _httpContextAccessor.HttpContext.User.Identity.Name, "Events");

            var time = DateTime.UtcNow.AddHours(4);

            if (appUser.Events != null && appUser.Events.Count > 0)
            {
                Event currentEvent = appUser.Events.Last();

                currentEvent.Message += $"{time.ToString("dd/MM/yyyy HH:mm:ss")}: User-{responseVM.UserScore} : {responseVM.CompScore}-Comp_";

                if (responseVM.HasWon == 1 || responseVM.HasWon == 2)
                {
                    currentEvent.HasWon = true;
                    appUser.WinTimes += 1;
                }
                else
                {
                    currentEvent.HasWon = false;
                }
            }
            else
            {
                Event userEvent = new Event()
                {
                    AppUser = appUser,
                    CreatedAt = DateTime.UtcNow.AddHours(4),
                    Message = $"{time.ToString("dd/MM/yyyy HH:mm:ss")}: User-{responseVM.UserScore} : {responseVM.CompScore}-Comp_",
                };

                if (responseVM.HasWon == 1 || responseVM.HasWon == 2)
                {
                    appUser.WinTimes += 1;
                    userEvent.HasWon = true;
                }
                else
                {
                    userEvent.HasWon = false;
                }

                await _unitOfWork.EventRepository.AddAsync(userEvent);
            }

            await _unitOfWork.CommitAsync();

            return responseVM;
        }

        public async Task CreateEvent()
        {
            AppUser appUser = await _unitOfWork.AppUserRepository.GetAsync(x =>
            x.UserName == _httpContextAccessor.HttpContext.User.Identity.Name, "Events");

            List<Event> nullEvents = await _unitOfWork.EventRepository.GetAllByExAsync(x => x.Message == null);
            List<Event> shitEvents = await _unitOfWork.EventRepository.GetAllByExAsync(x => x.Message != null && x.Message.Length < 200);

            foreach (Event eventik in nullEvents)
            {
                _unitOfWork.EventRepository.Remove(eventik);
            }

            foreach (Event eventikik in shitEvents)
            {
                _unitOfWork.EventRepository.Remove(eventikik);
            }

            var time = DateTime.UtcNow.AddHours(4);

            if (appUser.Events != null && appUser.Events.Count > 0)
            {
                Event currentEvent = appUser.Events.Last();

                if (currentEvent.Message != null && currentEvent.Message.Length > 0)
                {
                    Event userEvent = new Event()
                    {
                        AppUser = appUser,
                        CreatedAt = DateTime.UtcNow.AddHours(4)
                    };

                    await _unitOfWork.EventRepository.AddAsync(userEvent);
                }
            }

            appUser.PlayTimes += 1;

            await _unitOfWork.CommitAsync();
        }
    }
}
