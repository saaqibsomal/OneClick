using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneClick.Infrastructure.Model;
using OneClick.Models;
using OneClick.Service;
using OneClick.Service.Interface;

namespace OneClick.Controllers
{
    //[Authorize]
    [Route("api")]
    [ApiController]
    public class GalleryController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IGalleryService _galleryService;
        public GalleryController(IConfiguration configuration, IGalleryService galleryService)
        {
            _configuration = configuration;
            _galleryService = galleryService;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        [Route("add-gallery")]
        public IActionResult AddGallery([FromForm] GalleryRequest req, IFormFile? file)
        {
            var response = _galleryService.AddGallery(req, file);
            return Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        [Route("add-video")]
        public IActionResult AddVideo([FromForm] GalleryRequest req, IFormFile? file)
        {
            var response = _galleryService.AddVideo(req, file);
            return Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        [Route("get-gallery")]
        public IActionResult getContentList()
        {

            var Response = _galleryService.GetGallery();
            return Ok(Response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        [Route("get-video")]
        public IActionResult GetVideo()
        {

            var Response = _galleryService.GetVideo();
            return Ok(Response);
        }
    }
}
