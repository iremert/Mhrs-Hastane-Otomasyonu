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
    public partial class Form16 : Form
    {
        public Form16()
        {
            InitializeComponent();
        }

        Class1 bgl=new Class1();
        public string tc = "";
        private void Form16_Load(object sender, EventArgs e)
        {
            SqlCommand komut= new SqlCommand("select ailehekimi,hastane from tbl_hastalar inner join tbl_ailehekimi on tbl_hastalar.ailehekimiid=tbl_ailehekimi.ailehekimiid ",bgl.connect()); 
            SqlDataReader oku=komut.ExecuteReader();
            while(oku.Read())
            {
                label1.Text = oku[0].ToString();
                label2.Text = oku[1].ToString();
            }
            bgl.connect().Close();

            SqlCommand komut2 = new SqlCommand("select distinct tarih from tbl_ailehekimirandevu  inner join tbl_ailehekimi on tbl_ailehekimirandevu.ailehekimiid=tbl_ailehekimi.ailehekimiid where ailehekimi=@p1",bgl.connect());
            komut2.Parameters.AddWithValue("@p1",label1.Text);
            SqlDataAdapter da= new SqlDataAdapter(komut2);
            DataTable dt= new DataTable();  
            da.Fill(dt);

            comboBox3.ValueMember = "tarih";
            comboBox3.DisplayMember = "tarih";

            comboBox3.DataSource = dt;
            comboBox3.SelectedIndex = -1;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            SqlCommand komut2 = new SqlCommand("select distinct saat from tbl_ailehekimirandevu  inner join tbl_ailehekimi on tbl_ailehekimirandevu.ailehekimiid=tbl_ailehekimi.ailehekimiid where ailehekimi=@p1 and tarih=@p2 and durum=0", bgl.connect());
            komut2.Parameters.AddWithValue("@p1", label1.Text);
            komut2.Parameters.AddWithValue("@p2", comboBox3.Text);
            SqlDataAdapter da = new SqlDataAdapter(komut2);
            DataTable dt = new DataTable();
            da.Fill(dt);

            comboBox6.ValueMember = "saat";
            comboBox6.DisplayMember = "saat";

            comboBox6.DataSource = dt;
            comboBox6.SelectedIndex = -1;
        }

        private void comboBox3_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }
        string idd = "";
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update tbl_ailehekimirandevu set durum=1 , hastatc=@p2 where id=@p1", bgl.connect());
            komut.Parameters.AddWithValue("@p1",idd);
            komut.Parameters.AddWithValue("@p2", tc);
            komut.ExecuteNonQuery();
            bgl.connect().Close();

            timer1.Start();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("select distinct id from tbl_ailehekimirandevu  inner join tbl_ailehekimi on tbl_ailehekimirandevu.ailehekimiid=tbl_ailehekimi.ailehekimiid where ailehekimi=@p1 and tarih=@p2 and saat=@p3 and durum=0", bgl.connect());
            komut2.Parameters.AddWithValue("@p1", label1.Text);
            komut2.Parameters.AddWithValue("@p2", comboBox3.Text);
            komut2.Parameters.AddWithValue("@p3", comboBox6.Text);
            SqlDataReader oku= komut2.ExecuteReader();
            while(oku.Read())
            {
                idd = oku[0].ToString();
            }
            bgl.connect().Close();
        }

        int tick = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            tick++;
            toolStripStatusLabel1.Text = "Aile Hekimi randevunuz oluşturuldu.";
            if(tick==20)
            {
                timer1.Stop();
                toolStripStatusLabel1.Text = "";
            }
        }

    }
}
