using System;
using DapperConsole.domain;
using DapperLib;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DapperConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Server=.;Database=LearnEF;User ID=sa;Password=123456;";
            IServiceCollection service = new ServiceCollection();
            service.AddDapperSetup(connectionString);
            service.AddScoped<IUserRepository, UserRepository>();
            var provider = service.BuildServiceProvider();
            var userService = provider.GetService<IUserRepository>();
            var b = userService.ChangeModel();
            Console.WriteLine("Hello World!");
        }
    }
}
