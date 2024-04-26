using OneClick.Infrastructure.Model;

namespace OneClick.Infrastructure.Interface
{
    public interface IGalleryRepository
    {
        void AddGallery(Gallery req);
        List<Gallery> GetGallery();
    }
}
