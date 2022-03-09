﻿namespace GreenTeam.Utils
{
    public class ImageConverter
    {

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
