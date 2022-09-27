using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Vue3_Service.Filters;

namespace Vue3_Service.Controllers
{
	[Route("api/test/[action]")]
	[ApiController]
	public class TestController : ControllerBase
	{
		[HttpPost]

		public IActionResult Test1()
		{
			return Ok(100);
		}

		[HttpGet]
		[ActionFilter(str:"test")]
		public IActionResult Test2()
		{
			return Ok(200);
		}
	}
}
