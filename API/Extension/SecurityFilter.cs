using System;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using System.Web.Security;
using API.Models;
using Common;

// ReSharper disable once CheckNamespace
namespace API
{
    public class SecurityFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var cookie = HttpContext.Current.Request.Cookies[UserParameter.UserCookie];
            if (cookie != null)
            {
                var ticket = cookie.Value;
                if (ticket == null) return;

                var user = ticket.JsonToObject<Users>();

                if (user == null || user.UID <= 0)
                    actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }
            else
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }
        }
    }
}