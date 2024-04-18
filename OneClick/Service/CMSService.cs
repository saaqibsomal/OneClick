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
                string Path = Constants.Folder + req.Key;
                if(!Directory.Exists(Path))
                {
                    Directory.CreateDirectory(Path);
                }
                if (req.isVideo)
                {
                    if (file == null || file.Length == 0)
                    {
                        response.MessageCode = "File is not selected or empty.";
                        response.MessageDescription = MessageDescription.Success;
                    }

                    var filePath = Path + "/" + req.Name;
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        file?.CopyTo(stream);
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(req.Base64))
                    {
                        Helper.SaveImage(req.Base64, Path + "/" + req.Name);
                    }
                }

                CMS cMS = new CMS
                {
                    CreatedOn = DateTime.Now,
                    Desc = req.Desc,
                    Key = req.Key,
                    Name = req.Name,
                    Path = Path,
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
                string Path = Constants.Folder + req.Key;
                if (!Directory.Exists(Path))
                {
                    Directory.CreateDirectory(Path);
                }
                if(req.isVideo)
                {
                    if (file == null || file.Length == 0)
                    {
                        response.MessageCode = "File is not selected or empty.";
                        response.MessageDescription = MessageDescription.Success;
                    }

                    var filePath = Path + "/" + req.Name;
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                         file?.CopyTo(stream);
                    }

                }
                else
                {
                    if (!string.IsNullOrEmpty(req.Base64))
                    {
                        Helper.SaveImage(req.Base64, Path + "/" + req.Name);
                    }
                }
               
                CMS cMS = new CMS
                {
                    CreatedOn = DateTime.Now,
                    Desc = req.Desc,
                    Key = req.Key,
                    Name = req.Name,
                    Path = Path,
                    Title = req.Title,
                    isActive = true
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
            }
            catch (Exception ex)
            {
                _logger.LogError($"CLASSNAME: {CLASSNAME} METHOD: GetCMSByKeyList Message:{ex.Message} StackTrace:{ex.StackTrace}");
            }
            return response;
        }

    }
}
