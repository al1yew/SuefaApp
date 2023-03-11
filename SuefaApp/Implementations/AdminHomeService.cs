using AutoMapper;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SuefaApp.Interfaces;
using SuefaApp.Models;
using SuefaApp.ViewModels.AdminAccountVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SuefaApp.Implementations
{
    public class AdminHomeService : IAdminHomeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminHomeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AdminHomeVM> GetData()
        {
            List<AppUser> appUsers = await _unitOfWork.AppUserRepository.GetAllAsync();

            int newUsersCount = appUsers.Where(x => (DateTime.Now - x.CreatedAt.Value).TotalDays <= 1).Count();

            List<Event> events = await _unitOfWork.EventRepository.GetAllAsync();

            List<Event> wins = events.Where(x => x.HasWon).ToList();

            int allWins = wins.Count();

            int todayWins = wins.Where(x => (DateTime.Now - x.CreatedAt.Value).TotalDays <= 1).Count();

            int todayGamesCount = events.Where(x => (DateTime.Now - x.CreatedAt.Value).TotalDays <= 1).Count();

            AdminHomeVM adminHomeVM = new AdminHomeVM()
            {
                UserCount = appUsers.Count,
                TodayUsersCount = newUsersCount,
                AllWins = allWins,
                TodayPlayedGames = todayGamesCount,
                TodayWins = todayWins
            };

            return adminHomeVM;
        }
    }
}
