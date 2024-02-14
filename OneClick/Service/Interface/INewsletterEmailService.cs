using OneClick.Infrastructure.Model;
using OneClick.Models;

namespace OneClick.Service.Interface
{
    public interface INewsletterEmailService
    {
        ResponseMessage AddNewslater(NewsletterEmail newsletterEmail);
        List<NewsletterEmail> GetNewsletters();
    }
}
