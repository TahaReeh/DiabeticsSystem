using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DiabeticsSystem.Application.Contracts.Persistence;
using DiabeticsSystem.Persistence.Repositories;
using DiabeticsSystem.Persistence.DbInitializers;

namespace DiabeticsSystem.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString
            ("DefaultConnection")));

            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(IDbInitializer), typeof(DbInitializer));

            return services;
        }
    }
}
