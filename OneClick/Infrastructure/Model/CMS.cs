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
        public string CreatedOn { get; set; }
        public string isActive { get; set; }


        //public string Header_Slider_Path { get; set; } = string.Empty;
        //public string Header_Slider_Name { get; set; } = string.Empty;
        //public string Header_Slider_Desc { get; set; } = string.Empty;

        //public string Click_Header_Logo { get; set; } = string.Empty;
        //public string Header_Logo { get; set; } = string.Empty;

        //public string[] Highlights_Path { get; set; }
        //public string[] Highlights_Name { get; set; }
        //public string[] Highlights_Desc { get; set; }

        //public string Video_Path { get; set; } = string.Empty;

        //public string[] Messages_Path { get; set; }
        //public string[] Messages_Name { get; set; }
        //public string[] Messages_Desc { get; set; }
        //public string[] Messages_Slider { get; set; }
    }
}
