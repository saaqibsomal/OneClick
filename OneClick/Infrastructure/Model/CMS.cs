using System.ComponentModel.DataAnnotations;

namespace OneClick.Infrastructure.Model
{
    public class CMS
    {
        [Key]
        public int Id { get; set; }
        public string Key { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool isActive { get; set; }
    }

    public class CMSResponse
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Path { get; set; }
        public byte[] Video { get; set; }
        public string Base64 { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool isActive { get; set; }
    }
}
