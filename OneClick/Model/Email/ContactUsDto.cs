using System.ComponentModel.DataAnnotations;

namespace OneClick.Model.Email
{
	public class ContactUsDto
	{
		[Required]
		public string Name { get; set; } = string.Empty;
		public string MobileNo { get; set; } =string.Empty;
		[Required]
		public string Email { get; set; }=string.Empty;
		[Required]
		public string Comments { get; set; } = string.Empty;
		public string Address { get; set; } = string.Empty;
		public string CompanyName { get; set; } = string.Empty;
		public string Country_City{ get; set; } = string.Empty;
		public string Department { get; set; } = string.Empty;
		public string Company_Website { get; set; } = string.Empty;
		public string License { get; set; } = string.Empty;
	}
}
