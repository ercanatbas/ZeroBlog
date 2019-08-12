using Microsoft.AspNetCore.Mvc;
using ZBlog.Application.Users;
using ZBlog.Application.Users.Request;
using ZBlog.Core.Authentication;

namespace ZBlog.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class AccountController : ControllerBase
    {
        #region .ctor

        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        #endregion

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(typeof(Token), 200)]
        public IActionResult Login([FromBody] LoginRequest request) => Ok(_accountService.Login(request));
    }
}
