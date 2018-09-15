using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using OnlineStore.Data.IRepository;

namespace OnlineStore.Data.Repository
{
    public class BaseRepository_Contrib<T>:IBaseRepository<T> where T:class
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
    }
}
