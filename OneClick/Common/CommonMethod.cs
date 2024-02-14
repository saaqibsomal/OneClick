using OneClick.Model.Email;
using System.Net.Mail;
using System.Net;

namespace OneClick.Common
{
	public static class CommonMethod
	{

		public static string SendEmail(ContactUsDto req,string Email,string Password,string Host,int Port)
		{
			string Message = "";
			try
			{
				var fromAddress = new MailAddress(Email,"Click");
				var toAddress = new MailAddress(Email, req.Name);
				const string subject = "Contact Us";
				string Body = $@"
<!DOCTYPE html>
<html>
<head>
    <style>
        body {{
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
        }}
        .container {{
            max-width: 600px;
            margin: 0 auto;
            padding: 20px;
        }}
        h1 {{
            color: #333;
        }}
        table {{
            width: 100%;
            border-collapse: collapse;
            margin: 20px 0;
        }}
        th, td {{
            border: 1px solid #ddd;
            padding: 8px;
            text-align: left;
        }}
        th {{
            background-color: #f2f2f2;
        }}
    </style>
</head>
<body>
    <div class='container'>
        <h1>Feedback</h1>
        <table>
            <tr>
                <th>Name</th>
                <td>{req.Name}</td>
            </tr>
            <tr>
                <th>Company Name</th>
                <td>{req.CompanyName}</td>
            </tr>

            <tr>
                <th>Comments</th>
                <td>{req.Comments}</td>
            </tr>

            <tr>
                <th>Address</th>
                <td>{req.Address}</td>
            </tr>
            <tr>
                <th>Country / City</th>
                <td>{req.Country_City}</td>
            </tr>
            <tr>
                <th>Mobile No</th>
                <td>{req.MobileNo}</td>
            </tr>
            <tr>
                <th>Company Website</th>
                <td>{req.Company_Website}</td>
            </tr>
            <tr>
                <th>Department</th>
                <td>{req.Department}</td>
            </tr>
            <tr>
                <th>License</th>
                <td>{req.License}</td>
            </tr>
        </table>
    </div>
</body>
</html>
";


				var smtp = new SmtpClient
				{
					Host = Host,
					Port = Port,
					EnableSsl = true,
					DeliveryMethod = SmtpDeliveryMethod.Network,
					UseDefaultCredentials = false,
					Credentials = new NetworkCredential(fromAddress.Address, Password),
					 
				};
			
				using (var message = new MailMessage(fromAddress, toAddress)
				{
					Subject = subject,
					Body = Body
				})
				{
                    message.IsBodyHtml = true;
					smtp.Send(message);
				}
				return "Success";
			}
			catch(Exception ex)
			{
				Message = ex.Message;
				return Message;
			}
		}
	}
}
