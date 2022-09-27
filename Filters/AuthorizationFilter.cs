using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;

namespace Vue3_Service.Filters
{
	public class ActionFilter : Attribute, IActionFilter
	{
		string str = "";
		public ActionFilter(string str)
		{
			this.str = str;
		}

		public void OnActionExecuting(ActionExecutingContext context)
		{
			StringValues auth;
			context.HttpContext.Request.Headers.TryGetValue("auth", out auth);
			if (auth.ToString() != "test")
			{
				context.Result = new OkObjectResult(new { status = "fail", message = "權限不足" });
			}
			else
			{
				throw new InvalidOperationException("Request is not valid!");
			}
		}

		public void OnActionExecuted(ActionExecutedContext context)
		{
			//context.HttpContext.Response.WriteAsync($"{GetType().Name} out. \r\n");
		}
	}
}
