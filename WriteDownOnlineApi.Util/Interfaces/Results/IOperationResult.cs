using WriteDownOnlineApi.Util.Enum;

namespace WriteDownOnlineApi.Util.Interfaces.Results
{
    public interface IOperationResultBase
    {
        List<string> Messages { get; set; }
        EnumTypeResult ResultType { get; set; }
        Exception Exception { get; set; }

        bool IsSuccessTypeResult { get; }

        IOperationResultBase AddMessage(string message);
        IOperationResultBase AddMessage(IEnumerable<string> messages);
    }

    public interface IOperationResult<T> : IOperationResultBase
    {
        T Data { get; set; }

        new IOperationResult<T> AddMessage(string message);
        new IOperationResult<T> AddMessage(IEnumerable<string> messages);
    }
}
