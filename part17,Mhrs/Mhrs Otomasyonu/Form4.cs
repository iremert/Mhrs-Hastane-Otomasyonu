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
    public partial class Form4 : Form
    {
        Class1 bgl=new Class1();
        public Form4()
        {
            InitializeComponent();
        }


        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Mhrs form = new Mhrs();
            form.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand komut= new SqlCommand("select * from tbl_hastalar where hastatc=@p1 and hastaad=@p2 and hastasoyad=@p3 and hastadoğumtarihi=@p4 and yemek=@p5 and sanslinumara=@p6 ",bgl.connect());
            komut.Parameters.AddWithValue("@p1",textBox1.Text);
            komut.Parameters.AddWithValue("@p2", textBox3.Text);
            komut.Parameters.AddWithValue("@p3", textBox4.Text);
            komut.Parameters.AddWithValue("@p4", dateTimePicker1.Text);
            komut.Parameters.AddWithValue("@p5", textBox5.Text);
            komut.Parameters.AddWithValue("@p6", textBox6.Text);
            SqlDataReader oku= komut.ExecuteReader();
            if (oku.Read())
            {
                Form5 form = new Form5();
                form.tc = textBox1.Text;
                form.Show();
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
            toolStripStatusLabel1.Text = "Böyle bir kullanıcı bulamadık,lütfen girdiğiniz bilgileri kontrol ediniz (her alan doldurulmak zorunda) !!!";
            if(tick==20)
            {
                timer1.Stop();
                toolStripStatusLabel1.Text = "";
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
