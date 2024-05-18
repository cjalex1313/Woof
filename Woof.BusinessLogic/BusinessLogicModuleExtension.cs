using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Woof.BusinessLogic.Clinic;
using Woof.DataAccess;

namespace Woof.BusinessLogic
{
    public static class BusinessLogicModuleExtension
    {
        public static void AddBusinessLogic(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataAccess(configuration);
            services.AddScoped<IClinicService, ClinicService>();
        }
    }
}
