using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ViMail.Service.Interfaces;

namespace ViMail.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("login")]
        public async Task<ActionResult> Login(string username, string password)
        {
            var result = await _accountService.LoginAsync(username, password);
            if (result)
                return Ok("abc");


            return BadRequest();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(string username, string password)
        {
            var result = await _accountService.RegisterAsync(username, password);
            if (result)
                return Ok();

            return BadRequest();
        }
    }
}