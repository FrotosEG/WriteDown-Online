using WriteDownOnlineApi.Util.Models;

namespace WriteDownOnlineApi.Util.Interfaces.Inputs
{
    public interface IOrderable
    {
        IEnumerable<OrdenationAttribute> Ordenations { get; set; }
    }
}
