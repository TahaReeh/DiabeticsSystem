using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using DiabeticsSystem.Application.Contracts.Infrastructure;
using DiabeticsSystem.Infrastructure.FileExport;

namespace DiabeticsSystem.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ICsvExport, CsvExport>();
            services.AddTransient<IRdlcReport, RdlcReport>();

            return services;
        }
    }
}
