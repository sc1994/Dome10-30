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
            var sh = new SqlHelper<Users>(model);
            if (sh.Insert() > 0)
                return Content(HttpStatusCode.OK, "注册成功");
            return Content(HttpStatusCode.InternalServerError, "链接异常,稍后再试");
        }
    }
}
