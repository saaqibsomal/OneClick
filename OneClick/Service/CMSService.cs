using OneClick.Common;
using OneClick.Infrastructure.Interface;
using OneClick.Infrastructure.Model;
using OneClick.Models;
using OneClick.Service.Interface;
using OneClick.Utility;
using static OneClick.Models.Constant;

namespace OneClick.Service
{
    public class CMSService: ICMSService
    {

        private ICMSRepository _Repository;
        private ILogger<CMSService> _logger;
        public string CLASSNAME = "CMSService";
        public CMSService(ICMSRepository Repository, ILogger<CMSService> logger)
        {
            _Repository = Repository;
            _logger = logger;
        }

        public ResponseMessage AddCMS(CMSRequest req, IFormFile file)
        {
            ResponseMessage response = new();
            try
            {
                

                CMS cMS = new CMS
                {
                    CreatedOn = DateTime.Now,
                    Desc = req.Desc,
                    Key = req.Key,
                    Name = req.Name,
                    Path = req.Path,
                    Title = req.Title,
                    isActive = true
                };


                _Repository.AddCMS(cMS);
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

        public ResponseMessage UpdateCMS(CMSRequest req, IFormFile file)
        {
            ResponseMessage response = new();
            try
            {
                string Path = Constants.Folder;
                CMS cMS = new CMS
                {
                    CreatedOn = DateTime.Now,
                    Desc = req.Desc,
                    Key = req.Key,
                    Name = req.Name,
                    Path = req.Path,
                    Title = req.Title,
                    isActive = req.isActive,
                    Id = req.id
                };

                _Repository.UpdateCMS(cMS);
                response.MessageCode = MessageCode.Success;
                response.MessageDescription = MessageDescription.Success;
            }
            catch (Exception ex)
            {
                _logger.LogError($"CLASSNAME: {CLASSNAME} METHOD: UpdateCMS Message:{ex.Message} StackTrace:{ex.StackTrace}");
                response.MessageCode = MessageCode.Failure;
                response.MessageDescription = MessageDescription.Failure;
            }
            return response;
        }

        public CMS GetCMSValue(string Key)
        {
            CMS response = new();
            try
            {
                response = _Repository.GetCMSByKey(Key);
            }
            catch (Exception ex)
            {
                _logger.LogError($"CLASSNAME: {CLASSNAME} METHOD: GetCMSValue Message:{ex.Message} StackTrace:{ex.StackTrace}");
            }
            return response;
        }

        public List<CMS> GetCMSList(string Key)
        {
            List<CMS> response = new();
            try
            {
                response = _Repository.GetCMSByKeyList(Key);


              //  string basePath = Directory.GetCurrentDirectory();
              //  string folderPath = Path.Combine(basePath, Constants.Folder);


              //  List<string> Files = CommonMethod.GetImagesAndVideosFromFolder(folderPath);

                foreach (var item in response)
                {

                    byte[] imageBytes = File.ReadAllBytes(item.Path);
                    // Convert the byte array to a Base64 string
                    string base64String = Convert.ToBase64String(imageBytes);

                    response.Add(new CMS { Name = item.Path, Path = base64String });
                }



            }
            catch (Exception ex)
            {
                _logger.LogError($"CLASSNAME: {CLASSNAME} METHOD: GetCMSByKeyList Message:{ex.Message} StackTrace:{ex.StackTrace}");
            }
            return response;
        }

        public bool DeletedByKey(string Key)
        {
            bool isSuccess = false;
            try
            {
                isSuccess = _Repository.DeletedCMSByKey(Key);
            }
            catch (Exception ex)
            {
                _logger.LogError($"CLASSNAME: {CLASSNAME} METHOD: DeletedByKey Message:{ex.Message} StackTrace:{ex.StackTrace}");
            }
            return isSuccess;
        }
    }
}
