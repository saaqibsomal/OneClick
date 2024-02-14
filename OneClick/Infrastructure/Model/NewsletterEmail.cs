using System.ComponentModel.DataAnnotations;

namespace OneClick.Infrastructure.Model
{
    public class NewsletterEmail
    {
        [Key]
        public int Id { get; set; }
        public string Emails { get; set; } = string.Empty;
    }
}
