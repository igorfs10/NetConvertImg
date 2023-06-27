using ApplicationCore.Interfaces.Services;
using ApplicationCore.Models;
using ImageMagick;

namespace ApplicationCore.Services
{
    public class ImageService : IImageService
    {
        private readonly IFileService _fileService;

        public ImageService(IFileService fileService)
        {
            _fileService = fileService;
        }

        public bool ConvertImage(List<AddedFile> files, string outPutPath, string type)
        {
            foreach (AddedFile item in files)
            {
                byte[] imageBytes = _fileService.GetFile(item.FilePath);
                using var image = new MagickImage(imageBytes);
                image.Strip();
                image.Quality = 100;
                image.Format = MagickFormat.Png;
                image.Resize(500, 500);

                string outPath = Path.Combine(outPutPath, "convert", $"{Path.GetFileNameWithoutExtension(item.FilePath)}.{image.Format.ToString().ToLower()}");

                _fileService.SaveFile(outPath, image.ToByteArray());
            }
            return true;
        }
    }
}
