using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Mhrs_Otomasyonu.SqlServerTypes
{
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        Class1 bgl = new Class1();
        public string tc = "";
        private void Form15_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select distinct il  from tbl_ailehekimi  ", bgl.connect());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.ValueMember = "il";
            comboBox1.DisplayMember = "il";
            comboBox1.DataSource = dt;
            comboBox1.SelectedIndex = -1;
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            comboBox2.Enabled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand("select distinct ilce  from tbl_ailehekimi where  il=@p1", bgl.connect());
            komut.Parameters.AddWithValue("@p1",comboBox1.Text);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox2.ValueMember = "ilce";
            comboBox2.DisplayMember = "ilce";
            comboBox2.DataSource = dt;
            comboBox2.SelectedIndex = -1;
        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            comboBox4.Enabled = true;  
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select distinct hastane from tbl_ailehekimi where  il=@p1 and ilce=@p2 and mahalle=@p3", bgl.connect());
            komut.Parameters.AddWithValue("@p1", comboBox1.Text);
            komut.Parameters.AddWithValue("@p2", comboBox2.Text);
            komut.Parameters.AddWithValue("@p3", comboBox4.Text);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox3.ValueMember = "hastane";
            comboBox3.DisplayMember = "hastane";
            comboBox3.DataSource = dt;
            comboBox3.SelectedIndex = -1;
        }

        private void comboBox4_Click(object sender, EventArgs e)
        {
            comboBox3.Enabled= true;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select distinct ailehekimi from tbl_ailehekimi where  il=@p1 and ilce=@p2 and mahalle=@p3 and hastane=@p4" , bgl.connect());
            komut.Parameters.AddWithValue("@p1", comboBox1.Text);
            komut.Parameters.AddWithValue("@p2", comboBox2.Text);
            komut.Parameters.AddWithValue("@p3", comboBox4.Text);
            komut.Parameters.AddWithValue("@p4", comboBox3.Text);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox5.ValueMember = "ailehekimi";
            comboBox5.DisplayMember = "ailehekimi";
            comboBox5.DataSource = dt;
            comboBox5.SelectedIndex = -1;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select distinct mahalle from tbl_ailehekimi where il=@p1 and ilce=@p2", bgl.connect());
            komut.Parameters.AddWithValue("@p1", comboBox1.Text);
            komut.Parameters.AddWithValue("@p2", comboBox2.Text);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox4.ValueMember = "mahalle";
            comboBox4.DisplayMember = "mahalle";
            comboBox4.DataSource = dt;
            comboBox4.SelectedIndex = -1;
        }

        private void comboBox3_Click(object sender, EventArgs e)
        {
            comboBox5.Enabled = true;
        }
        string id = "";
        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update tbl_hastalar set ailehekimiid=@p1 where hastatc=@p2",bgl.connect());
            komut.Parameters.AddWithValue("@p1",id);
            komut.Parameters.AddWithValue("@p2", tc);
            komut.ExecuteNonQuery();
            bgl.connect().Close();

            timer1.Start();
        }

        int tick = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            tick++;
            toolStripStatusLabel1.Text = "Aile Hekiminiz oluşturuldu.";
            if(tick==20)
            {
                timer1.Stop();
                toolStripStatusLabel1.Text = "";
            }
        }
       
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select distinct AileHekimiid from tbl_ailehekimi  where  il=@p1 and ilce=@p2 and mahalle=@p3 and hastane=@p4 and ailehekimi=@p5", bgl.connect());
            komut.Parameters.AddWithValue("@p1", comboBox1.Text);
            komut.Parameters.AddWithValue("@p2", comboBox2.Text);
            komut.Parameters.AddWithValue("@p3", comboBox4.Text);
            komut.Parameters.AddWithValue("@p4", comboBox3.Text);
            komut.Parameters.AddWithValue("@p5", comboBox5.Text);
            SqlDataReader oku= komut.ExecuteReader();
            while(oku.Read())
            {
                id = oku[0].ToString();
            }
        }

        private void comboBox5_Click(object sender, EventArgs e)
        {
            button4.Enabled = true;
        }
    }
}
