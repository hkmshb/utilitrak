namespace Hazeltek.UtiliTrak.Web.Common.Paging
{
    /// <summary>
    /// Represents a collection of objects that has been split into pages.
    /// </summary>
    public interface IPageableModel
    {
        /// <summary>
        /// Gets the current page index (starts from 0). 
        /// </summary>
        int PageIndex { get; }

        /// <summary>
        /// Gets the current page number (starts from 1).
        /// </summary>
        int Page { get; }

        /// <summary>
        /// Gets the number of items in each page.
        /// </summary>
        int PageSize { get; }

        /// <summary>
        /// Gets the total number of items.
        /// </summary>
        int TotalItems { get; }

        /// <summary>
        /// Gets the total number of pages.
        /// </summary>
        int TotalPages { get; }

        /// <summary>
        /// Gets the index of the first item in the page.
        /// </summary>
        int FirstItem { get; }

        /// <summary>
        /// Gets the index of the last item in the page.
        /// </summary>
        int LastItem { get; }

        /// <summary>
        /// Gets whether there are pages before the current page.
        /// </summary>
        bool HasPrevPage { get; }

        /// <summary>
        /// Gets whether there are pages after the current page.
        /// </summary>
        bool HasNextPage { get; }
    }

    /// <summary>
    /// Generic form of IPageableModel.
    /// </summary>
    public interface IPaginator<T>: IPageableModel
    {
    }


}