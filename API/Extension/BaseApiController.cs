using System.Web;
using System.Web.Http;
using API.Models;
using Common;

// ReSharper disable once CheckNamespace
namespace API
{
    public class BaseApiController : ApiController
    {
        protected Users CurrentUser;

        public BaseApiController()
        {
            var id = HttpContext.Current.Request.Cookies[UserParameter.UserCookie]?.Value;
            if (!string.IsNullOrEmpty(id))
            {
                CurrentUser = RedisHelper.GetCache<Users>(id);
            }
        }
    }
}