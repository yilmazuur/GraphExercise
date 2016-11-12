using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataOperations
{
    public interface IGraphOperations
    {
        IDataFile inputFile { get; set; }
        string DrawGraphAsImage();
        void VisualizeChart(string graphPath);
    }
}
