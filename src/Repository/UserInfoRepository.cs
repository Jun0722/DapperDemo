using System;
using System.Collections.Generic;
using System.Data;
using OnlineStore.IRepository;
using OnlineStore.Models;
using OnlineStore.Models.Pagination;
using static Dapper.SqlMapper;

namespace OnlineStore.Repository
{
    public class UserInfoRepository:Repository<UserInfo>,IUserInfoRepository
    {
        List<UserInfo> userInfos = null;
        int? totalRecords = null;

        public override List<UserInfo> GetPageList(UrlQuery urlQuery)
        {
            string sql = @"select Id,UserName,UserPwd,RegTime,Email from UserInfo";
            if(urlQuery.PageIndex.HasValue)
            {
                sql += @" order by Id offset @PageIndex*(@PageIndex-1) rows fetch next @PageSize rows only";
            }
            if(urlQuery.PageIndex.HasValue && urlQuery.IncludeCount)
            {
                sql += @" select [TotalCount]=Count(*) from UserInfo";
            }
            using(IDbConnection conn=Data.DbConfig.GetSqlConnection())
            {
                GridReader results = conn.QueryMultiple(sql, urlQuery);
                userInfos = results.Read<UserInfo>().AsList();
                if(urlQuery.PageIndex.HasValue && urlQuery.IncludeCount)
                {
                    totalRecords = results.ReadSingle<int>();
                }
            }
            if(urlQuery.PageIndex.HasValue)
            {
                Pagination pagination = new Pagination()
                {
                    PageIndex = urlQuery.PageIndex.Value,
                    PageSize = urlQuery.PageSize
                };
                if(urlQuery.IncludeCount)
                {
                    pagination.TotalRecords = totalRecords.Value;
                }
            }
            return userInfos;
        }
    }
}
