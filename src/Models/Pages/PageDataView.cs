using System;
using System.Collections.Generic;

namespace OnlineStore.Models
{
    /// <summary>
    /// 分页获取数据实体
    /// </summary>
    public class PageDataView<T>
    {
        //总数
        public int TotalNum { get; set; }
        //具体数据列表
        public IList<T> Items { get; set; }
        //当前页数
        public int CurrentPage { get; set; }
        //总页数
        public int TotalPageCount { get; set; }

        public PageDataView()
        {
            this.Items = new List<T>();
        }
    }
}
