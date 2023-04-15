namespace WriteDownOnlineApi.Domain.Entities.Core
{
    public abstract class BaseEntity<TPK>
    {
        public TPK? Id { get; set; }
    }
}
