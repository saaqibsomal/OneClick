namespace OneClick.Models
{
    public class CmsResponse
    {
        public List<CmsDto> data { get; set; } =new List<CmsDto>();
    }

    public class CmsDto
    {
        public byte[] PDF { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
    }
}
