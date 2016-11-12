using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class GraphItem : IGraphItem
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public int Value { get; set; }
        public GraphItem(string name, string color, string value)
        {
            Name = name;
            Color = color;
            Value = 0;
            int tempVal;
            if (Int32.TryParse(value, out tempVal)) //if value is not convertiable to integer then we put 0 for that.
            {
                Value = tempVal;
            }
        }

    }
}
