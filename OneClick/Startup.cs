using Microsoft.EntityFrameworkCore;
using OneClick.Models;

namespace OneClick
{
    public class Startup
    {
        

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
         
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MyDbContext>(options =>
     options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));



        }
    }
}
