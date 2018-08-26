using System;
using System.Collections.Generic;

namespace OnlineStore.Models
{
    /// <summary>
    /// 分页实体
    /// </summary>
    public class PageCriteria
    {
        //查询表名
        public string TableName { get; set; }
        //字段集合
        public string Fields { get; set; }
        //主键名
        public string PrimaryKey { get; set; }
        //每页数量
        public int PageSize { get; set; }
        //当前页码
        public int CurrentPage { get; set; }
        //排序字段
        public string Sort { get; set; }
        //查询条件
        public string Condition { get; set; }
        //总数
        public int RecordCount { get; set; }
        //传入的参数列表
        public IList<ParameterDict> ParameterList { get; set; }

        public PageCriteria()
        {
            ParameterList = new List<ParameterDict>();
        }
    }
}
