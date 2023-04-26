using WriteDownOnlineApi.Domain.Entities;
using WriteDownOnlineApi.Service.Responses.Core;

namespace WriteDownOnlineApi.Service.Responses.Vault
{
    public class FindVaultReponse : BaseResponse
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public short IdStatus { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
        public long StatusChangedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime StatusUpdateDate { get; set; }

        public FindVaultReponse() { }

        public FindVaultReponse(VaultEntity vault) 
        {
            Title = vault.Title;
            Description = vault.Description;
            IdStatus = vault.IdStatus;
            CreatedBy = vault.CreatedBy;
            UpdatedBy = vault.UpdatedBy;
            StatusChangedBy = vault.StatusChangedBy;
            CreateDate = vault.CreateDate;
            UpdateDate = vault.UpdateDate;
            StatusUpdateDate = vault.StatusUpdateDate;
        }
    }
}
