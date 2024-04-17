using Microsoft.EntityFrameworkCore;
using OneClick.Infrastructure.Model;

namespace OneClick.Infrastructure.Db
{
    public class OneClickContext : DbContext
    {
        public OneClickContext(DbContextOptions<OneClickContext> options) : base(options)
        {
        }

        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<NewsletterEmail> NewsletterEmail { get; set; }
        public virtual DbSet<HomePage> HomePage { get; set; }

        // Add other DbSet properties for your other entities if needed

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
            .HasKey(u => u.Id);


            modelBuilder.Entity<NewsletterEmail>()
            .HasKey(u => u.Id);  
            
            modelBuilder.Entity<HomePage>()
            .HasKey(u => u.Id);
        }
       
    }
}
