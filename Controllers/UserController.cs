using Microsoft.AspNetCore.Mvc;
using Vue3_Service.Parameter;

namespace Vue3_Service.Controllers
{
	[Route("api/user/[action]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		public IActionResult Login([FromBody] Login data)
		{

			return Ok(100);
		}
	}
}
