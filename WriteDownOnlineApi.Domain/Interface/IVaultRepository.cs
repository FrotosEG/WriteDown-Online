using WriteDownOnlineApi.Domain.Entities;
using WriteDownOnlineApi.Domain.Interface.Core;

namespace WriteDownOnlineApi.Domain.Interface
{
    public interface IVaultRepositpory : IRepository<VaultEntity, long>
    {
    }
}
