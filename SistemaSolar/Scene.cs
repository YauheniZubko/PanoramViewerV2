/* 
 *This code is property of Vasily Tserekh
 *if you like it you can visit my personal dev blog
 *http://vasilydev.blogspot.com
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace PanoramsViewer
{
    public class Scene
    {
        public Scene()
        {
            Camera = new Camera();
            Figure = new CubeFigure(CubeProjectionType.CrossProjection);
        }
        public string FileName { get; set; }

        public IFigure Figure { get; set; }
       

        public void CreateScene()
        {
            Figure.Create();
        }

        public Camera Camera { get; }
      

        public void DrawScene()
        {
            Figure.Paint(FileName);
        }
    }
}
