using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Vue3_Service.Filters
{

	public class AuthFilter3 : IAuthorizationFilter
	{

		Entity.MyDBContext _context;
		public AuthFilter3(Entity.MyDBContext context)
		{
			this._context = context;
		}

		public void OnAuthorization(AuthorizationFilterContext context)
		{
			Console.WriteLine("hello world");
			var ok = new OkObjectResult("error");
			context.Result = ok;
		}
	}

}
