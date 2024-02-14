using OneClick.Infrastructure.Db;
using OneClick.Infrastructure.Interface;
using OneClick.Infrastructure.Model;

namespace OneClick.Infrastructure.Repository
{
    public class NewsletterEmailRepository : INewsletterEmailRepository
    {
        private OneClickContext _context;
        public NewsletterEmailRepository(OneClickContext context)
        {
            _context = context;
        }

        public void AddNewslater(NewsletterEmail newsletterEmail)
        {
            _context.NewsletterEmail.Add(newsletterEmail);
            _context.SaveChanges();
        }

        public List<NewsletterEmail> GetAll()
        {
          return  _context.NewsletterEmail.ToList();
        }
    }
}
