using NuGet.Protocol.Core.Types;
using OneClick.Infrastructure.Interface;
using OneClick.Infrastructure.Model;
using OneClick.Models;
using OneClick.Service.Interface;
using OneClick.Utility;
using static OneClick.Models.Constant;

namespace OneClick.Service
{
    public class GalleryService : IGalleryService
    {
        private IGalleryRepository _galleryRepository;
        private ILogger<UserService> _logger;
        public string CLASSNAME = "UserService";
        public GalleryService(IGalleryRepository galleryRepository, ILogger<UserService> logger)
        {
            _galleryRepository = galleryRepository;
            _logger = logger;
        }

        public ResponseMessage AddGallery(GalleryRequest req, IFormFile file)
        {
            ResponseMessage response = new();
            try
            {
                string Path = Constants.Folder;
                if (!Directory.Exists(Path))
                {
                    Directory.CreateDirectory(Path);
                }
                 
                    if (file == null || file.Length == 0)
                    {
                        response.MessageCode = "File is not selected or empty.";
                        response.MessageDescription = MessageDescription.Success;
                    }

                    var filePath = Path + "/" + req.FileName;
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        file?.CopyTo(stream);
                    }

                Gallery gel = new Gallery();
                gel.Path = req.Path;
                gel.FileName = req.FileName;
                gel.FileType = req.FileType;
                _galleryRepository.AddGallery(gel);
                response.MessageCode = MessageCode.Success;
                response.MessageDescription = MessageDescription.Success;
            }
            catch (Exception ex)
            {
                _logger.LogError($"CLASSNAME: {CLASSNAME} METHOD: AddCMS Message:{ex.Message} StackTrace:{ex.StackTrace}");
                response.MessageCode = MessageCode.Failure;
                response.MessageDescription = MessageDescription.Failure;
            }
            return response;
        }
    }
}
