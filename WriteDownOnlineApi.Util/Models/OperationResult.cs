using WriteDownOnlineApi.Util.Enum;
using WriteDownOnlineApi.Util.Interfaces.Results;

namespace WriteDownOnlineApi.Util.Models
{
    public class OperationResult<T> : OperationResultBase, IOperationResult<T>
    {
        #region Propriedades
        public T Data { get; set; }
        #endregion

        #region Contrutores
        protected OperationResult(EnumTypeResult typeResult) : base(typeResult) { }
        protected OperationResult(IOperationResultBase otherResult) : base(otherResult) { }
        protected OperationResult(EnumTypeResult typeResult, Exception exception) : base(typeResult, exception) { }
        protected OperationResult(EnumTypeResult typeResult, T data) : base(typeResult)
        {
            Data = data;
        }
        #endregion

        #region Criadores Genéricos
        public static new IOperationResult<T> Create(IOperationResultBase otherResult)
        {
            return new OperationResult<T>(otherResult);
        }

        public static new IOperationResult<T> Create(EnumTypeResult typeResult)
        {
            return new OperationResult<T>(typeResult);
        }

        public static IOperationResult<T> Create(EnumTypeResult typeResult, T data)
        {
            return new OperationResult<T>(typeResult, data);
        }
        #endregion

        #region Criadores Específicos
        public static IOperationResult<T> CreateSuccess(T data)
        {
            return new OperationResult<T>(EnumTypeResult.Ok, data);
        }

        public static new IOperationResult<T> CreateInvalidInput()
        {
            return new OperationResult<T>(EnumTypeResult.InvalidInput);
        }

        public static new IOperationResult<T> CreateInternalError()
        {
            return new OperationResult<T>(EnumTypeResult.InternalError);
        }

        public static new IOperationResult<T> CreateServiceUnavaliable()
        {
            return new OperationResult<T>(EnumTypeResult.ServiceUnavaliable);
        }

        public static new IOperationResult<T> CreateNotFound()
        {
            return new OperationResult<T>(EnumTypeResult.NotFound);
        }

        public static new IOperationResult<T> CreateInternalError(Exception exception)
        {
            return new OperationResult<T>(EnumTypeResult.InternalError, exception);
        }
        #endregion

        #region Funções Públicas
        public new IOperationResult<T> AddMessage(string message)
        {
            _AddMessage(message);
            return this;
        }

        public new IOperationResult<T> AddMessage(IEnumerable<string> messages)
        {
            _AddMessage(messages);
            return this;
        }
        #endregion
    }
}
