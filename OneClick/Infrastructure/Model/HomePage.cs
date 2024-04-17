using System.ComponentModel.DataAnnotations;

namespace OneClick.Infrastructure.Model
{
    public class HomePage
    {
        [Key]
        public int Id { get; set; }
        public string Header_Slider_Path { get; set; } = string.Empty;
        public string Click_Header_Logo { get; set; } = string.Empty;
        public string Header_Logo { get; set; } = string.Empty;
        public string Highlights { get; set; } = string.Empty;
        public string Video_Path { get; set; } = string.Empty;
    }
}
