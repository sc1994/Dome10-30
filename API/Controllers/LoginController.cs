using API.Models;
using Common;
using System;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace API.Controllers
{
    public class LoginController : ApiController
    {
        private readonly string _token = "token";

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

        [HttpPost]
        public IHttpActionResult Login(UserParameter model)
        {
            var cookie = HttpContext.Current.Request.Cookies[_token];
            if (cookie == null)
            {
                return Content(HttpStatusCode.InternalServerError, "Miss Cookie");
            }
            if (model.Md5 != cookie.Value)
            {
                return Content(HttpStatusCode.InternalServerError, "Error Token");
            }

            var sh = new SqlHelper<Users>();
            sh.AddWhere("UName", model.UName);
            sh.AddWhere("UPassword", model.UPassword);
            var user = sh.Select().FirstOrDefault();
            if (user == null) return Content(HttpStatusCode.InternalServerError, "账号名称或者密码错误");
            cookie.Expires = DateTime.Now.AddHours(-1);
            HttpContext.Current.Response.Cookies.Add(cookie);
            var newCookie = new HttpCookie(UserParameter.UserCookie)
            {
                Value = user.ToJson(),
                Expires = DateTime.Now.AddHours(8),
                Name = UserParameter.UserCookie
            };
            HttpContext.Current.Response.Cookies.Add(newCookie);
            return Content(HttpStatusCode.OK, "登陆成功");
        }
    }
}
