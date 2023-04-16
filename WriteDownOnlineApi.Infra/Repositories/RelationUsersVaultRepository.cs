using WriteDownOnlineApi.Domain.Entities;
using WriteDownOnlineApi.Domain.Interface;
using WriteDownOnlineApi.Domain.Interface.Core;
using WriteDownOnlineApi.Infra.Repositories.Core;

namespace WriteDownOnlineApi.Infra.Repositories
{
    public class RelationUsersVaultRepository : Repository<RelationUsersVaultEntity, long>, IRelationUsersVaultRepository
    {
        private readonly IUnitOfWork<DbContext> _unitOfWork;
        public RelationUsersVaultRepository(DbContext context, IUnitOfWork<DbContext> unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
