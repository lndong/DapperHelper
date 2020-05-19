using System;
using System.Collections.Generic;
using System.Linq;
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
            service.AddScoped<IRoleInfoRepository, RoleInfoRepository>();
            var provider = service.BuildServiceProvider();
           
            // InsertUser(provider);
            UpdateRole(provider);

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }

        private static void InsertUser(ServiceProvider provider)
        {
            var userService = provider.GetService<IUserRepository>();
            var list = new List<User>
            {
                new User
                {
                    UserId = Guid.NewGuid(),
                    UserName = "angel18"
                },
                new User
                {
                    UserId = Guid.NewGuid(),
                    UserName = "angel19"
                },
                new User
                {
                    UserId = Guid.NewGuid(),
                    UserName = "angel20"
                }
            };

            Console.WriteLine(userService.Insert(list));
        }

        private static void UpdateRole(ServiceProvider provider)
        {
            var roleService = provider.GetService<IRoleInfoRepository>();
            var list = new List<RoleInfo>
            {
                new RoleInfo
                {
                    Id = 2,
                    Name = "管理者"
                },
                new RoleInfo
                {
                    Id = 3,
                    Name = "小组长",
                    Role = "leader"
                }
            };
            Console.WriteLine(roleService.Update(list));
        }
    }
}
