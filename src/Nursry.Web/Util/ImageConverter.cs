using ImageMagick;
using System.IO;

namespace Nursry.Web.Util
{
    public class ImageConverter
    {
        public Stream ToWebP(Stream stream)
        {
            using (MagickImage mImage = new MagickImage(stream))
            {
                Stream webpStream = new MemoryStream();
                mImage.Format = MagickFormat.WebP;
                mImage.Write(webpStream);
                return webpStream;
            }
        }

        public Stream ToPNG(Stream stream)
        {
            using (MagickImage mImage = new MagickImage(stream))
            {
                Stream webpStream = new MemoryStream();
                mImage.Format = MagickFormat.Png00;
                mImage.Write(webpStream);
                return webpStream;
            }
        }
    }
}
