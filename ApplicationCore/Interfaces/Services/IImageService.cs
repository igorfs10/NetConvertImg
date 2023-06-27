using ApplicationCore.Models;

namespace ApplicationCore.Interfaces.Services
{
    public interface IImageService
    {
        bool ConvertImage(List<AddedFile> files, string outPutPath, string type);
    }
}
