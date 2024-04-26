using System.ComponentModel.DataAnnotations;

namespace OneClick.Infrastructure.Model
{
    public class Gallery
    {
        [Key]
        public int Id { get; set; }
        public string Path { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
    }

    public class GalleryRequest
    {
 
        public string? Path { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
    }
}
