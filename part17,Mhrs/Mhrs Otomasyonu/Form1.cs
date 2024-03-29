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
    public partial class Mhrs : Form
    {
        public Mhrs()
        {
            InitializeComponent();
        }
        Class1 bgl=new Class1();

        private void textBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if(textBox1.Text== "T.C. Kimlik No")
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

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form4 frm4= new Form4();    
            frm4.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 frm6 = new Form6();   
            frm6.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form8 frm8 = new Form8();
            frm8.Show();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut=new SqlCommand("select * from tbl_hastalar where hastatc=@p1 and sifre=@p2",bgl.connect());
            komut.Parameters.AddWithValue("@p1",textBox1.Text);
            komut.Parameters.AddWithValue("@p2",textBox2.Text);
            SqlDataReader oku=komut.ExecuteReader();    
            if(oku.Read())
            {
                Form9 form9 = new Form9();
                form9.hasta = oku[2] + " " + oku[3];
                form9.tc = oku[1].ToString();
                form9.Show();
                this.Hide();
            }
            else
            {
                timer1.Start();
            }
            
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form18 frm18=new Form18();
            frm18.Show();
            this.Hide();
        }

        int tick = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            tick++;
            toolStripStatusLabel1.Text = "Girdiğiniz bilgilerle eşleşen kullanıcı bulunamadı, lütfen kontrol ediniz !!! (Boş alan bırakmayınız.)";
            if(tick==20)
            {
                timer1.Stop();
                toolStripStatusLabel1.Text = "";
            }
        }

        private void Mhrs_Load(object sender, EventArgs e)
        {

        }

        private void Mhrs_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
