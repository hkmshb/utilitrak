using System.Collections.Generic;


namespace Hazeltek.UtiliTrak.Services
{
    public interface IPagedList<T>: IList<T>
    {
        int PageIndex { get; }

        int PageSize { get; }

        int TotalCount { get; }

        int TotalPages { get; }

        bool HasPrevPage { get; }

        bool HasNextPage { get; }
    }

}