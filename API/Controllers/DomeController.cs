using System;
using System.Net;
using System.Web;
using System.Web.Http;
using API.Models;
using Common;

namespace API.Controllers
{
    public class DomeController : BaseApiController
    {
        /// <summary>
        /// 信息查看
        /// </summary>
        /// <returns></returns>
        [SecurityFilter(Access.NeedLogin)]
        [HttpGet]
        public IHttpActionResult Index()
        {
            if (CurrentUser == null)
            {
                return Content(HttpStatusCode.InternalServerError, ErrorEnum.E3.GetDescription());
            }

            return Content(HttpStatusCode.OK, new
            {
                name = CurrentUser.UName,
                sex = ((Sex)CurrentUser.USex).ToString(),
                phone = CurrentUser.UPhone,
                email = CurrentUser.UEmail
            });
        }

        /// <summary>
        /// 登出
        /// </summary>
        /// <returns></returns>
        [SecurityFilter(Access.NeedLogin)]
        [HttpGet]
        public IHttpActionResult Logout()
        {
            var cookie = HttpContext.Current.Request.Cookies[UserParameter.UserCookie];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(cookie);
                RedisHelper.ClearCache(cookie.Value);
            }
            return Content(HttpStatusCode.OK, "登出成功");
        }
    }
}
