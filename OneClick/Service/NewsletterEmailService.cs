using OneClick.Infrastructure.Interface;
using OneClick.Infrastructure.Model;
using OneClick.Model;
using OneClick.Models;
using OneClick.Service.Interface;
using OneClick.Utility;
using static OneClick.Models.Constant;

namespace OneClick.Service
{
    public class NewsletterEmailService : INewsletterEmailService
    {
        private INewsletterEmailRepository _newsletterEmailRepository;
        private ILogger<INewsletterEmailRepository> _logger;
        public string CLASSNAME = "UserService";
        public NewsletterEmailService(INewsletterEmailRepository newsletterEmailRepository, ILogger<INewsletterEmailRepository> logger)
        {
            _newsletterEmailRepository = newsletterEmailRepository;
            _logger = logger;
        }

        public ResponseMessage AddNewslater(NewsletterEmail newsletterEmail)
        {
            ResponseMessage response = new();
            try
            {

                _newsletterEmailRepository.AddNewslater(newsletterEmail);
                response.MessageCode = MessageCode.Success;
                response.MessageDescription = MessageDescription.Success;
            }
            catch (Exception ex)
            {
                _logger.LogError($"CLASSNAME: {CLASSNAME} METHOD: AddNewslater Message:{ex.Message} StackTrace:{ex.StackTrace}");
                response.MessageCode = MessageCode.Failure;
                response.MessageDescription = MessageDescription.Failure;
            }
            return response;
        }

        public List<NewsletterEmail> GetNewsletters()
        {
            try
            {
                return _newsletterEmailRepository.GetAll();
            }
            catch(Exception ex)
            {
                _logger.LogError($"CLASSNAME: {CLASSNAME} METHOD: GetNewsletters Message:{ex.Message} StackTrace:{ex.StackTrace}");
                return new List<NewsletterEmail>();
            }
            
        }
    }
}
