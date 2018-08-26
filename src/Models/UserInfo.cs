using System;
using Dapper.Contrib.Extensions;

namespace OnlineStore.Models
{
    [Table("UserInfo")]
    public class UserInfo
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserPwd { get; set; }
        public DateTime? RegTime { get; set; }
        public string Email { get; set; }
    }
}
