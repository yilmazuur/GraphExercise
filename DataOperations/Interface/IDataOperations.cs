using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataOperations
{
    public delegate void DrawGraphicEventHandler();

    public interface IDataOperations
    {
        IDataFile inputFile { get; set; }
        void PopulateValues();
        event DrawGraphicEventHandler DrawGraphic;
    }
}
