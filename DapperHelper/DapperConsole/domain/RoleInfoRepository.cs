using DapperLib;

namespace DapperConsole.domain
{
    public interface IRoleInfoRepository : IRepository<RoleInfo>
    {

    }

    public class RoleInfoRepository : BaseRepository<RoleInfo>,IRoleInfoRepository
    {
        public RoleInfoRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}