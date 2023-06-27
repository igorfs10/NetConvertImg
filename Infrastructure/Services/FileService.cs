using ApplicationCore.Interfaces.Services;

namespace Infrastructure.Services
{
    public class FileService : IFileService
    {
        public byte[] GetFile(string path)
        {
            FileStream fs = new(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            // Create a byte array of file stream length
            byte[] ImageData = new byte[fs.Length];

            //Read block of bytes from stream into the byte array
            fs.Read(ImageData, 0, Convert.ToInt32(fs.Length));

            //Close the File Stream
            fs.Close();

            return ImageData;
        }

        public void SaveFile(string path, byte[] data)
        {
            string? outputFolder = Path.GetDirectoryName(path);
            if (outputFolder != null)
            {
                Directory.CreateDirectory(outputFolder);
                FileStream fs = new(path, FileMode.Create, FileAccess.ReadWrite);
                fs.Write(data);
                fs.Close();
            }
        }
    }
}
