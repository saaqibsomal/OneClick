using NuGet.Protocol.Core.Types;
using OneClick.Common;
using OneClick.Infrastructure.Interface;
using OneClick.Infrastructure.Model;
using OneClick.Infrastructure.Repository;
using OneClick.Models;
using OneClick.Service.Interface;
using OneClick.Utility;
using System.Collections.Generic;
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
           
                string basePath = Directory.GetCurrentDirectory();
                string folderPath = Path.Combine(basePath, Constants.Folder);
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                if (file == null || file.Length == 0)
                {
                    response.MessageCode = "File is not selected or empty.";
                    response.MessageDescription = MessageDescription.Success;
                }
                string filePath = Path.Combine(folderPath, file.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file?.CopyTo(stream);
                }
                Gallery gel = new Gallery();
                gel.Path = filePath;
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

        public ResponseMessage AddVideo(GalleryRequest req, IFormFile file)
        {
            ResponseMessage response = new();
            try
            {

  
                if (!Directory.Exists(Constants.VideoFile))
                {
                    Directory.CreateDirectory(Constants.VideoFile);
                }

                if (file == null || file.Length == 0)
                {
                    response.MessageCode = "File is not selected or empty.";
                    response.MessageDescription = MessageDescription.Success;
                }
                string filePath = Path.Combine(Constants.VideoFile, file.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file?.CopyTo(stream);
                }
                Gallery gel = new Gallery();
                gel.Path = filePath;
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

        public List<ImagesResponse> GetGallery()
        {
            List <ImagesResponse> res = new List<ImagesResponse>();
            try
            {
                string basePath = Directory.GetCurrentDirectory();
                string folderPath = Path.Combine(basePath, Constants.Folder);


                List<string> Files = CommonMethod.GetImagesAndVideosFromFolder(folderPath);

                foreach (var item in Files)
                {
                  

                    byte[] imageBytes = File.ReadAllBytes(item);
                    // Convert the byte array to a Base64 string
                    string base64String = Convert.ToBase64String(imageBytes);

                    res.Add(new ImagesResponse { FileName = item,Base64 = base64String,Path= item });
                }


                return res;
            }
            catch (Exception ex)
            {
                _logger.LogError($"CLASSNAME: {CLASSNAME} METHOD: GetNewsletters Message:{ex.Message} StackTrace:{ex.StackTrace}");
                return res;
            }

        }


        public List<ImagesResponse> GetVideo()
        {
            List<ImagesResponse> res = new List<ImagesResponse>();
            try
            {
          


                List<string> Files = CommonMethod.GetVideoFromFolder(Constants.VideoFile);

                foreach (var item in Files)
                {
                    byte[] imageBytes = File.ReadAllBytes(item);
                    // Convert the byte array to a Base64 string
                    string base64String = Convert.ToBase64String(imageBytes);
                    res.Add(new ImagesResponse { FileName = item, Path = item, Base64 = base64String });
                }


                return res;
            }
            catch (Exception ex)
            {
                _logger.LogError($"CLASSNAME: {CLASSNAME} METHOD: GetNewsletters Message:{ex.Message} StackTrace:{ex.StackTrace}");
                return res;
            }

        }

        static List<string> GetImagesAndVideosFromFolder(string folderPath)
        {
            // Define a list of image and video file extensions
            List<string> validExtensions = new List<string>
        {
            ".jpg", ".jpeg", ".png", ".bmp", ".gif", // Image file extensions
            ".mp4", ".avi", ".mkv", ".mov", ".wmv"  // Video file extensions
        };

            // Create a list to store the file paths
            List<string> files = new List<string>();

            // Get all files in the specified folder
            string[] allFiles = Directory.GetFiles(folderPath);

            // Filter files based on valid extensions
            foreach (string file in allFiles)
            {
                string extension = Path.GetExtension(file).ToLower();
                if (validExtensions.Contains(extension))
                {
                    files.Add(file);
                }
            }

            return files;
        }
    }
}
