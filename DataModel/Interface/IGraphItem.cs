using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public interface IGraphItem
    {
        string Name { get; set; }
        string Color { get; set; }
        int Value { get; set; }
    }
}
