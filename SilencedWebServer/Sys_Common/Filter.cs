namespace Sys_Common
{
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Mvc.Filters;

	public class AuthorizFilter : ActionFilterAttribute
	{
		public override void OnActionExecuted(ActionExecutedContext context)
		{

			base.OnActionExecuted(context);
		}
		public override void OnActionExecuting(ActionExecutingContext context)
		{

			context.HttpContext.Session.TryGetValue("name", out var name);
			if (name == null)
			{
				context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;

				var objectResult = new ObjectResult(new { isSuccess = false, message = "Unauthorized！Maybe login again." });
				context.Result = objectResult;

			}
			base.OnActionExecuting(context);
		}
		public override void OnResultExecuted(ResultExecutedContext context)
		{

			base.OnResultExecuted(context);
		}
		public override void OnResultExecuting(ResultExecutingContext context)
		{
			base.OnResultExecuting(context);
		}

	}
}