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
using System.Data.SqlClient;

namespace Mhrs_Otomasyonu
{
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent();
        }
        Class1 bgl=new Class1();
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public string tc = "", id = "";
        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand komut=new SqlCommand("update tbl_asirandevu set durum=1 ,hastatc=@p1 where aşırandevuid=@p2",bgl.connect());
            komut.Parameters.AddWithValue("@p1",tc);
            komut.Parameters.AddWithValue("@p2",id);
            komut.ExecuteNonQuery();
            bgl.connect().Close();
            Form17 form17 = new Form17();
            form17.Show();

            timer1.Start();

        }

        private void label5_Click(object sender, EventArgs e)
        {
            
        }

        string look="a";
        private void button1_Click(object sender, EventArgs e)
        {
            label9.Text = button1.Text;
            comboBox1.Enabled = true;

            comboBox1.Items.Clear();
            SqlCommand komut = new SqlCommand("select  il  from tbl_asirandevu  where asituru=@p1 and durum=0 ", bgl.connect());
            komut.Parameters.AddWithValue("@p1", label9.Text);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                if (!comboBox1.Items.Contains(oku[0].ToString()))
                {
                    comboBox1.Items.Add(oku[0].ToString());
                }
            }
            bgl.connect().Close();
            comboBox1.SelectedIndex = -1;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            label9.Text = button2.Text;
            comboBox1.Enabled = true;

            comboBox1.Items.Clear();
            SqlCommand komut = new SqlCommand("select  il  from tbl_asirandevu  where asituru=@p1 and durum=0", bgl.connect());
            komut.Parameters.AddWithValue("@p1", label9.Text);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                if (!comboBox1.Items.Contains(oku[0].ToString()))
                {
                    comboBox1.Items.Add(oku[0].ToString());
                }
            }
            bgl.connect().Close();
            comboBox1.SelectedIndex = -1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label9.Text = button3.Text;
            comboBox1.Enabled = true;

            comboBox1.Items.Clear();
            SqlCommand komut = new SqlCommand("select  il  from tbl_asirandevu  where asituru=@p1 and durum=0  ", bgl.connect());
            komut.Parameters.AddWithValue("@p1", label9.Text);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                if (!comboBox1.Items.Contains(oku[0].ToString()))
                {
                    comboBox1.Items.Add(oku[0].ToString());
                }
            }
            bgl.connect().Close();
            comboBox1.SelectedIndex = -1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            SqlCommand komut = new SqlCommand("select  ilce  from tbl_asirandevu  where asituru=@p1 and il=@p2 and durum=0 ", bgl.connect());
            komut.Parameters.AddWithValue("@p1", label9.Text);
            komut.Parameters.AddWithValue("@p2", comboBox1.Text);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                if (!comboBox2.Items.Contains(oku[0].ToString()))
                {
                    comboBox2.Items.Add(oku[0].ToString());
                }
            }
            bgl.connect().Close();
            comboBox2.SelectedIndex = -1;
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            comboBox2.Enabled = true;
        }

        private void Form14_Load(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();
            SqlCommand komut = new SqlCommand("select  hastane from tbl_asirandevu  where asituru=@p1 and il=@p2 and ilce=@p3 and durum=0 ", bgl.connect());
            komut.Parameters.AddWithValue("@p1", label9.Text);
            komut.Parameters.AddWithValue("@p2", comboBox1.Text);
            komut.Parameters.AddWithValue("@p3", comboBox2.Text);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                if (!comboBox4.Items.Contains(oku[0].ToString()))
                {
                    comboBox4.Items.Add(oku[0].ToString());
                }
            }
            bgl.connect().Close();
            comboBox4.SelectedIndex = -1;
        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            comboBox4.Enabled = true;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox5.Items.Clear();
            SqlCommand komut = new SqlCommand("select  muayene from tbl_asirandevu  where asituru=@p1 and il=@p2 and ilce=@p3 and hastane=@p4 and durum=0 ", bgl.connect());
            komut.Parameters.AddWithValue("@p1", label9.Text);
            komut.Parameters.AddWithValue("@p2", comboBox1.Text);
            komut.Parameters.AddWithValue("@p3", comboBox2.Text);
            komut.Parameters.AddWithValue("@p4", comboBox4.Text);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                if (!comboBox5.Items.Contains(oku[0].ToString()))
                {
                    comboBox5.Items.Add(oku[0].ToString());
                }
            }
            bgl.connect().Close();
            comboBox5.SelectedIndex = -1;
        }

        private void comboBox5_Click(object sender, EventArgs e)
        {
            comboBox3.Enabled = true;
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            SqlCommand komut = new SqlCommand("select  tarih from tbl_asirandevu  where asituru=@p1 and il=@p2 and ilce=@p3 and hastane=@p4 and muayene=@p5 and durum=0 ", bgl.connect());
            komut.Parameters.AddWithValue("@p1", label9.Text);
            komut.Parameters.AddWithValue("@p2", comboBox1.Text);
            komut.Parameters.AddWithValue("@p3", comboBox2.Text);
            komut.Parameters.AddWithValue("@p4", comboBox4.Text);
            komut.Parameters.AddWithValue("@p5", comboBox5.Text);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                if (!comboBox3.Items.Contains(oku[0].ToString()))
                {
                    comboBox3.Items.Add(oku[0].ToString());
                }
            }
            bgl.connect().Close();
            comboBox3.SelectedIndex = -1;
        }

        private void comboBox4_Click(object sender, EventArgs e)
        {
            comboBox5.Enabled = true;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox6.Items.Clear();
            SqlCommand komut = new SqlCommand("select saat from tbl_asirandevu  where asituru=@p1 and il=@p2 and ilce=@p3 and hastane=@p4 and muayene=@p5 and tarih=@p6 and durum=0 ", bgl.connect());
            komut.Parameters.AddWithValue("@p1", label9.Text);
            komut.Parameters.AddWithValue("@p2", comboBox1.Text);
            komut.Parameters.AddWithValue("@p3", comboBox2.Text);
            komut.Parameters.AddWithValue("@p4", comboBox4.Text);
            komut.Parameters.AddWithValue("@p5", comboBox5.Text);
            komut.Parameters.AddWithValue("@p6", comboBox3.Text);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                if (!comboBox6.Items.Contains(oku[0].ToString()))
                {
                    comboBox6.Items.Add(oku[0].ToString());
                }
                
            }
            bgl.connect().Close();
            comboBox6.SelectedIndex = -1;
        }

        private void comboBox3_Click(object sender, EventArgs e)
        {
            comboBox6.Enabled = true;   
        }

        int tick = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            tick++;
            toolStripStatusLabel1.Text = "Aşı Randevusu Başarı ile Oluşturuldu.";
            if(tick==20)
            {
                timer1.Stop();
                toolStripStatusLabel1.Text = "";
            }
        }

        private void comboBox6_Click(object sender, EventArgs e)
        {
            button4.Enabled = true;    
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select  aşırandevuid from tbl_asirandevu  where asituru=@p1 and il=@p2 and ilce=@p3 and hastane=@p4 and muayene=@p5 and tarih=@p6 and saat=@p7 and durum=0 ", bgl.connect());
            komut.Parameters.AddWithValue("@p1", label9.Text);
            komut.Parameters.AddWithValue("@p2", comboBox1.Text);
            komut.Parameters.AddWithValue("@p3", comboBox2.Text);
            komut.Parameters.AddWithValue("@p4", comboBox4.Text);
            komut.Parameters.AddWithValue("@p5", comboBox5.Text);
            komut.Parameters.AddWithValue("@p6", comboBox3.Text);
            komut.Parameters.AddWithValue("@p7", comboBox6.Text);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                id = oku[0].ToString(); 
            }
            bgl.connect().Close();
           
        }
    }
}
