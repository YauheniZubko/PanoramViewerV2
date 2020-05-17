using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanoramsViewer
{
    public struct STVector
    {
        public STVector(float x, float y)
        {
            Y = y;
            X = x;
        }
        public float Y { get; set; }
        public float X { get; set; }
    }
}
