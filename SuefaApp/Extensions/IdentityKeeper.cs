using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SuefaApp.DAL;
using SuefaApp.Models;

namespace SuefaApp.Extensions
{
    public static class IdentityKeeper
    {
        public static void IdentityBuilder(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 0;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;

                options.Lockout.AllowedForNewUsers = false;
            }).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();
        }
    }
}
