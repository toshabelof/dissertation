using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearningToMaterial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        class PhotoToForm
        {
            string pathPhoto = String.Empty;
            Bitmap bitmap;

            public PhotoToForm(string path)
            {
                this.pathPhoto = path;
                bitmap = new Bitmap(path);
            }

            public void SetBitmap(Bitmap bitmap)
            {
                this.bitmap = bitmap;
            }

            public Bitmap GetBitmap()
            {
                return this.bitmap;
            }

            public void Resize(Size size)
            {
                this.bitmap = new Bitmap(bitmap, size);
            }
        }

        //Variables//

        Rectangle rectangle;
        Point Location_X1_Y1;
        Point Location_X2_Y2;
        bool Paint = false;
        string filePath = String.Empty;
        PhotoToForm photoToForm;
        Pen pen = new Pen(Color.Red, 2);

        //End_Variables//

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Photos|*.png;*.jpg|All files (*.*)|*.*";
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                filePath = openFileDialog.FileName;

                photoToForm = new PhotoToForm(filePath);
                photoToForm.Resize(new Size(this.pictureBox1.Width, this.pictureBox1.Height));
                pictureBox1.Image = photoToForm.GetBitmap();

            }
        }

        
        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (rectangle != null)
            {
                e.Graphics.DrawRectangle(pen, GetRect());
            }
        }

        private Rectangle GetRect()
        {
            rectangle = new Rectangle();
            rectangle.X = Math.Min(Location_X1_Y1.X, Location_X2_Y2.X);
            rectangle.Y = Math.Min(Location_X1_Y1.Y, Location_X2_Y2.Y);

            rectangle.Width = Math.Abs(Location_X1_Y1.X - Location_X2_Y2.X);
            rectangle.Height = Math.Abs(Location_X1_Y1.Y - Location_X2_Y2.Y);

            return rectangle;
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Paint = true;
            Location_X1_Y1 = e.Location;
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Paint)
            {
                Location_X2_Y2 = e.Location;
                Refresh();
            }
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (Paint)
            {
                Location_X2_Y2 = e.Location;
                Paint = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void PictureBox3_Paint(object sender, PaintEventArgs e)
        {
            if (rectangle != null && pictureBox1.Image != null)
            {
                e.Graphics.DrawImage(pictureBox1.Image, 0, 0, rectangle, GraphicsUnit.Pixel);
                pictureBox3.Invalidate();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }
    }
}
