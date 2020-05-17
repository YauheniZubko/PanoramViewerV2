/* 
 *This code is property of Vasily Tserekh
 *if you like it you can visit my personal dev blog
 *http://vasilydev.blogspot.com
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ShadowEngine;
using ShadowEngine.OpenGL;
using SistemaSolar;
using Tao.OpenGl; 

namespace PanoramsViewer
{
    public partial class MainForm : Form
    {
        //handle del viewport
        uint hdc;
        private bool leftButtonDown = false;
        Scene scene = new Scene();
        private int lastX, lastY;
        private int horizontalMove = 0, verticalMove = 0;
        void InitScene()
        {
            hdc = (uint)pnlViewPort.Handle;
            string error = "";
           
            OpenGLControl.OpenGLInit(ref hdc, pnlViewPort.Width, pnlViewPort.Height, ref error);


            if (error != "")
            {
                MessageBox.Show(error);
            }

            scene.Camera.InitCamera();

            float[] materialAmbient = { 0.5F, 0.5F, 0.5F, 1.0F };
            float[] materialDiffuse = { 1f, 1f, 1f, 1.0f };
            float[] materialShininess = { 10.0F }; // brillo 
            float[] ambientLightPosition = { 0F, 0F, 0F, 1.0F }; // posicion
            float[] lightAmbient = { 0.85F, 0.85F, 0.85F, 0.0F }; // intensidad de la luz

            Lighting.MaterialAmbient = materialAmbient;
            Lighting.MaterialDiffuse = materialDiffuse;
            Lighting.MaterialShininess = materialShininess;
            Lighting.AmbientLightPosition = ambientLightPosition;
            Lighting.LightAmbient = lightAmbient;

            Lighting.SetupLighting();

            ContentManager.SetTextureList("texturas\\");
            ContentManager.LoadTextures();
            scene.CreateScene();
            Gl.glClearColor(0, 0, 0, 1);//red green blue alpha 
        }
        public MainForm()
        {
            InitializeComponent();
            InitScene();
        }

        private void tmrPaint_Tick(object sender, EventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            scene.Camera.Update(verticalMove,horizontalMove);
            horizontalMove = 0;
            verticalMove = 0;
            scene.DrawScene();
            Winapi.SwapBuffers(hdc);
            Gl.glFlush(); 
        }


        private void pnlViewPort_MouseDown(object sender, MouseEventArgs e)
        {
            if (!leftButtonDown&& e.Button == MouseButtons.Left)
            {
                leftButtonDown = true;
                lastX = e.X;
                lastY = e.Y;
            }
        }

        private void pnlViewPort_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftButtonDown && e.Button == MouseButtons.Left)
            {
                leftButtonDown = false;
            }
        }

        private void sphericToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            scene.Figure = new SphereFigure();
            scene.Figure.Create();
            Winapi.SwapBuffers(hdc);

            Gl.glFlush();
        }

        private void openProjectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var filePath = "";
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = ".\\";
                openFileDialog.Filter = "All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                }
            }
            try
            {
                File.Copy(filePath, Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), "texturas"), Path.GetFileName(filePath)));
            }
            catch (Exception)
            {

            }
            
            scene.FileName = Path.GetFileName(filePath);

        }

        private void crossProjectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            this.scene.Figure = new CubeFigure(CubeProjectionType.CrossProjection);
            scene.Figure.Create();
            Winapi.SwapBuffers(hdc);

            Gl.glFlush();

        }

        string[] paths = new string[6];

        private void separateShadesProjectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SeparateProjectionWindow form = new SeparateProjectionWindow(ref paths);
            form.Closing += OnClose;
            form.Show();
            
        }

        private void OnClose(object sender, CancelEventArgs e)
        {
            try
            {
                var result = PictureCombiner.CombineImages(paths.Select(t => new FileInfo(t)).ToArray());
                scene.FileName = Path.GetFileName(result.Item2);
                Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
                this.scene.Figure = new CubeFigure(CubeProjectionType.SeparateProjection){Textures = result.Item1 };
                scene.Figure.Create();
                Winapi.SwapBuffers(hdc);

                Gl.glFlush();
            }
            catch (Exception)
            {
                return;
            }
          
          
        }

        private void tprojectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            this.scene.Figure = new CubeFigure(CubeProjectionType.TProjection);
            scene.Figure.Create();
            Winapi.SwapBuffers(hdc);
            Gl.glFlush();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            this.pnlViewPort.Height = (int) (0.9 * this.Height);
            this.pnlViewPort.Width = (int)(0.9 * this.Width);
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close(); 
            }
            else if (e.KeyCode == Keys.F)
            {
                this.Location = new Point(0, 0);
                this.Width = SystemInformation.VirtualScreen.Width;
                this.Height = SystemInformation.VirtualScreen.Height;
            }
        }

        private void pnlViewPort_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftButtonDown)
            {
                verticalMove = e.Y - lastY;
                horizontalMove = e.X - lastX;
                lastX = e.X;
                lastY = e.Y;
            }
        }
    }
}
