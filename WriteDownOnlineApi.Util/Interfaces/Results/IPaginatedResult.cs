using System.Collections;
using WriteDownOnlineApi.Util.Interfaces.Inputs;

namespace WriteDownOnlineApi.Util.Interfaces.Results
{
    public interface IPaginatedResult : IOperationResult<IList>
    {
        int? TotalCount { get; set; }
        int? Pages { get; set; }
        int Count { get; set; }
        int Page { get; set; }

        void Paginate<TSource, TResult>(IPagination pagination, IQueryable<TSource> source, Func<TSource, TResult> selectFunction);
        new IPaginatedResult AddMessage(string message);
    }
}
