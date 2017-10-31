using System.Linq;
using API.Models;
using Common;
using System.Net;
using System.Web.Http;

namespace API.Controllers
{
    public class SignUpController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Index(Users model)
        {
            if (string.IsNullOrEmpty(model.UName) || string.IsNullOrEmpty(model.UPassword))
            {
                return Content(HttpStatusCode.InternalServerError, "缺少比要字段");
            }
            var shOther = new SqlHelper<Users>();
            shOther.AddWhere("UName", model.UName);
            if (shOther.Select().Any())
            {
                return Content(HttpStatusCode.InternalServerError, "已存在的用户名");
            }
            var sh = new SqlHelper<Users>(model);
            if (sh.Insert() > 0)
                return Content(HttpStatusCode.OK, "注册成功");
            return Content(HttpStatusCode.InternalServerError, "链接异常,稍后再试");
        }
    }
}
