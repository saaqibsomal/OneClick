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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        [Route("add-Content")]
        public IActionResult AddContent([FromForm] CMSRequest req, IFormFile? file)
        {
            var response = _CMSService.AddCMS(req, file);
            return Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost]
        [Route("Update-Content")]
        public IActionResult UpdateContent([FromForm] CMSRequest req, IFormFile? file)
        {
            var response = _CMSService.UpdateCMS(req, file);
            return Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        [Route("get-Content")]
        public IActionResult getContent(string Key)
        {
           var Response = _CMSService.GetCMSValue(Key);
            return Ok(Response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        [Route("get-Content-list")]
        public IActionResult getContentList(string Key)
        {

            var Response = _CMSService.GetCMSList(Key);
            return Ok(Response);
        } 
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpDelete]
        [Route("cms-content-delete")]
        public IActionResult CMS_ContentDeleted(string Key)
        {
            var Response = _CMSService.DeletedByKey(Key);
            return Ok(Response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        [Route("file-upload")]
        public IActionResult FileUpload(IFormFile? file)
        {
            var response = _CMSService.FileUpload(file);
            return Ok(response);
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        [Route("get-files")]
        public IActionResult GetFile()
        {
            var response = _CMSService.GetFiles();
            return Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        [Route("delete-file")]
        public IActionResult DeleteFile(DeleteFile req)
        {
            var response = _CMSService.DeleteFile(req.Path);
            return Ok(response);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        [Route("get-videos")]
        public IActionResult GetVideo(string key)
        {
            var response = _CMSService.GetVideo(key);
            return Ok(response);
        }
    }
}
