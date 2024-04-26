using OneClick.Infrastructure.Db;
using OneClick.Infrastructure.Interface;
using OneClick.Infrastructure.Model;

namespace OneClick.Infrastructure.Repository
{
    public class GalleryRepository : IGalleryRepository
    {
        private OneClickContext _context;
        public GalleryRepository(OneClickContext context)
        {
            _context = context;
        }

        public void AddGallery(Gallery req)
        {
            _context.Gallery.Add(req);
            _context.SaveChanges();
        }

        public List<Gallery> GetGallery(Gallery req)
        {
            List<Gallery> Gal = new ();
            Gal = _context.Gallery.ToList();
            return Gal;
        }

    }
}
