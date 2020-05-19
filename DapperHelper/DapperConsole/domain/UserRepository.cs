using System;
using DapperLib;
using Microsoft.Extensions.Logging;

namespace DapperConsole.domain
{
    public interface IUserRepository : IRepository<User>
    {
        bool ChangeModel();
    }

    public class UserRepository : BaseRepository<User>,IUserRepository
    {
        public UserRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public bool ChangeModel()
        {
            var insertSql = "INSERT INTO UserInfo Values(@id,@userName)";
            var updateSql = "update UserInfo set userName = @userName where UserId = @id";

            var model = new User
            {
                UserId = Guid.NewGuid(),
                UserName = "dong"
            };
            var upModel = new User
            {
                UserId = Guid.Parse("D25CF72E-DF02-455A-9503-D668A58B7E73"),
                UserName = "哈哈哈哈，试一下，错误，这么多字"
            };
            try
            {
                UnitOfWork.Begin();
                var res = Execute(insertSql, model);
                var upRes = Execute(updateSql, upModel);
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