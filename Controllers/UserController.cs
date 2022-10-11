using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vue3_Service.Entity;
using Vue3_Service.Services;

namespace Vue3_Service.Controllers
{
	[Route("api/user/[action]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private MyDBContext entity ;
		private UserService userService;

		public UserController(MyDBContext myDB,UserService service)
		{
			this.entity = myDB;
			this.userService = service;
		}

		[HttpGet]
		public async Task<IActionResult> Login([FromBody] Parameter.Login user)
		{
			
			return Ok(100);
		}




	}
}
