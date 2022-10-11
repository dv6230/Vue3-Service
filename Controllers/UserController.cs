using Microsoft.AspNetCore.Mvc;
using Vue3_Service.Entity;
using Vue3_Service.Model;
using Vue3_Service.Services;

namespace Vue3_Service.Controllers
{
	[Route("api/user/[action]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private MyDBContext entity;
		private UserService userService;

		public UserController(MyDBContext myDB, UserService service)
		{
			this.entity = myDB;
			this.userService = service;
		}

		[HttpPost]
		public async Task<IActionResult> Login([FromBody] Parameter.Login loginData)
		{
			var user = userService.CheckUser(loginData);

			if (user == null)
			{
				return Ok("帳號或密碼錯誤");
			}

			var token = Utilities.Token.CreateToken(user.Email);
			var boo = userService.LoginRecord(user.Id, token);

			if (!boo) return Ok(new Reponse() { message = "帳號或密碼錯誤", status = "fail" });

			Dictionary<string, object> data = new Dictionary<string, object>();
			data["token"] = token;
			data["userId"] = user.Id;
			data["userName"] = user.Name;

			return Ok(new Reponse() { message = "登入成功", status = "success", data = data });

		}
	}
}
