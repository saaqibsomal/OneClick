namespace OneClick.Models
{
    public class CMSRequest
    {
        public string? Base64 { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public bool isVideo { get; set; }
    }
}
