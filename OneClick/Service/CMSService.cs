using OneClick.Infrastructure.Interface;
using OneClick.Infrastructure.Model;
using OneClick.Infrastructure.Repository;
using OneClick.Models;
using OneClick.Service.Interface;
using static OneClick.Models.Constant;

namespace OneClick.Service
{
    public class CMSService: ICMSService
    {

        private ICSMRepository _Repository;
        private ILogger<CMSService> _logger;
        public string CLASSNAME = "HomePageService";
        public CMSService(ICSMRepository Repository, ILogger<CMSService> logger)
        {
            _Repository = Repository;
            _logger = logger;
        }

        public ResponseMessage AddCMS(CMS cms)
        {
            ResponseMessage response = new();
            try
            {
                _Repository.AddCMS(cms);
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

        public ResponseMessage UpdateCMS(CMS cms)
        {
            ResponseMessage response = new();
            try
            {
                _Repository.UpdateCMS(cms);
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
