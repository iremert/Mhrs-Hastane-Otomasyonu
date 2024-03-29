using Mhrs_Otomasyonu.SqlServerTypes;
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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        Class1 bgl=new Class1();
        public string hasta,tc;
        private void pictureBox8_Click(object sender, EventArgs e)
        {
           
            this.Hide();    
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form10 frm10= new Form10();
            frm10.Show();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Mhrs mhrs = new Mhrs();
            mhrs.Show();
            this.Hide();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select distinct doktoril  from tbldoktorrandevu inner join tbldoktorlar on tbldoktorrandevu.doktorid=tbldoktorlar.doktorid where durum=0",bgl.connect());
            SqlDataAdapter da=new SqlDataAdapter(komut);
            DataTable dt=new DataTable();
            da.Fill(dt);
            comboBox1.ValueMember = "doktoril";
            comboBox1.DisplayMember = "doktoril";
            comboBox1.DataSource = dt;
            comboBox1.SelectedIndex = -1;
        }

       

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Form15 form15= new Form15();
            form15.tc = tc;
            form15.Show();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            SqlCommand komut = new SqlCommand("select distinct doktorilçe  from tbldoktorrandevu inner join tbldoktorlar on tbldoktorrandevu.doktorid=tbldoktorlar.doktorid where durum=0 and doktoril=@p1", bgl.connect());
            komut.Parameters.AddWithValue("@p1",comboBox1.Text);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox2.ValueMember = "doktorilçe";
            comboBox2.DisplayMember = "doktorilçe";
            comboBox2.DataSource = dt;
            comboBox2.SelectedIndex = -1;
     
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            comboBox2.Enabled = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select distinct doktorklinik  from tbldoktorrandevu inner join tbldoktorlar on tbldoktorrandevu.doktorid=tbldoktorlar.doktorid where durum=0 and doktoril=@p1 and doktorilçe=@p2", bgl.connect());
            komut.Parameters.AddWithValue("@p1", comboBox1.Text);
            komut.Parameters.AddWithValue("@p2", comboBox2.Text);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox3.ValueMember = "doktorklinik";
            comboBox3.DisplayMember = "doktorklinik";
            comboBox3.DataSource = dt;
            comboBox3.SelectedIndex = -1;
        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            comboBox3.Enabled = true;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select distinct doktorhastane  from tbldoktorrandevu inner join tbldoktorlar on tbldoktorrandevu.doktorid=tbldoktorlar.doktorid where durum=0 and doktoril=@p1 and doktorilçe=@p2 and doktorklinik=@p3", bgl.connect());
            komut.Parameters.AddWithValue("@p1", comboBox1.Text);
            komut.Parameters.AddWithValue("@p2", comboBox2.Text);
            komut.Parameters.AddWithValue("@p3", comboBox3.Text);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox4.ValueMember = "doktorhastane";
            comboBox4.DisplayMember = "doktorhastane";
            comboBox4.DataSource = dt;
            comboBox4.SelectedIndex = -1;
        }

        private void comboBox3_Click(object sender, EventArgs e)
        {
            comboBox4.Enabled = true;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select distinct doktormuayeneyeri  from tbldoktorrandevu inner join tbldoktorlar on tbldoktorrandevu.doktorid=tbldoktorlar.doktorid where durum=0 and doktoril=@p1 and doktorilçe=@p2 and doktorklinik=@p3 and doktorhastane=@p4", bgl.connect());
            komut.Parameters.AddWithValue("@p1", comboBox1.Text);
            komut.Parameters.AddWithValue("@p2", comboBox2.Text);
            komut.Parameters.AddWithValue("@p3", comboBox3.Text);
            komut.Parameters.AddWithValue("@p4", comboBox4.Text);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox5.ValueMember = "doktormuayeneyeri";
            comboBox5.DisplayMember = "doktormuayeneyeri";
            comboBox5.DataSource = dt;
            comboBox5.SelectedIndex = -1;
        }

        private void comboBox4_Click(object sender, EventArgs e)
        {
            comboBox5.Enabled = true;
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select distinct doktor from tbldoktorrandevu inner join tbldoktorlar on tbldoktorrandevu.doktorid=tbldoktorlar.doktorid where durum=0 and doktoril=@p1 and doktorilçe=@p2 and doktorklinik=@p3 and doktorhastane=@p4 and doktormuayeneyeri=@p5", bgl.connect());
            komut.Parameters.AddWithValue("@p1", comboBox1.Text);
            komut.Parameters.AddWithValue("@p2", comboBox2.Text);
            komut.Parameters.AddWithValue("@p3", comboBox3.Text);
            komut.Parameters.AddWithValue("@p4", comboBox4.Text);
            komut.Parameters.AddWithValue("@p5", comboBox5.Text);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox6.ValueMember = "doktor";
            comboBox6.DisplayMember = "doktor";
            comboBox6.DataSource = dt;
            comboBox6.SelectedIndex = -1;
        }

        private void comboBox5_Click(object sender, EventArgs e)
        {
            comboBox6.Enabled = true;
        }


        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select distinct tarih from tbldoktorrandevu inner join tbldoktorlar on tbldoktorrandevu.doktorid=tbldoktorlar.doktorid where durum=0 and doktoril=@p1 and doktorilçe=@p2 and doktorklinik=@p3 and doktorhastane=@p4 and doktormuayeneyeri=@p5 and doktor=@p6", bgl.connect());
            komut.Parameters.AddWithValue("@p1", comboBox1.Text);
            komut.Parameters.AddWithValue("@p2", comboBox2.Text);
            komut.Parameters.AddWithValue("@p3", comboBox3.Text);
            komut.Parameters.AddWithValue("@p4", comboBox4.Text);
            komut.Parameters.AddWithValue("@p5", comboBox5.Text);
            komut.Parameters.AddWithValue("@p6", comboBox6.Text);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox7.ValueMember = "tarih";
            comboBox7.DisplayMember = "tarih";
            comboBox7.DataSource = dt;
            comboBox7.SelectedIndex = -1;

        }


        
        private void button1_Click(object sender, EventArgs e)
        {
            Form12 frm12 = new Form12();
            frm12.hasta = hasta;
            frm12.tc = tc;
            frm12.a = comboBox1.Text;
            frm12.b = comboBox2.Text;
            frm12.c = comboBox3.Text;
            frm12.d = comboBox4.Text;
            frm12.h = comboBox5.Text;
            frm12.f = comboBox6.Text;
            frm12.g=comboBox7.Text;
            frm12.Show();
        }
        private void comboBox6_Click(object sender, EventArgs e)
        {
            comboBox7.Enabled = true;
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox7_Click(object sender, EventArgs e)
        {
            button1.Enabled = true; 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            comboBox5.SelectedIndex = -1;
            comboBox6.SelectedIndex = -1;
            comboBox7.SelectedIndex = -1;
        }

        private void Form11_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }
    }
}
