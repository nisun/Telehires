using System.Collections.Generic;

namespace Telehire.BusinessLogic.Infrastructures
{
    public interface IPagedList<T> : IList<T>
    {
        int PageIndex { get; }
        int PageSize { get; }
        int TotalCount { get; }
        int TotalPages { get; }
        bool HasPreviousPage { get; }
        bool HasNextPage { get; }
        IEnumerable<T> TheSource { get; }
    }
}
