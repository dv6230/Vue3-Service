using Microsoft.AspNetCore.Mvc;

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
    }
}
