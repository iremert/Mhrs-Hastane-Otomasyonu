using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Mhrs_Otomasyonu
{
    public partial class Form22 : Form
    {
        public Form22()
        {
            InitializeComponent();
        }

        Class1 bgl=new Class1();    
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form18 frm18 = new Form18();
            frm18.Show();
            this.Hide();
        }


        private void textBox1_Enter_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "T.C. Kimlik No")
            {
                textBox1.ForeColor = Color.Black;
                textBox1.Text = "";
            }
        }

        private void textBox1_Leave_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.ForeColor = Color.Gray;
                textBox1.Text = "T.C. Kimlik No";
            }
        }

        private void textBox2_Enter_1(object sender, EventArgs e)
        {
            if (textBox2.Text == "Parola")
            {
                textBox2.ForeColor = Color.Black;
                textBox2.Text = "";
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void textBox2_Leave_1(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.ForeColor = Color.Gray;
                textBox2.Text = "Parola";

                textBox2.UseSystemPasswordChar = false;
            }
        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
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
            SqlCommand komut = new SqlCommand("select * from tbldoktorlar where tc=@p1 and sifre=@p2",bgl.connect());
            komut.Parameters.AddWithValue("@p1",textBox1.Text);
            komut.Parameters.AddWithValue("@p2", textBox2.Text);
            SqlDataReader oku=komut.ExecuteReader();
            if(oku.Read())
            {
                Form23 frm23= new Form23();
                frm23.doktor = oku[6].ToString();
                frm23.tc= oku[8].ToString();
                frm23.resim = oku[7].ToString();
                frm23.Show();
                this.Hide();
            }
            else
            {
                timer1.Start();
            }
        }

        int tick = 0;
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

        private void Form22_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
