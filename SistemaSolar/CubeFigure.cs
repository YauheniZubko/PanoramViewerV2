using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShadowEngine;
using SistemaSolar;
using Tao.OpenGl;

namespace PanoramsViewer
{
    public class CubeFigure : IFigure
    {
        private readonly CubeProjectionType _cubeProjectionType;
        int list;
        float rotacion;
        public CubeFigure(CubeProjectionType cubeProjectionType)
        {
            _cubeProjectionType = cubeProjectionType;
        }

        public CubeProjectionType CubeProjectionType
        {
            get { return _cubeProjectionType; }
        }

        private (STVector, STVector, STVector, STVector)[] textures;
        public (STVector, STVector, STVector, STVector)[] Textures
        {
            get
            {
                if (_cubeProjectionType == CubeProjectionType.SeparateProjection)
                {
                    return this.textures;
                }
               textures=new (STVector, STVector, STVector, STVector)[6];
                if (_cubeProjectionType == CubeProjectionType.CrossProjection)
                {
                    textures[0] = (new STVector(0.5f, 0), new STVector(0.5f, 1.0f / 3), new STVector(0.25f, 1.0f / 3), new STVector(0.25f, 0));
                    textures[1] = (new STVector(0.5f, 1), new STVector(0.5f, 2.0f / 3), new STVector(0.25f, 2.0f / 3), new STVector(0.25f, 1));
                }
                else if (_cubeProjectionType == CubeProjectionType.TProjection)
                {
                    textures[0] = (new STVector(0.25f, 0), new STVector(0.25f, 1.0f / 3), new STVector(0, 1.0f / 3), new STVector(0, 0));
                    textures[1] = (new STVector(0.25f, 1), new STVector(0.25f, 2.0f / 3), new STVector(0, 2.0f / 3), new STVector(0, 1));
                }
                textures[2] = (new STVector(0, 1.0f / 3), new STVector(0, 2.0f / 3), new STVector(0.25f, 2.0f / 3), new STVector(0.25f, 1.0f / 3));
                textures[3] = (new STVector(0.75f, 1.0f / 3), new STVector(0.75f, 2.0f / 3), new STVector(0.5f, 2.0f / 3), new STVector(0.5f, 1.0f / 3));
                textures[4] = (new STVector(0.75f, 1.0f / 3), new STVector(0.75f, 2.0f / 3), new STVector(1f, 2.0f / 3), new STVector(1f, 1.0f / 3));
                textures[5] = (new STVector(0.5f, 1.0f / 3), new STVector(0.5f, 2.0f / 3), new STVector(0.25f, 2.0f / 3), new STVector(0.25f, 1.0f / 3));

                return textures;

            }
            set
            {
                if (this._cubeProjectionType != CubeProjectionType.SeparateProjection)
                {
                    throw new Exception();
                }
                else
                {
                    this.textures = value;
                }
            }
        }

        public void InitCoordinates()
        {
            var shades = new (Vector3, Vector3, Vector3, Vector3)[6];
            if (_cubeProjectionType == CubeProjectionType.CrossProjection)
            {
                shades[0] = (new Vector3(-1, 1, -1), new Vector3(-1, -1, -1), new Vector3(1, -1, -1), new Vector3(1, 1, -1));
                shades[1] = (new Vector3(-1, 1, 1), new Vector3(-1, -1, 1), new Vector3(1, -1, 1), new Vector3(1, 1, 1));
            }
            else if (_cubeProjectionType == CubeProjectionType.TProjection)
            {
                shades[0] = (new Vector3(-1, -1, -1), new Vector3(1, -1, -1), new Vector3(1, 1, -1), new Vector3(-1, 1, -1));
                shades[1] = (new Vector3(-1, -1, 1), new Vector3(1, -1, 1), new Vector3(1, 1, 1), new Vector3(-1, 1, 1));
            }
            shades[2] = (new Vector3(1, 1, -1), new Vector3(1, 1, 1), new Vector3(1, -1, 1), new Vector3(1, -1, -1));
            shades[3] = (new Vector3(-1, 1, -1), new Vector3(-1, 1, 1), new Vector3(-1, -1, 1), new Vector3(-1, -1, -1));
            shades[4] = (new Vector3(-1, 1, -1), new Vector3(-1, 1, 1), new Vector3(1, 1, 1), new Vector3(1, 1, -1));
            shades[5] = (new Vector3(-1, -1, -1), new Vector3(-1, -1, 1), new Vector3(1, -1, 1), new Vector3(1, -1, -1));


            if (_cubeProjectionType == CubeProjectionType.SeparateProjection)
            {
                //PictureCombiner.CombineImages()
            }

            
            Gl.glBegin(Gl.GL_QUADS);
            for (int i = 0; i < 6; i++)
            {
                var s = shades[i];
                var t = Textures[i];
                Gl.glTexCoord2f(t.Item1.X, t.Item1.Y);
                Gl.glVertex3d(s.Item1.X, s.Item1.Y, s.Item1.Z);
                Gl.glTexCoord2f(t.Item2.X, t.Item2.Y);
                Gl.glVertex3d(s.Item2.X, s.Item2.Y, s.Item2.Z);
                Gl.glTexCoord2f(t.Item3.X, t.Item3.Y);
                Gl.glVertex3d(s.Item3.X, s.Item3.Y, s.Item3.Z);
                Gl.glTexCoord2f(t.Item4.X, t.Item4.Y);
                Gl.glVertex3d(s.Item4.X, s.Item4.Y, s.Item4.Z);
            }

            Gl.glEnd();
        }


        public void Create()
        {
            Glu.GLUquadric quadratic = Glu.gluNewQuadric();
            Glu.gluQuadricNormals(quadratic, Glu.GLU_SMOOTH);
            Glu.gluQuadricTexture(quadratic, Gl.GL_TRUE);

            list = Gl.glGenLists(1);
            Gl.glNewList(list, Gl.GL_COMPILE);
            Gl.glPushMatrix();
            Gl.glRotated(270, 1, 0, 0);
            //Gl.glDisable(Gl.GL_LIGHTING);
            InitCoordinates();

            //Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glPopMatrix();
            Gl.glEndList();
        }

        public void Paint(string fileName)
        {
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, ContentManager.GetTextureByName(fileName));
            Gl.glPushMatrix();
            //rotacion += 2f; 
            Gl.glRotatef(rotacion, 1, 0, 0);
            Gl.glCallList(list);
            Gl.glPopMatrix();
            Gl.glDisable(Gl.GL_TEXTURE_2D);
        }
    }
}
