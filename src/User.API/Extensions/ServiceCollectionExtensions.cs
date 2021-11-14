using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using User.BusinessLogic.Services.Users;

namespace User.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterTypes(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUserService, UserService>();
        }
    }
}