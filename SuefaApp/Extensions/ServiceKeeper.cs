
using Microsoft.Extensions.DependencyInjection;
using SuefaApp.Implementations;
using SuefaApp.Interfaces;

namespace SuefaApp.Extensions
{
    public static class ServiceKeeper
    {
        public static void ServicesBuilder(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<IAdminAccountService, AdminAccountService>();
            services.AddScoped<IAdminEventService, AdminEventService>();
            services.AddScoped<IAdminHomeService, AdminHomeService>();
            services.AddScoped<IAdminUserService, AdminUserService>();
        }
    }
}