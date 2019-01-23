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
                //mImage.Settings.SetDefine(MagickFormat.WebP, "lossless", true);
                mImage.Write(webpStream);
                return webpStream;
            }
        }

        public Stream ToPNG(Stream stream)
        {
            using (MagickImage mImage = new MagickImage(stream))
            {
                Stream webpStream = new MemoryStream();
                mImage.Format = MagickFormat.Png;
                mImage.Write(webpStream);
                return webpStream;
            }
        }
    }
}
