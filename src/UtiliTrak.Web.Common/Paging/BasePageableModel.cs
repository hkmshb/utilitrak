using System;
using Hazeltek.UtiliTrak.Services;



namespace Hazeltek.UtiliTrak.Web.Common.Paging
{
    public abstract class BasePageableModel: IPageableModel
    {
        public virtual void LoadPagedList<T>(IPagedList<T> pagedList)
        {
            int indexStartPos = (pagedList.PageIndex * pagedList.PageSize);
            LastItem = Math.Min(pagedList.TotalCount, indexStartPos + pagedList.PageSize);
            FirstItem = indexStartPos + 1;
            PageNumber = pagedList.PageIndex + 1;
            PageSize = pagedList.PageSize;
            TotalItems = pagedList.TotalCount;
            TotalPages = pagedList.TotalPages;
        }

        /// <summary>
        /// Gets the current page index (starts from 0). 
        /// </summary>
        public int PageIndex 
        { 
            get {
                if (PageNumber > 0)
                    return PageNumber - 1;
                return 0;
            } 
        }

        /// <summary>
        /// Gets the current page number (starts from 1).
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Gets the number of items in each page.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Gets the total number of items.
        /// </summary>
        public int TotalItems { get; set; }

        /// <summary>
        /// Gets the total number of pages.
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// Gets the index of the first item in the page.
        /// </summary>
        public int FirstItem { get; set; }

        /// <summary>
        /// Gets the index of the last item in the page.
        /// </summary>
        public int LastItem { get; set; }

        /// <summary>
        /// Gets whether there are pages before the current page.
        /// </summary>
        public bool HasPrevPage { get; set; }

        /// <summary>
        /// Gets whether there are pages after the current page.
        /// </summary>
        public bool HasNextPage { get; set; }
    }


}