using Microsoft.Extensions.DependencyInjection;
using PruebaTecnicaInfrastucture.Repository;
using PruebaTecnicaModel.Interfaces;

namespace PruebaTecnicaInfrastucture.Extension
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection Repository)
        {
            return Repository.AddScoped<IStudentRepository, StudentRepository>();
        }
    }
}
