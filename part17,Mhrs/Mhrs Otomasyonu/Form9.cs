using Mhrs_Otomasyonu.SqlServerTypes;
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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        public string hasta, tc;
        Class1 bgl=new Class1();
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Mhrs mhrs = new Mhrs();
            mhrs.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form10 form10 = new Form10();
            form10.Show();  
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form14 form14 = new Form14();
            form14.tc = tc; 
            form14.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form11 form11 = new Form11();
            form11.hasta = hasta;
            form11.tc=tc;
            form11.Show();
            

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Form15 form15 = new Form15();
            form15.tc = tc;
            form15.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form16 frm16= new Form16();
            frm16.tc = tc;
            frm16.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Form16 frm16 = new Form16();
            frm16.Show();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Form11 form11 = new Form11();
            form11.hasta = hasta;
            form11.tc = tc;
            form11.Show();
            
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form14 form14 = new Form14();
            form14.Show();
        }

        private void Form9_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            label9.Text = hasta;

            SqlCommand komut=new SqlCommand("select doktorrandevuid,doktor,tarih,saat,hastasikayet from tbldoktorrandevu inner join tbldoktorlar on tbldoktorrandevu.doktorid=tbldoktorlar.doktorid where hastatc=@p1",bgl.connect());
            komut.Parameters.AddWithValue("@p1",tc);
            SqlDataAdapter da=new SqlDataAdapter(komut);
            DataTable dt=new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;


        }
    }
}
