using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class DataFile : IDataFile
    {
        public string FileDirectory { get; set; }
        public string FileName { get; set; }
        public string FullPath { get; set; }
        public IList<IGraphItem> Graph { get; set; }

        public DataFile(string filePath)
        {
            FullPath = filePath;
            FileName = Path.GetFileName(filePath);
            FileDirectory = Path.GetDirectoryName(filePath) == string.Empty ? AppDomain.CurrentDomain.BaseDirectory : Path.GetDirectoryName(filePath);
        }

    }
}
