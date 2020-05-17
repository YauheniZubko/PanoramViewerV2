using System;
using System.Windows.Forms;

namespace PanoramsViewer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlViewPort = new System.Windows.Forms.Panel();
            this.tmrPaint = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openProjectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sphericToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cubeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tprojectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crossProjectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.separateShadesProjectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlViewPort
            // 
            this.pnlViewPort.AutoSize = true;
            this.pnlViewPort.Location = new System.Drawing.Point(12, 27);
            this.pnlViewPort.Name = "pnlViewPort";
            this.pnlViewPort.Size = new System.Drawing.Size(974, 694);
            this.pnlViewPort.TabIndex = 0;
            this.pnlViewPort.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.pnlViewPort.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlViewPort_MouseDown);
            this.pnlViewPort.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlViewPort_MouseMove);
            this.pnlViewPort.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlViewPort_MouseUp);
            // 
            // tmrPaint
            // 
            this.tmrPaint.Enabled = true;
            this.tmrPaint.Interval = 25;
            this.tmrPaint.Tick += new System.EventHandler(this.tmrPaint_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(995, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openProjectionToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openProjectionToolStripMenuItem
            // 
            this.openProjectionToolStripMenuItem.Name = "openProjectionToolStripMenuItem";
            this.openProjectionToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.openProjectionToolStripMenuItem.Text = "Open projection";
            this.openProjectionToolStripMenuItem.Click += new System.EventHandler(this.openProjectionToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // formToolStripMenuItem
            // 
            this.formToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sphericToolStripMenuItem,
            this.cubeToolStripMenuItem});
            this.formToolStripMenuItem.Name = "formToolStripMenuItem";
            this.formToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.formToolStripMenuItem.Text = "Form";
            // 
            // sphericToolStripMenuItem
            // 
            this.sphericToolStripMenuItem.Name = "sphericToolStripMenuItem";
            this.sphericToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.sphericToolStripMenuItem.Text = "Spheric";
            this.sphericToolStripMenuItem.Click += new System.EventHandler(this.sphericToolStripMenuItem_Click);
            // 
            // cubeToolStripMenuItem
            // 
            this.cubeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tprojectionToolStripMenuItem,
            this.crossProjectionToolStripMenuItem,
            this.separateShadesProjectionToolStripMenuItem});
            this.cubeToolStripMenuItem.Name = "cubeToolStripMenuItem";
            this.cubeToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.cubeToolStripMenuItem.Text = "CubeFigure";
            // 
            // tprojectionToolStripMenuItem
            // 
            this.tprojectionToolStripMenuItem.Name = "tprojectionToolStripMenuItem";
            this.tprojectionToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.tprojectionToolStripMenuItem.Text = "T-projection";
            this.tprojectionToolStripMenuItem.Click += new System.EventHandler(this.tprojectionToolStripMenuItem_Click);
            // 
            // crossProjectionToolStripMenuItem
            // 
            this.crossProjectionToolStripMenuItem.Name = "crossProjectionToolStripMenuItem";
            this.crossProjectionToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.crossProjectionToolStripMenuItem.Text = "Cross-projection";
            this.crossProjectionToolStripMenuItem.Click += new System.EventHandler(this.crossProjectionToolStripMenuItem_Click);
            // 
            // separateShadesProjectionToolStripMenuItem
            // 
            this.separateShadesProjectionToolStripMenuItem.Name = "separateShadesProjectionToolStripMenuItem";
            this.separateShadesProjectionToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.separateShadesProjectionToolStripMenuItem.Text = "Separate shades projection";
            this.separateShadesProjectionToolStripMenuItem.Click += new System.EventHandler(this.separateShadesProjectionToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(995, 687);
            this.Controls.Add(this.pnlViewPort);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Solar System";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                MessageBox.Show("Form.KeyPress: '" +
                    e.KeyChar.ToString() + "' pressed.");

                switch (e.KeyChar)
                {
                    case (char)49:
                    case (char)52:
                    case (char)55:
                        MessageBox.Show("Form.KeyPress: '" +
                            e.KeyChar.ToString() + "' consumed.");
                        e.Handled = true;
                        break;
                }
            }
        }


        #endregion

        private System. Windows.Forms.Panel pnlViewPort;
        private System.Windows.Forms.Timer tmrPaint;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sphericToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cubeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openProjectionToolStripMenuItem;
        private ToolStripMenuItem tprojectionToolStripMenuItem;
        private ToolStripMenuItem crossProjectionToolStripMenuItem;
        private ToolStripMenuItem separateShadesProjectionToolStripMenuItem;
    }
}

