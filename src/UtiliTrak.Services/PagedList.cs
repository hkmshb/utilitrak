using System.Linq;
using System.Collections.Generic;



namespace Hazeltek.UtiliTrak.Services
{
    public class PagedList<T>: List<T>, IPagedList<T>
    {
        public PagedList(IList<T> source, int pageIndex, int pageSize):
               this(source.Skip(pageIndex * pageSize).Take(pageSize),
                    pageIndex, pageSize, source.Count())
        {
        }

        public PagedList(IQueryable<T> source, int pageIndex, int pageSize):
               this(source.Skip(pageIndex * pageSize).Take(pageSize),
                    pageIndex, pageSize, source.Count())
        {
        }

        public PagedList(IEnumerable<T> source, int pageIndex, int pageSize, 
               int totalCount)
        {
            this.TotalCount = totalCount;
            this.TotalPages = TotalCount / pageSize;
            if (TotalCount % pageSize > 0)
                TotalPages++;
            
            this.PageSize = pageSize;
            this.PageIndex = pageIndex;
            this.AddRange(source);
        }

        public int PageIndex { get; private set; }

        public virtual int PageSize { get; private set; }

        public virtual int TotalCount { get; private set; }

        public virtual int TotalPages { get; private set; }

        public bool HasPrevPage 
        { 
            get { return (PageIndex > 0); } 
        }

        public bool HasNextPage 
        { 
            get { return (PageIndex + 1 < TotalPages); } 
        }
    }


}