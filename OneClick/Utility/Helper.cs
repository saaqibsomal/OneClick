using System.Drawing;
using System.Drawing.Imaging;
using System.Security.Cryptography;
using System.Text;

namespace OneClick.Utility
{
    public class Helper
    {
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute hash from the password bytes
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert byte array to a hexadecimal string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static void SetFolder(string path)
        {
            Constants.Folder = path.Split(',')[0];
            Constants.FileUploadFolder = path.Split(',')[1];
        }  
        
        public static void SetFolderVideo(string path)
        {
            Constants.VideoFile = path;
          
        }

        public static bool SaveImage(string Base64,string Path)
        {
            // Your base64 string representing the image
            string base64String = Base64;

            // Convert the base64 string to bytes
            byte[] imageBytes = Convert.FromBase64String(base64String);

            // Create a MemoryStream from the bytes
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                // Create an Image from the MemoryStream
                Image image = Image.FromStream(ms);

                // Define the path to save the image
                string imagePath = Path;

                // Save the image to the specified path
                image.Save(imagePath, ImageFormat.Jpeg);
            }
            return true;
        }


    }
}
