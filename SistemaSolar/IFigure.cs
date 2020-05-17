using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanoramsViewer
{
    public interface IFigure
    {
        void Create();
        void Paint(string fileName);

    }
}
