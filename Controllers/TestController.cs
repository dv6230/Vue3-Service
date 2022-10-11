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
		[ActionFilter(str: "test")]
		public IActionResult Test2()
		{
			return Ok(200);
		}

		[HttpGet]
		[ApiExplorerSettings(IgnoreApi = true)]  // Swagger 隱藏此 API
		public IActionResult Test3()
		{
			return Ok("hidden");
		}

		[HttpGet]
		public IActionResult TestMD5(string content)
		{
			return Ok(Utilities.StringHash.MD5(content));
		}

		[HttpGet]
		public IActionResult TestSha256(string content)
		{
			return Ok(Utilities.StringHash.SHA256(content));
		}

	}
}
