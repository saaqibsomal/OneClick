using OneClick.Infrastructure.Interface;
using OneClick.Infrastructure.Repository;
using OneClick.Service.Interface;
using Microsoft.Extensions.DependencyInjection;
using OneClick.Service;

namespace OneClick.Utility.Extensions
{
    public  static class ServiceCollectionExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<INewsletterEmailRepository, NewsletterEmailRepository>();
            services.AddScoped<INewsletterEmailService, NewsletterEmailService>();
        }
    }
}
