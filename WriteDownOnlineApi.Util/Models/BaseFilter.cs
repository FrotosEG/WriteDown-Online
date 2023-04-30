using WriteDownOnlineApi.Util.Interfaces.Inputs;

namespace WriteDownOnlineApi.Util.Models
{
    public class BaseFilter : IPagination, IOrderable
    {
        public int ItemsPerPage { get; set; } = 30;
        public int Page { get; set; }
        public bool CountTotal { get; set; }
        public IEnumerable<OrdenationAttribute> Ordenations { get; set; }
    }
}
