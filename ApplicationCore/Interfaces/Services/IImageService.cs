﻿using ApplicationCore.Models;

namespace ApplicationCore.Interfaces.Services
{
    public interface IImageService
    {
        public bool ConvertImage(List<AddedFile> files, string outPutPath, string type, int width, int height);
    }
}
