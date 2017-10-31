using System;
using System.Net;
using System.Web;
using System.Web.Http;
using API.Models;
using Common;

namespace API.Controllers
{
    public class DomeController : ApiController
    {
        [SecurityFilter]
        [HttpGet]
        public IHttpActionResult Index()
        {
            var model = HttpContext.Current.Request.Cookies[UserParameter.UserCookie]?.Value.JsonToObject<Users>();

            if (model == null)
                return Content(HttpStatusCode.InternalServerError, "请求成功,但未取得预期的成果");

            return Content(HttpStatusCode.OK, new
            {
                name = model.UName,
                sex = ((Sex)model.USex).ToString(),
                phone = model.UPhone,
                email = model.UEmail
            });
        }

        [SecurityFilter]
        [HttpGet]
        public IHttpActionResult Logout()
        {
            var cookie = HttpContext.Current.Request.Cookies[UserParameter.UserCookie];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
            return Content(HttpStatusCode.OK, "操作成功");
        }
    }
}
