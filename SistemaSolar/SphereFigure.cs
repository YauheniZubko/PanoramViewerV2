using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShadowEngine;
using Tao.OpenGl;

namespace PanoramsViewer
{
    public class SphereFigure : IFigure
    {

        int list;
        float rotacion;
        public void Create()
        {
            Glu.GLUquadric quadratic = Glu.gluNewQuadric();
            Glu.gluQuadricNormals(quadratic, Glu.GLU_SMOOTH);
            Glu.gluQuadricTexture(quadratic, Gl.GL_TRUE);
            list = Gl.glGenLists(1);
            Gl.glNewList(list, Gl.GL_COMPILE);
            Gl.glPushMatrix();
            Gl.glRotated(270, 1, 0, 0);
            Glu.gluSphere(quadratic, 2, 32, 32);
            Gl.glPopMatrix();
            Gl.glEndList();
        }

        public void Paint(string fileName)
        {

            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, ContentManager.GetTextureByName(fileName));
            Gl.glPushMatrix();
            //rotacion += 0.05f; 
            //Gl.glRotatef(rotacion, 0, 1, 0);
            Gl.glCallList(list);
            Gl.glPopMatrix();
            Gl.glDisable(Gl.GL_TEXTURE_2D);
        }
    }
}
