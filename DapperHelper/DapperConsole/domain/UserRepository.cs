using System;
using DapperLib;
using Microsoft.Extensions.Logging;

namespace DapperConsole.domain
{
    public interface IUserRepository : IRepository
    {
        bool ChangeModel();
    }

    public class UserRepository : BaseRepository,IUserRepository
    {
        public UserRepository(/*ILogger<BaseRepository> logger, */IUnitOfWork unitOfWork) : base(/*logger,*/ unitOfWork)
        {
        }

        public bool ChangeModel()
        {
            var insertSql = "INSERT INTO dong.[User] Values(@id,@userName)";
            var updateSql = "update dong.[User] set userName = @userName where id = @id";

            var model = new User
            {
                Id = Guid.NewGuid(),
                UserName = "dong"
            };
            var upModel = new User
            {
                Id = Guid.Parse("D25CF72E-DF02-455A-9503-D668A58B7E73"),
                UserName = "哈哈哈哈，试一下，错误，这么多字"
            };
            try
            {
                UnitOfWork.Begin();
                var res = Insert(insertSql, model);
                var upRes = Update(updateSql, upModel);
                UnitOfWork.Commit();
                return upRes > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                UnitOfWork.Rollback();
                return false;
            }
        }
    }
}