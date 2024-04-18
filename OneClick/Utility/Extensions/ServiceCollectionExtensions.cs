using OneClick.Infrastructure.Interface;
using OneClick.Infrastructure.Repository;
using OneClick.Service.Interface;
using Microsoft.Extensions.DependencyInjection;
using OneClick.Service;
using OneClick.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;

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
            services.AddScoped<ICMSService, CMSService>();
            services.AddScoped<ICMSRepository, CMSRepository>();
        }

        public static void AddDBServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OneClickContext>(options =>
           options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        public static void AddCustomCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin", builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }
    }
}
