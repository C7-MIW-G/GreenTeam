using Image = GreenTeam.Models.Image;

namespace GreenTeam.Utils
{
    public class ImageConverter
    {
        public Image CreateImage(IFormFile files)
        {
            string fileName = Path.GetFileName(files.FileName);

            string fileExtension = Path.GetExtension(fileName);

            string newFileName = string.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);

            byte[] bytes = ImageToByteArray(files);

            Image image = new Image()
            {
                Name = newFileName,
                FileType = fileExtension,
                Content = bytes,
                CreatedOn = DateTime.Now
            };

            return image;
        }


        public byte[] ImageToByteArray(IFormFile files)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                files.CopyTo(memoryStream);
                byte[] bytes = memoryStream.ToArray();
                return bytes;
            }
        }
    }
}
