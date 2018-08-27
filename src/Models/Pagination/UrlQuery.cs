using System;
namespace OnlineStore.Models.Pagination
{
    public class UrlQuery
    {
        private const int maxPageSize = 100;
        public bool IncludeCount { get; set; } = false;
        public int? PageIndex { get; set; }
        private int _pageSize = 50;
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = (value < maxPageSize) ? value : maxPageSize; }
        }
    }
}
