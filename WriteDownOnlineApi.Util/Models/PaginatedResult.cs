using System.Collections;
using System.ComponentModel;
using System.Text;
using WriteDownOnlineApi.Util.Enum;
using WriteDownOnlineApi.Util.Interfaces.Inputs;
using WriteDownOnlineApi.Util.Interfaces.Results;
using System.Linq.Dynamic.Core;

namespace WriteDownOnlineApi.Util.Models
{
    public class PaginatedResult : OperationResult<IList>, IPaginatedResult
    {
        #region Propriedades
        public int? TotalCount { get; set; }
        public int? Pages { get; set; }
        public int Count { get; set; }
        public int Page { get; set; }
        #endregion

        #region Construtores
        protected PaginatedResult(IOperationResultBase otherResult) : base(otherResult) { }
        protected PaginatedResult(EnumTypeResult statusCode) : base(statusCode) { }
        protected PaginatedResult(EnumTypeResult typeResult, Exception exception) : base(typeResult, exception) { }
        #endregion

        #region Criadores Genéricos
        public static new IPaginatedResult Create(IOperationResultBase otherResult)
        {
            return new PaginatedResult(otherResult);
        }

        public static new IPaginatedResult Create(EnumTypeResult typeResult)
        {
            return new PaginatedResult(typeResult);
        }
        #endregion

        #region Criadores Específicos
        public static IPaginatedResult CreateSuccess<TSource, TResult>(IPagination pagination, IQueryable<TSource> source, Func<TSource, TResult> selectFunction)
        {
            var result = new PaginatedResult(EnumTypeResult.Ok);
            result.Paginate(pagination, source, selectFunction);
            return result;
        }

        public static IPaginatedResult CreateSuccess<TSource>(IPagination pagination, IQueryable<TSource> source)
        {
            var result = new PaginatedResult(EnumTypeResult.Ok);
            result.Paginate<TSource, TSource>(pagination, source, null);
            return result;
        }

        public static new IPaginatedResult CreateInvalidInput()
        {
            return new PaginatedResult(EnumTypeResult.InvalidInput);
        }

        public static new IPaginatedResult CreateServiceUnavaliable()
        {
            return new PaginatedResult(EnumTypeResult.ServiceUnavaliable);
        }

        public static new IPaginatedResult CreateInternalError()
        {
            return new PaginatedResult(EnumTypeResult.InternalError);
        }

        public static new IPaginatedResult CreateNotFound()
        {
            return new PaginatedResult(EnumTypeResult.NotFound);
        }

        public static new IPaginatedResult CreateInternalError(Exception exception)
        {
            return new PaginatedResult(EnumTypeResult.InternalError, exception);
        }
        #endregion

        #region Funções Públicas
        public void Paginate<TSource, TResult>(IPagination pagination, IQueryable<TSource> source, Func<TSource, TResult> selectFunction)
        {
            Page = pagination.Page == 0 ? 1 : pagination.Page;

            var orderedSource = Order(source, pagination);

            var paginatedSource = orderedSource.Skip(Page * pagination.ItemsPerPage - pagination.ItemsPerPage).Take(pagination.ItemsPerPage);

            if (pagination.CountTotal && Page == 1)
            {
                TotalCount = source.Count();

                double pages = TotalCount.Value / (double)pagination.ItemsPerPage;

                Pages = (int)(pages % 1 == 0 ? pages : pages + 1);
            }

            if (selectFunction != null)
            {
                var registrosSelecionados = paginatedSource.Select(selectFunction);
                Data = registrosSelecionados.ToList();
            }
            else
            {
                Data = paginatedSource.ToList();
            }
            Count = Data.Count;
        }

        public new IPaginatedResult AddMessage(string message)
        {
            _AddMessage(message);
            return this;
        }
        #endregion

        #region Funções Privada
        private IQueryable<TSource> Order<TSource>(IQueryable<TSource> source, IOrderable ordenator)
        {
            if (ordenator.Ordenations is null || !ordenator.Ordenations.Any())
                return source;

            StringBuilder query = new StringBuilder();

            foreach (var ordenation in ordenator.Ordenations)
            {
                query.Append(ordenation.PropertyName);
                query.Append(ordenation.Direction == ListSortDirection.Descending ? " desc" : " asc");
                query.Append(",");
            }
            query = query.Remove(query.Length - 1, 1);
            return source.OrderBy(query.ToString());
        }
        #endregion
    }
}
