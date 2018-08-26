using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using OnlineStore.Data;
using OnlineStore.IRepository;
using OnlineStore.Models;

namespace OnlineStore.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public async Task<bool> AddAsync(T entity)
        {
            using (IDbConnection conn = DbConfig.GetSqlConnection())
            {
                return await conn.InsertAsync(entity) > 0;
            }
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            using (IDbConnection conn = DbConfig.GetSqlConnection())
            {
                var entity = await conn.GetAsync<T>(id);
                return await conn.DeleteAsync(entity);
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            using (IDbConnection conn = DbConfig.GetSqlConnection())
            {
                return await conn.GetAllAsync<T>();
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            using (IDbConnection conn = DbConfig.GetSqlConnection())
            {
                return await conn.GetAsync<T>(id);
            }
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            using (IDbConnection conn = DbConfig.GetSqlConnection())
            {
                return await conn.UpdateAsync(entity);
            }
        }
        //分页
        public PageDataView<T> GetPageListForSql(PageCriteria pageCriteria)
        {
            var result = new PageDataView<T>();
            string sql = "SELECT * from(SELECT " + pageCriteria.Fields + ",row_number() over(order by " + pageCriteria.Sort + ") rownum FROM " + pageCriteria.TableName + " where " + pageCriteria.Condition + ") t where rownum>@minrownum and rownum<=@maxrownum";
            string countSql = "select count(1) from " + pageCriteria.TableName + "  where " + pageCriteria.Condition;
            int minrownum = (pageCriteria.CurrentPage - 1) * pageCriteria.PageSize;
            int maxrownum = minrownum + pageCriteria.PageSize;

            var p = new DynamicParameters();
            p.Add("minrownum", minrownum);
            p.Add("maxrownum", maxrownum);
            if (pageCriteria.ParameterList != null)
            {
                foreach (var param in pageCriteria.ParameterList)
                {
                    p.Add(param.ParaName, param.ParamValue);
                }
            }
            using(IDbConnection conn=DbConfig.GetSqlConnection())
            {
                var reader = conn.QueryMultiple(sql + ";" + countSql, p);
                result.Items = reader.Read<T>().ToList();
                result.TotalNum = reader.Read<int>().First<int>();
                result.CurrentPage = pageCriteria.CurrentPage;
                result.TotalPageCount = result.TotalNum / pageCriteria.PageSize + (result.TotalNum % pageCriteria.PageSize == 0 ? 0 : 1);
                return result;
            }
        }
    }
}
