using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace Goomer.Web.Infrastructure.FileSystem
{
    public class FileSaver : IFileSaver
    {
        public void SaveFile(string path, byte[] data)
        {
            this.ResolvePath(path);
            path = HostingEnvironment.MapPath(path);
            using (var fs = new FileStream(path, FileMode.Create))
            {
                fs.Write(data, 0, data.Length);
                 fs.WriteAsync(data, 0, data.Length);
            }
        }

        public void SaveFile(string path, Stream stream)
        {
            byte[] bytesInStream = new byte[stream.Length];
            stream.Read(bytesInStream, 0, bytesInStream.Length);
             this.SaveFile(path, bytesInStream);
        }

        private void ResolvePath(string path)
        {
            var dir = Directory.Exists(path);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
