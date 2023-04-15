using WriteDownOnlineApi.Domain.Entities;
using WriteDownOnlineApi.Domain.Interface;
using WriteDownOnlineApi.Domain.Interface.Core;
using WriteDownOnlineApi.Infra.Repositories.Core;

namespace WriteDownOnlineApi.Infra.Repositories
{
    public class UsersRepository : Repository<UsersEntity, long>, IUsersRepository
    {
        private readonly IUnitOfWork<DbContext> _unitOfWork;
        public UsersRepository(DbContext context, IUnitOfWork<DbContext> unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
