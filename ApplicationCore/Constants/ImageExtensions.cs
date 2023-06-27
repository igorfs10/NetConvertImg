using ImageMagick;

namespace ApplicationCore.Constants
{
    public static class ImageExtensions
    {
        public static readonly Dictionary<string, MagickFormat> Extensions = new() {
            { ".png", MagickFormat.Png},
            { ".jpg", MagickFormat.Jpg},
            { ".bmp", MagickFormat.Bmp},
            { ".gif", MagickFormat.Gif},
            { ".webp", MagickFormat.WebP},
            { ".pdf", MagickFormat.Pdf},
            { ".tiff", MagickFormat.Tiff},
            { ".svg", MagickFormat.Svg},
            { ".ico", MagickFormat.Ico}
        };
    }
}
