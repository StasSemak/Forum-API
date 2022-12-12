using BussinessLogic.DTOs;
using BussinessLogic.Intefraces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebForum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountsController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDto user)
        {
            if (!ModelState.IsValid) return BadRequest();

            await accountService.RegisterAsync(user);

            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserCredentials credentials)
        {
            if (!ModelState.IsValid) return BadRequest();

            var user = await accountService.LoginAsync(credentials.Email, credentials.Password);

            return Ok(user);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetUser([FromRoute]string id)
        {
            try
            {
                var user = await accountService.GetUserAsync(id);
                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
