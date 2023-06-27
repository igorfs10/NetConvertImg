namespace ApplicationCore.Interfaces.Services
{
    public interface IFileService
    {
        byte[] GetFile(string path);
        void SaveFile(string path, byte[] data);
    }
}
