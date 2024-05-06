namespace OneClick.Models
{
    public class CMSRequest
    {
        public int id { get; set; }
        public string? Path { get; set; }
        public string? Base64 { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public bool isVideo { get; set; }
        public bool isActive { get; set; }
    }


    public class FileUploadRequest
    {
        public string FilePath { get; set; }
    }
}
