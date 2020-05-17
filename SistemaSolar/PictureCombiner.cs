using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PanoramsViewer;

namespace SistemaSolar
{
    static class PictureCombiner
    {

        public static ((STVector, STVector, STVector, STVector)[], string) CombineImages(FileInfo[] files)
        {
            //change the location to store the final image.
            var name = $"111.jpg";
            string finalImage = Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), "texturas"), name);
            var imageHeights = new List<int>();
            int nIndex = 0;
            var curWidth = 0;
            int totalHeight = files.Max(t => Image.FromFile(t.FullName).Height);
            var list = new List<(STVector, STVector, STVector, STVector)>();
            var totalWidth = files.Select(t => Image.FromFile(t.FullName)).Sum(t => t.Width);
            foreach (FileInfo file in files)
            {
                Image img = Image.FromFile(file.FullName);
                imageHeights.Add(img.Height);
                
                var point1 = new STVector((float)curWidth / totalWidth, 0);
                var point2 = new STVector((float)(curWidth + img.Width) / totalWidth, 0);
                var point3 = new STVector((float)(curWidth + img.Width) / totalWidth, (float)img.Height / totalHeight);
                var point4 = new STVector((float)curWidth / totalWidth, (float)img.Height / totalHeight);
                curWidth += img.Width;
                img.Dispose();
               

                list.Add((point1, point2, point3, point4));
             
            }
            imageHeights.Sort();
            
            Bitmap img3 = new Bitmap(totalWidth, totalHeight);
            Graphics g = Graphics.FromImage(img3);
            g.Clear(SystemColors.AppWorkspace);
            foreach (FileInfo file in files)
            {
                Image img = Image.FromFile(file.FullName);
                if (nIndex == 0)
                {
                    g.DrawImage(img, new Point(0, 0));
                    nIndex++;
                    totalWidth = img.Width;

                }
                else
                {
                    g.DrawImage(img, new Point(totalWidth, 0));
                    totalWidth += img.Width;
                }
                img.Dispose();
            }
            g.Dispose();
            img3.Save(finalImage, System.Drawing.Imaging.ImageFormat.Jpeg);
            img3.Dispose();
            return  (list.ToArray(), name);
        }
    }
}
