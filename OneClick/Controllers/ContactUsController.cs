using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using OneClick.Common;
using OneClick.Model;
using OneClick.Model.Email;

namespace OneClick.Controllers
{
	[Route("api")]
	public class ContactUsController : ControllerBase
	{
		private readonly IConfiguration _configuration;
		public ContactUsController(IConfiguration configuration) {
			_configuration = configuration;
		}

		[ProducesResponseType(StatusCodes.Status200OK)]
		[HttpPost]
		[Route("contact-us")]
		public IActionResult Contact(ContactUsDto req)
		{
			
			string EmailFrom = _configuration.GetValue<string>("AppSettings:Email");
			string Password = _configuration.GetValue<string>("AppSettings:Password");
			string Host = _configuration.GetValue<string>("AppSettings:Host");
			int Port = _configuration.GetValue<int>("AppSettings:Port");
			string res = CommonMethod.SendEmail(req, EmailFrom,Password, Host,Port);
			return Ok(res);
		}
	}
}
