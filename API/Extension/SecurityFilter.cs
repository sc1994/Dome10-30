using API.Models;
using Common;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

// ReSharper disable once CheckNamespace
namespace API
{
    public class SecurityFilter : ActionFilterAttribute
    {
        private readonly Access _accress;
        public SecurityFilter(Access accress)
        {
            _accress = accress;
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var cookie = HttpContext.Current.Request.Cookies[UserParameter.UserCookie];
            if (cookie != null)
            {
                var id = cookie.Value;
                if (string.IsNullOrEmpty(id))
                {
                    if (_accress == Access.NeedLogin)
                    {
                        actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                    }
                }

                var user = RedisHelper.GetCache<Users>(id);
                if (user == null || user.UID <= 0)
                {
                    if (_accress == Access.NeedLogin)
                    {
                        actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                    }
                }
                else
                {
                    if (_accress == Access.Logined)
                    {
                        actionContext.Response = new HttpResponseMessage(HttpStatusCode.Conflict);
                    }
                }
            }
            else
            {
                if (_accress == Access.NeedLogin)
                {
                    actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                }
            }
        }
    }
}