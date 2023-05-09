using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PK_10_EdytorIkon_Baza
{
    public partial class Form1 : Form
    {
        const int pixelSize = 20;
        DBDataContext db;
        public Form1()
        {
            InitializeComponent();

            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            db = new DBDataContext();

            loadPictures();
        }

        private void loadPictures()
        {
            listBoxPictures.Items.Clear();
            listBoxPictures.Items.AddRange(db.Pictures.ToArray());
        }

        private void buttonAddNew_Click(object sender, EventArgs e)
        {
            Picture p = new Picture()
            {
                Name = textBoxName.Text,
                Width = (Int32)numericUpDownWidth.Value,
                Height = (Int32)numericUpDownHeight.Value
            };
            db.Pictures.InsertOnSubmit(p);
            db.SubmitChanges();
            loadPictures();
            listBoxPictures.SelectedItem = p;


            textBoxName.Text = "";
            numericUpDownWidth.Value = 5;
            numericUpDownHeight.Value = 5;
        }

        private void listBoxPictures_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxPictures.SelectedItem != null &&
                listBoxPictures.SelectedItem is Picture)
            {
                Picture currentPicture = listBoxPictures.SelectedItem as Picture;
                pictureBox1.Image = preparePicture(currentPicture, pixelSize, true);
            }
        }

        private Image preparePicture(Picture currentPicture, int scale, bool grid)
        {
            Image image = new Bitmap(currentPicture.Width * scale + 1, currentPicture.Height * scale + 1);
            Graphics g = Graphics.FromImage(image);

            g.Clear(Color.White);

            foreach (Pixel pixel in currentPicture.Pixels)
            {
                g.FillRectangle(new SolidBrush(Color.FromArgb(pixel.Color)),
                                    pixel.PosX * scale,
                                    pixel.PosY * scale,
                                    scale,
                                    scale);
            }
            if (grid)
            {
                for (int x = 0; x < currentPicture.Width; x++)
                {
                    for (int y = 0; y < currentPicture.Height; y++)
                    {
                        g.DrawRectangle(new Pen(Color.Gray),
                                        x * scale,
                                        y * scale,
                                        scale,
                                        scale);
                    }
                }
            }
            return image;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (listBoxPictures.SelectedItem != null &&
                listBoxPictures.SelectedItem is Picture &&
                e.Button == MouseButtons.Left)
            {
                Picture currentPicture = listBoxPictures.SelectedItem as Picture;

                //próba znalezienia Pixela o klikniętych współrzędnych
                Pixel pix = currentPicture.Pixels.SingleOrDefault(tmp => tmp.PosX == e.X / pixelSize && tmp.PosY == e.Y / pixelSize);

                //nowy Pixel jeśli nie ma takich współrzędnych w bazie
                if (pix == null)
                {
                    pix = new Pixel()
                    {
                        PosX = e.X / pixelSize,
                        PosY = e.Y / pixelSize
                    };
                    currentPicture.Pixels.Add(pix);
                }
                pix.Color = buttonColor.BackColor.ToArgb();
                db.SubmitChanges();

                pictureBox1.Image = preparePicture(currentPicture, pixelSize, true);
            }
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.Color = buttonColor.BackColor;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                buttonColor.BackColor = cd.Color;
            }
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            if (listBoxPictures.SelectedItem != null &&
                listBoxPictures.SelectedItem is Picture)
            {
                Picture currentPicture = listBoxPictures.SelectedItem as Picture;


                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Ikona|*.ico";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Image i = preparePicture(currentPicture, 1, false);
                    i.Save(sfd.FileName);
                }
            }
        }
    }
}
/*
-- Nazwa tabeli
-- Typy atrybutów i NOT NULLL
-- IDENTITY
-- klucze obce
CREATE TABLE [dbo].[Picture]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Width] INT NOT NULL, 
    [Height] INT NOT NULL
)
CREATE TABLE [dbo].[Pixel]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [PosX] INT NOT NULL, 
    [PosY] INT NOT NULL, 
    [Color] INT NOT NULL, 
    [PictureId] INT NOT NULL, 
    CONSTRAINT [FK_Pixel_Piceture] FOREIGN KEY ([PictureId]) REFERENCES [Picture]([Id])
)

*/