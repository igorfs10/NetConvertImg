﻿using ApplicationCore.Constants;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Models;
using ImageMagick;

namespace ApplicationCore.Services
{
    public class ImageService(IFileService fileService) : IImageService
    {
        public bool ConvertImage(List<AddedFile> files, string outPutPath, string type, int width, int height)
        {
            foreach (AddedFile item in files)
            {
                try
                {
                    byte[] imageBytes = fileService.GetFile(item.FilePath);
                    using var image = new MagickImage(imageBytes);
                    image.Strip();
                    image.Quality = 100;
                    image.Format = ImageExtensions.Extensions[type];
                    MagickGeometry size = new(width, height)
                    {
                        IgnoreAspectRatio = true
                    };
                    image.Resize(size);

                    string outPath = Path.Combine(outPutPath, $"{Path.GetFileNameWithoutExtension(item.FilePath)}.{image.Format.ToString().ToLower()}");

                    fileService.SaveFile(outPath, image.ToByteArray());
                    item.Status = "Success";
                }
                catch (Exception ex)
                {
                    item.Status = ex.Message;
                }
            }
            return true;
        }
    }
}
