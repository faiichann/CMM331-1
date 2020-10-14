using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMM331Windowfrom
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }
        private void imageToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = bmp;
                pictureBox2.Image = bmp;
            }

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image.Save(saveFileDialog1.FileName);
            }
        }

        private void grayScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmpNew =new Bitmap(bmp.Width,bmp.Height);
            for (int y=0; y<bmp.Height;y++)
            {
                for(int x=0;x<bmp.Width;x++)
                {
                    Color c = bmp.GetPixel(x, y);
                    int red = c.R;
                    int green = c.G;
                    int blue = c.B;
                    float gray = (float)(red + green + blue) / 3.0f;
                    int igray = (int)gray;
                    Color cNew = Color.FromArgb(igray,igray,igray);
                    bmpNew.SetPixel(x, y, cNew);
                }
            }
            pictureBox2.Image = bmpNew;
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmpNew = new Bitmap(bmp.Width, bmp.Height);
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color c = bmp.GetPixel(x, y);
                    int red = c.R;
                    Color cNew = Color.FromArgb(c.R, 0,0);
                    bmpNew.SetPixel(x, y, cNew);
                }
            }
            pictureBox2.Image = bmpNew;
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmpNew = new Bitmap(bmp.Width, bmp.Height);
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color c = bmp.GetPixel(x, y);
                    int green = c.G;
                    Color cNew = Color.FromArgb(0, c.G, 0);
                    bmpNew.SetPixel(x, y, cNew);
                }
            }
            pictureBox2.Image = bmpNew;

        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmpNew = new Bitmap(bmp.Width, bmp.Height);
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color c = bmp.GetPixel(x, y);
                    int blue = c.B;
                    Color cNew = Color.FromArgb(0, 0, c.B);
                    bmpNew.SetPixel(x, y, cNew);
                }
            }
            pictureBox2.Image = bmpNew;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            int trabaVal = trackBar1.Value;
            for(int y=0;y<bmp.Width;y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color c = bmp.GetPixel(x, y);
                    int red = c.R+trabaVal;
                    int green = c.G + trabaVal;
                    int blue = c.B + trabaVal;
                    red = (red > 255) ? 255 : (red < 0) ? 0 : red;
                    green = (green > 255) ? 255 : (green < 0) ? 0 : green;
                    blue = (blue > 255) ? 255 : (blue < 0) ? 0 : blue;
                    Color c2 = Color.FromArgb(red, green, blue);
                    bmp2.SetPixel(x, y, c2);

                }
            }
            pictureBox2.Image = bmp2;
        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(pictureBox1.Image);

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    Color color = bitmap.GetPixel(x, y);
                    int red = (int)(color.R*0.393+color.G*0.769+color.B*0.189);
                    int green = (int)(color.R * 0.349 + color.G * 0.686 + color.B * 0.168);
                    int blue = (int)(color.R * 0.272 + color.G * 0.534 + color.B * 0.131);
                    red = Math.Max(0, Math.Min(red, 255));
                    green = Math.Max(0, Math.Min(green, 255));
                    blue = Math.Max(0, Math.Min(blue, 255));
                    Color newColor = Color.FromArgb(red, green, blue);
                    bitmap.SetPixel(x, y, newColor);

                }
            }
            pictureBox2.Image = bitmap;

        }

        private void inverseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(pictureBox1.Image);

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    Color color = bitmap.GetPixel(x, y);
                    int red = 255-color.R;
                    int green = 255 - color.G;
                    int blue = 255 - color.B;
                    red = Math.Max(0, Math.Min(red, 255));
                    green = Math.Max(0, Math.Min(green, 255));
                    blue = Math.Max(0, Math.Min(blue, 255));
                    Color newColor = Color.FromArgb(red, green, blue);
                    bitmap.SetPixel(x, y, newColor);

                }
            }
            pictureBox2.Image = bitmap;

        }
    }
}
