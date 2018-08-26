using System;
using OnlineStore.IRepository;
using OnlineStore.Models;

namespace OnlineStore.Repository
{
    public class UserInfoRepository:Repository<UserInfo>,IUserInfoRepository
    {
       
    }
}
