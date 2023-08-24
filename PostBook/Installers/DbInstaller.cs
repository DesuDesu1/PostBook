using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PostBook.Data;
using PostBook.Services;

namespace PostBook.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<DataContext>();
            services.AddScoped<IPostService, PostService>();
        }
    }
}
