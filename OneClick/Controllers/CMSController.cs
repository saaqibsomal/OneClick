using Microsoft.AspNetCore.Mvc;
using OneClick.Infrastructure.Model;
using OneClick.Models;
using OneClick.Service.Interface;

namespace OneClick.Controllers
{
    [Route("api")]
    [ApiController]
    public class CMSController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ICMSService _CMSService;
        public CMSController(IConfiguration configuration, ICMSService CMSService)
        {
            _configuration = configuration;
            _CMSService = CMSService;
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost]
        [Route("add-Content")]
        public IActionResult AddContent(CMSRequest req)
        {

             IFormFile? file = null;
            var response = _CMSService.AddCMS(req, file);
            return Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost]
        [Route("Update-Content")]
        public IActionResult UpdateContent(IFormFile? file, CMSRequest req)
        {
            var response = _CMSService.UpdateCMS(req, file);
            return Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost]
        [Route("get-Content")]
        public IActionResult getContent(string Key)
        {
           var Response = _CMSService.GetCMSValue(Key);
            return Ok(Response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost]
        [Route("get-Content-list")]
        public IActionResult getContentList(string Key)
        {

            var Response = _CMSService.GetCMSList(Key);
            return Ok(Response);
        }
    }
}
