using Microsoft.Extensions.DependencyInjection;

namespace DapperLib
{
    public static class DapperSetup
    {
        public static IServiceCollection AddDapperSetup(this IServiceCollection service, string connectionString)
        {
            var config = new DatabaseConfig
            {
                ConnectString = connectionString
            };

            service.AddSingleton(config);

            service.AddScoped<IUnitOfWork, UnitOfWork>();
            service.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            return service;
        }
    }
}