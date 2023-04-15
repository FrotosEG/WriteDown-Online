using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteDownOnlineApi.Service.Responses.Core
{
    public class BaseResponse
    {
        public string MensagemSucesso { get; set; }
        public int StatusCode { get; set; }
        public bool Sucesso { get; set; }
    }
}
