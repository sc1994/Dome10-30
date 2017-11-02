using API.Models;
using Common;
using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace API.Controllers
{
    public class LoginController : ApiController
    {
        private readonly string _token = "token";

        /// <summary>
        /// 获取登陆票据
        /// </summary>
        /// <returns></returns>
        [SecurityFilter(Access.Logined)]
        [HttpGet]
        public IHttpActionResult GetToken()
        {
            var token = DateTime.Now.ToString("yyyyMMMMdd").ToMd5();

            var cookie = new HttpCookie(_token)
            {
                Value = token,
                Expires = DateTime.Now.AddHours(8),
                Name = _token
            };

            HttpContext.Current.Response.Cookies.Add(cookie);
            return Content(HttpStatusCode.OK, token);
        }

        /// <summary>
        /// 登录接口
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [SecurityFilter(Access.Logined)]
        [HttpPost]
        public IHttpActionResult Login(UserParameter model)
        {
            if (string.IsNullOrEmpty(model.Md5) || string.IsNullOrEmpty(model.UName) || string.IsNullOrEmpty(model.UPassword))
            {
                return Content(HttpStatusCode.InternalServerError, ErrorEnum.E1.GetDescription());
            }
            var cookie = HttpContext.Current.Request.Cookies[_token];
            if (cookie == null)
            {
                return Content(HttpStatusCode.InternalServerError, ErrorEnum.E4.GetDescription());
            }
            if (model.Md5 != cookie.Value)
            {
                return Content(HttpStatusCode.InternalServerError, ErrorEnum.E5.GetDescription());
            }

            var sh = new SqlHelper<Users>();
            sh.AddWhere("UName", model.UName);
            sh.AddWhere("UPassword", model.UPassword);
            var user = sh.Select().FirstOrDefault();
            if (user == null) return Content(HttpStatusCode.InternalServerError, ErrorEnum.E6.GetDescription());
            cookie.Expires = DateTime.Now.AddHours(-1);
            HttpContext.Current.Response.Cookies.Add(cookie);
            var newCookie = new HttpCookie(UserParameter.UserCookie)
            {
                Value = user.UID.ToString(),
                Expires = DateTime.Now.AddSeconds(Convert.ToInt32(ConfigurationManager.ConnectionStrings["LandingTime"].ConnectionString)),
                Name = UserParameter.UserCookie
            };
            HttpContext.Current.Response.Cookies.Add(newCookie);

            RedisHelper.SetCache(user.UID.ToString(), user, DateTime.Now.AddSeconds(Convert.ToInt32(ConfigurationManager.ConnectionStrings["LandingTime"].ConnectionString)));

            return Content(HttpStatusCode.OK, "登陆成功");
        }
    }
}
