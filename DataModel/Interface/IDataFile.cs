using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public interface IDataFile
    {
        string FileDirectory { get; set; }
        string FileName { get; set; }
        string FullPath { get; set; }
        IList<IGraphItem> Graph { get; set; }
    }
}
