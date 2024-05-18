using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Woof.DataAccess
{
    public static class DataAccessModuleExtension
    {
        public static void AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WoofDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("Woof"));
            });
        }
    }
}
