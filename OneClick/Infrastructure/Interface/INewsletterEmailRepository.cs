using OneClick.Infrastructure.Model;

namespace OneClick.Infrastructure.Interface
{
    public interface INewsletterEmailRepository
    {
        void AddNewslater(NewsletterEmail newsletterEmail);
        List<NewsletterEmail> GetAll();
    }
}
