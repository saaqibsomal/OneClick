using Microsoft.AspNetCore.Mvc;
using OneClick.Common;
using OneClick.Infrastructure.Model;
using OneClick.Model;
using OneClick.Model.Email;
using OneClick.Service.Interface;

namespace OneClick.Controllers
{
    [Route("api")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private IUserService _userService;
        public UsersController(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginRequest Request)
        {
          var loginResponse =  _userService.Login(Request);
          return Ok(loginResponse);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost]
        [Route("user-registration")]
        public IActionResult UserRegistration(UserRequest Request)
        {
            var response = _userService.AddUser(Request);
            return Ok(response);
        }
    }
}
