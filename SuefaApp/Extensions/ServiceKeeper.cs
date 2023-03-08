
using Microsoft.Extensions.DependencyInjection;


namespace SuefaApp.Extensions
{
    public static class ServiceKeeper
    {
        public static void ServicesBuilder(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}