using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using System.Data.SqlClient;

namespace Mhrs_Otomasyonu
{
    public partial class Form24 : Form
    {
        public Form24()
        {
            InitializeComponent();
        }

        Class1 bgl = new Class1();
        private void Form24_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form18 frm18 = new Form18();
            frm18.Show();
            this.Hide();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "T.C. Kimlik No")
            {
                textBox1.ForeColor = Color.Black;
                textBox1.Text = "";
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.ForeColor = Color.Gray;
                textBox1.Text = "T.C. Kimlik No";
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Parola")
            {
                textBox2.ForeColor = Color.Black;
                textBox2.Text = "";
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.ForeColor = Color.Gray;
                textBox2.Text = "Parola";

                textBox2.UseSystemPasswordChar = false;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (pictureBox5.ImageLocation == @"C:\Users\lenovo\OneDrive\Masaüstü\Future\c#\part17,Mhrs\Adsız tasarım (2).png")
            {
                pictureBox5.ImageLocation = @"C:\Users\lenovo\OneDrive\Masaüstü\Future\c#\part17,Mhrs\Adsız tasarım (3).png"; //göz açık

                if (textBox2.Text == "Parola")
                {
                    textBox2.UseSystemPasswordChar = false;
                }
                else { textBox2.UseSystemPasswordChar = true; }
            }
            else
            {
                pictureBox5.ImageLocation = @"C:\Users\lenovo\OneDrive\Masaüstü\Future\c#\part17,Mhrs\Adsız tasarım (2).png"; //göz kapalı

                textBox2.UseSystemPasswordChar = false;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from tbl_eczaci where eczacitc=@p1 and eczacisifre=@p2", bgl.connect());
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            komut.Parameters.AddWithValue("@p2", textBox2.Text);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                SqlCommand komut2 = new SqlCommand("select * from tbl_ilaçlar where tc=@p1",bgl.connect());
                komut2.Parameters.AddWithValue("@p1",textBox3.Text);
                SqlDataReader oku2=komut2.ExecuteReader();   
                if(oku2.Read())
                {
                    Form25 frm25 = new Form25();
                    frm25.tc = textBox3.Text;
                    frm25.Show();
                    this.Hide();
                    timer2.Start();
                }
               
            }
            else
            {
                timer1.Start();
            }
        }

        int tick = 0,tick2=0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            tick++;
            toolStripStatusLabel1.Text = "Girdiğiniz bilgilerle eşleşen kullanıcı bulunamadı, lütfen kontrol ediniz !!! (Boş alan bırakmayınız.)";
            if (tick == 20)
            {
                timer1.Stop();
                toolStripStatusLabel1.Text = "";
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Hasta T.C. Kimlik No")
            {
                textBox3.ForeColor = Color.Black;
                textBox3.Text = "";
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.ForeColor = Color.Gray;
                textBox3.Text = "Hasta T.C. Kimlik No";
            }
        }

        private void Form24_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            tick2++;
            toolStripStatusLabel1.Text = "Bu hastaya ilaç atanmamış giriş yapilmicak. (Boş alan bırakmayınız.)";
            if (tick2 == 20)
            {
                timer2.Stop();
                toolStripStatusLabel1.Text = "";
            }
        }
    }
}
