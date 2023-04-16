using WriteDownOnlineApi.Domain.Entities.Core;

namespace WriteDownOnlineApi.Domain.Entities
{
    public class StatusEntity : BaseEntity<short>
    {
        public string Description { get; set; }
    }
}
