/* 
 *This code is property of Vasily Tserekh
 *if you like it you can visit my personal dev blog
 *http://vasilydev.blogspot.com
*/

using System;
using System.Collections.Generic;
using System.Text;
using Tao.OpenGl;
using System.Drawing;
using System.IO;

namespace PanoramsViewer
{
    public class Camera
    {
        #region Private atributes

        public float eyex, eyey, eyez;
        static float centerx, centery, centerz;
        static float yaw, pitch;
        #endregion


        public void InitCamera()
        {
            eyex = 0f;
            eyey = 0f;
            eyez = 0f;
            centerx = 0;
            centery = 2;
            centerz = 0; 
            Look();
        }

        public void Look()
        {
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Glu.gluLookAt(eyex, eyey, eyez, centerx, centery, centerz, 0, 1, 0);
        }

        public void UpdateDirVector()
        {
            var k = Math.Cos((yaw) * 0.05)*0.5; //eje z
            var i = -Math.Sin((yaw) * 0.05) * 0.5; // eje x
            var j = Math.Sin((pitch) * 0.05); // eje y      
            
            centerz = (float)k; 
            centerx = (float)i;
            centery = (float)j;
         
        }
        public void Update(int verticalMove,int horizontalMove)
        {
            UpdateDirVector(); 
            yaw +=horizontalMove;
            pitch += verticalMove;
            Look();  
        }
    }
}
