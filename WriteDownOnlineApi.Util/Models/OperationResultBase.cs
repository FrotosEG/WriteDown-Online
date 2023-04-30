using WriteDownOnlineApi.Util.Enum;
using WriteDownOnlineApi.Util.Interfaces.Results;

namespace WriteDownOnlineApi.Util.Models
{
    public class OperationResultBase : IOperationResultBase
    {
        #region Propriedades
        public List<string> Messages { get; set; }
        public EnumTypeResult ResultType { get; set; }
        public Exception Exception { get; set; }

        public bool IsSuccessTypeResult
        {
            get { return _IsSuccessTypeResult(ResultType); }
        }
        #endregion

        #region Construtores
        protected OperationResultBase(EnumTypeResult resultType)
        {
            ResultType = resultType;
        }

        protected OperationResultBase(IOperationResultBase otherResult)
        {
            Messages = otherResult.Messages;
            ResultType = otherResult.ResultType;
            Exception = otherResult.Exception;
        }

        protected OperationResultBase(EnumTypeResult resultType, Exception exception)
        {
            ResultType = resultType;
            Exception = exception;
        }
        #endregion

        #region Criadores Genéricos
        public static IOperationResultBase Create(EnumTypeResult typeResult)
        {
            return new OperationResultBase(typeResult);
        }

        public static IOperationResultBase Create(IOperationResultBase otherResult)
        {
            return new OperationResultBase(otherResult);
        }
        #endregion

        #region Criadores Específicos
        public static IOperationResultBase CreateSuccess()
        {
            return new OperationResultBase(EnumTypeResult.Ok);
        }

        public static IOperationResultBase CreateInvalidInput()
        {
            return new OperationResultBase(EnumTypeResult.InvalidInput);
        }

        public static IOperationResultBase CreateInternalError()
        {
            return new OperationResultBase(EnumTypeResult.InternalError);
        }

        public static IOperationResultBase CreateServiceUnavaliable()
        {
            return new OperationResultBase(EnumTypeResult.ServiceUnavaliable);
        }

        public static IOperationResultBase CreateNotFound()
        {
            return new OperationResultBase(EnumTypeResult.NotFound);
        }

        public static IOperationResultBase CreateInternalError(Exception exception)
        {
            return new OperationResultBase(EnumTypeResult.InternalError)
            {
                Exception = exception
            };
        }
        #endregion

        #region Funções Públicas
        public IOperationResultBase AddMessage(string message)
        {
            _AddMessage(message);
            return this;
        }

        public IOperationResultBase AddMessage(IEnumerable<string> messages)
        {
            _AddMessage(messages);
            return this;
        }
        #endregion

        #region Funcoes Privadas e Protegidas
        private bool _IsSuccessTypeResult(EnumTypeResult typeResult)
        {
            switch (typeResult)
            {
                case EnumTypeResult.Ok:
                case EnumTypeResult.Created:
                case EnumTypeResult.Accepted:
                    return true;
                default:
                    return false;
            }
        }

        protected void _AddMessage(string message)
        {
            if (Messages == null)
                Messages = new List<string>();
            Messages.Add(message);
        }

        protected void _AddMessage(IEnumerable<string> messages)
        {
            if (messages is null)
                return;
            if (Messages == null)
                Messages = new List<string>();
            Messages.AddRange(messages);
        }
        #endregion
    }
}
