using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace Main.Filters
{
    public class NotImplExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
			context.Response.StatusCode = HttpStatusCode.OK;
			context.Response.Content = JsonContent.Create(new { isSuccess = false, message = context.Exception.Message });
		}
    }
}
