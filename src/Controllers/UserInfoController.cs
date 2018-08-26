using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.IRepository;
using OnlineStore.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineStore.Controllers
{
    public class UserInfoController : Controller
    {
        private readonly IUserInfoRepository _userInfoRepository;
        public UserInfoController(IUserInfoRepository userInfoRepository)
        {
            _userInfoRepository = userInfoRepository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<UserInfo> userInfos = _userInfoRepository.GetAllAsync().Result.ToList();
            ViewData.Model = userInfos;

            //PageCriteria pageCriteria = new PageCriteria();
            //StringBuilder sb = new StringBuilder();
            //sb.Append("userName like @userName");
            //pageCriteria.ParameterList.Add(new ParameterDict() { ParaName = "userName", ParamValue = "Test" + "%" });
            //pageCriteria.Condition = sb.ToString();
            //pageCriteria.CurrentPage = 1;
            //pageCriteria.Fields = " Id,userName,UserPwd,RegTime,Email ";
            //pageCriteria.PageSize = 5;
            //pageCriteria.PrimaryKey = " id";
            //pageCriteria.Sort = " id desc";
            //pageCriteria.TableName = "UserInfo";



            //var userInfos = _userInfoRepository.GetPageListForSql(pageCriteria);
            //ViewData.Model = userInfos;

            return View();
        }
    }
}
