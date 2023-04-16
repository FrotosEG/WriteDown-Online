using WriteDownOnlineApi.Service.Responses.Core;

namespace WriteDownOnlineApi.Service.Responses.User
{
    public class FindUserResponse : BaseResponse
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Fone { get; set; }
        public short IdStatus { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? StatusUpdateDate { get; set; }
    }
}
