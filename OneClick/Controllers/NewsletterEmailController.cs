using Microsoft.AspNetCore.Mvc;
using OneClick.Infrastructure.Model;
using OneClick.Model;
using OneClick.Service.Interface;

namespace OneClick.Controllers
{
    [Route("api")]
    [ApiController]
    public class NewsletterEmailController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private INewsletterEmailService _newsletterEmailService;
        public NewsletterEmailController(IConfiguration configuration, INewsletterEmailService newsletterEmailService)
        {
            _configuration = configuration;
            _newsletterEmailService = newsletterEmailService;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost]
        [Route("add-news-later")]
        public IActionResult AddNewslater(NewsletterEmail Request)
        {
            return Ok(_newsletterEmailService.AddNewslater(Request));
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        [Route("get-all")]
        public List<NewsletterEmail> UserRegistration()
        {
            return _newsletterEmailService.GetNewsletters();
        }
    }
}
