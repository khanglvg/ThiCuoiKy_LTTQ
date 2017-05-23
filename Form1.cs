using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace thicuoiky
{
    public partial class Form1 : Form
    {
        string path;
        //FolderBrowserDialog folderBrowserDialog;
        OpenFileDialog ofd = new OpenFileDialog();
        bool draw = false;
        int pX = 1;
        int pY = 1;
        Bitmap drawing;


        public Form1()
        {
            InitializeComponent();
            drawing = new Bitmap(pictureBox1.Width,pictureBox1.Height,pictureBox1.CreateGraphics());
            Graphics.FromImage(drawing).Clear(colorDialog1.Color);
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ofd.Title = "Open File";
            ofd.InitialDirectory = @"C:\Users\Public\Pictures\Sample Pictures";
            ofd.Filter = "Image|*.jpg; *.jpeg; *.png; *.gif; *.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
                pictureBox1.Image = Image.FromFile(ofd.FileName);
            toolStripStatusLabel1.Text = ofd.FileName;
        }

        SaveFileDialog sfd = new SaveFileDialog();
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sfd.Filter = "Image|*.jpg; *.jpeg; *.png; *.gif; *.bmp";
            sfd.FilterIndex = 2;
            sfd.RestoreDirectory = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(sfd.FileName);
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            button1.BackColor = colorDialog1.Color;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (draw)
            {
                Graphics pic = Graphics.FromImage(drawing);
                Pen pen = new Pen(colorDialog1.Color, int.Parse(comboBox1.Text));
                pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;

                pic.DrawLine(pen, pX,pY, e.X, e.Y);
                pictureBox1.CreateGraphics().DrawLine(pen, pX, pY, e.X, e.Y);
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            draw = true;
            pX = e.X;
            pY = e.Y;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            draw = false;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
