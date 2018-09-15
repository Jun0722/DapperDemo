using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using OnlineStore.Data.IRepository;
using OnlineStore.Models;

namespace OnlineStore.Data.Repository
{
	public class ProductRepository:IProductRepository
    {

        public async Task<bool> AddAsync(Product entity)
        {
            using (IDbConnection conn = DbConfig.GetSqlConnection())
            {
                string sql = @"INSERT INTO Product 
                            (Name
                            ,Quantity
                            ,Price
                            ,CategoryId)
                        VALUES
                            (@Name
                            ,@Quantity
                            ,@Price
                            ,@CategoryId)";
                return await conn.ExecuteAsync(sql, entity) > 0;
            }
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            using (IDbConnection conn = DbConfig.GetSqlConnection())
            {
                string sql = @"DELETE FROM Product
                            WHERE Id = @Id";
                return await conn.ExecuteAsync(sql, new { Id = id }) > 0;
            }
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            using (IDbConnection conn = DbConfig.GetSqlConnection())
            {
                return await conn.QueryAsync<Product>(@"SELECT Id
                                            ,Name
                                            ,Quantity
                                            ,Price
                                            ,CategoryId
                                        FROM Product");
            }
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            using (IDbConnection conn = DbConfig.GetSqlConnection())
            {
                string sql = @"SELECT Id
                                ,Name
                                ,Quantity
                                ,Price 
                                ,CategoryId
                            FROM Product
                            WHERE Id = @Id";
                return await conn.QueryFirstOrDefaultAsync<Product>(sql, new { Id = id });
            }
        }

        public async Task<bool> UpdateAsync(Product entity)
        {
            using (IDbConnection conn = DbConfig.GetSqlConnection())
            {
                string sql = @"UPDATE Product SET 
                                Name = @Name
                                ,Quantity = @Quantity
                                ,Price= @Price
                                ,CategoryId= @CategoryId
                           WHERE Id = @Id";
                return await conn.ExecuteAsync(sql, entity) > 0;
            }
        }

        //存储过程
        //using (var connection = My.ConnectionFactory())
        //{
        //    connection.Open();

        //    var affectedRows = connection.Execute(sql,
        //        new { Kind = InvoiceKind.WebInvoice, Code = "Single_Insert_1" },
        //        commandType: CommandType.StoredProcedure);

        //    My.Result.Show(affectedRows);
        //}

        //事务
        //using (var connection = My.ConnectionFactory())
        //{
        //    connection.Open();

        //    using (var transaction = connection.BeginTransaction())
        //    {
        //        var affectedRows = connection.Execute(sql, new { CustomerName = "Mark" }, transaction: transaction);

        //    transaction.Commit();
        //    }
        //}
    }
}
