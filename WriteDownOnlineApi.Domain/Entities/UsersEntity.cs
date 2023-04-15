using WriteDownOnlineApi.Domain.Entities.Core;

namespace WriteDownOnlineApi.Domain.Entities
{
    public class UsersEntity : BaseEntity<long>
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public string Fone { get; set; }

        public string Password { get; set; }
        public short IdStatus { get; set; }
        public virtual EnumStatus Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime StatusUpdateDate { get; set; }

        

    }
}
