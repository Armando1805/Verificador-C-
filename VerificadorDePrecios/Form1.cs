using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VerificadorDePrecios
{
    public partial class Form1 : Form
    {
        string Codigo = "";
        string Ruta = "C:\\Users\\Armando\\Desktop\\verificadordeprecioscsharp\\VerificadorDePrecios\\Resources";
        string [,]Productos =
        {
            {"1",   "Call Of Duty", "59.20", "callofduty.jpg"},
            {"2",   "Crash Bandicoot", "60.70", "crash.jpg"},
            {"3",   "Destiny", "49.44", "destiny.jpg"},
            {"4",   "Dragon Ball Kakarot", "69.70", "Dragonball.jpg"},
            {"5",   "Final Fantasy 14", "57.40", "ff14.jpg"},
            {"6",   "God Of War Ragnarok", "79.00", "GODR.jpg"},
            {"7",   "Resident Evil 3", "59.00", "re3.jpg"},
            {"8",   "Resident Evil 8", "69.00", "residen8.jpg"},
            {"9",   "Tekken 7", "59.00", "tekken.jpg"},
            {"10",  "Uncharted 4", "59.56", "uncharted.jpg"}
        };
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Location = new Point(this.Width / 2 - label1.Width / 2, 50);
            
            label2.Location = new Point(this.Width / 2 - label2.Width / 2, this.Height - label2.Height - 50);
            label3.Visible = false; 
            label4.Visible = false;
            Centrar_Imagen();
        }

        private void Centrar_Imagen()
        {
            pictureBox1.Location = new Point(this.Width / 2 - pictureBox1.Width / 2, this.Height / 2 - pictureBox1.Height / 2);
        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar != 13)
            {
                Codigo += e.KeyChar;
                

            }
            else
            {
                timer1.Enabled = false;
                timer1.Start();
                timer1.Enabled = true;
             
                //MessageBox.Show("Código " + Codigo);
                for (int i = 0; i < 10; i++)
                {
                    if (Codigo == Productos[i, 0])
                    {

                        label2.Visible = false;
                        label3.Text = Productos[i, 1];
                        label3.Visible = true;
                        label4.Text = "$ " + Productos[i, 2];
                        label4.Visible = true;
                        label3.Location = new Point(this.Width / 2 - label3.Width / 2, (this.Height - label3.Height*2)-50);
                        label4.Location = new Point(this.Width / 2 - label4.Width / 2, (this.Height - label4.Height)-50);

                        
                        pictureBox1.Image = Image.FromFile(Ruta + @"\" + Productos[i, 3]);
                        pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
                        Centrar_Imagen();

                    }
                }
                Codigo = "";
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(Ruta + @"\barcode-scan.gif");
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            Centrar_Imagen();
            label2.Visible = true;
            label3.Visible = false;
            label4.Visible = false;
            timer1.Stop();
        }
    }
}
