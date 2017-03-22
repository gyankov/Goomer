using System.IO;

namespace Goomer.Web.Infrastructure.FileSystem
{
    public interface IFileSaver
    {
        void SaveFile(string path, byte[] data);

        void SaveFile(string path, Stream stream);
    }
}
