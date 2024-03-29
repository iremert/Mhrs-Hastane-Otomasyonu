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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        Class1 bgl=new Class1();
        public string tc = "";
        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox1.Text==textBox2.Text)
            {
                SqlCommand komut = new SqlCommand("update tbl_hastalar set sifre=@p1 where hastatc=@p2", bgl.connect());
                komut.Parameters.AddWithValue("@p1", textBox2.Text);
                komut.Parameters.AddWithValue("@p2", tc);
                komut.ExecuteNonQuery();
                bgl.connect().Close();
                timer2.Start();
                

                textBox2.Text = "";
                textBox1.Text = "";
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
            toolStripStatusLabel1.Text = "Girdiğiniz şifreler uyuşmuyor, kontrol ediniz.";
            if(tick==10)
            {
                timer1.Stop();
                toolStripStatusLabel1.Text="";
            }
        }


        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            tick2++;
            toolStripStatusLabel1.Text = "Parola Sıfırlandı.";
            if(tick2==10)
            {
                timer2.Stop();
                toolStripStatusLabel1.Text = "";
            }
        }
    }
}
