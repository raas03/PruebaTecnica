using Microsoft.Extensions.DependencyInjection;
using PruebaTecnicaService.InterfaceService;
using PruebaTecnicaService.Service;

namespace PruebaTecnicaService.Extension
{
    public static class ServiceExtrension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services.AddScoped<IStudentServices, StudentServices>();
        }
    }
}
