using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System.Net;

namespace Vue3_Service.Filters
{

	public class AuthFilter2 : IAsyncActionFilter
	{

		Entity.MyDBContext _context;
		public AuthFilter2(Entity.MyDBContext context)
		{
			this._context = context;
		}

		/// <summary>
		/// 登入驗證功能
		/// </summary>
		/// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext" />.</param>
		/// <param name="next">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ActionExecutionDelegate" />. Invoked to execute the next action filter or the action itself.</param>
		public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{

			StringValues auth;
			context.HttpContext.Request.Headers.TryGetValue("Auth", out auth);

			var user = _context.UserLogins.Where(x => x.Token == auth.ToString()).Select(x => x.User).FirstOrDefault();
			//var parameter = context.ActionArguments.SingleOrDefault();

			if (user is null)
			{
				context.Result = new ObjectResult("沒有權限")
				{
					StatusCode = (int)HttpStatusCode.BadRequest
				};
			}
			else
			{
				await next();
			}
		}
	}

}
