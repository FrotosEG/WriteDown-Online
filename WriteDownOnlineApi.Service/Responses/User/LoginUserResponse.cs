using WriteDownOnlineApi.Service.Responses.Core;

namespace WriteDownOnlineApi.Service.Responses.User
{
    public class LoginUserResponse : BaseResponse
    {
        public long UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Fone { get; set; }
    }
}
