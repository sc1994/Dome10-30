using System.Linq;
using API.Models;
using Common;
using System.Net;
using System.Web.Http;

namespace API.Controllers
{
    public class SignUpController : ApiController
    {
        /// <summary>
        /// 注册接口
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Index(Users model)
        {
            if (string.IsNullOrEmpty(model.UName) || string.IsNullOrEmpty(model.UPassword))
            {
                return Content(HttpStatusCode.InternalServerError, ErrorEnum.E1.GetDescription());
            }

            var shOther = new SqlHelper<Users>();
            shOther.AddWhere("UName", model.UName);
            if (shOther.Select().Any())
            {
                return Content(HttpStatusCode.InternalServerError, ErrorEnum.E7.GetDescription());
            }

            var sh = new SqlHelper<Users>(model);
            if (sh.Insert() > 0)
            {
                return Content(HttpStatusCode.OK, "注册成功");
            }
            return Content(HttpStatusCode.InternalServerError, ErrorEnum.E2.GetDescription());
        }
    }
}
