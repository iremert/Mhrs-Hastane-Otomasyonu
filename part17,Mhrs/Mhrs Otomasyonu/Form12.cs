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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Mhrs_Otomasyonu
{
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        Class1 bgl=new Class1();
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Hide();
            
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form10 frm10 = new Form10();
            frm10.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Mhrs mhrs = new Mhrs();
            mhrs.Show();
            this.Hide();
        }
        public string a = "", b, c, d,h,f,g,hasta,tc;



        private void button3_Click(object sender, EventArgs e)
        {
            int row = dataGridView1.SelectedCells[0].RowIndex;
            
            Form13 frm13 = new Form13();
            frm13.a = f;
            frm13.b = d;
            frm13.c = c;
            frm13.d = h;
            frm13.hasta = hasta;
            frm13.tc = tc;

            frm13.kk= dataGridView1.Rows[row].Cells[8].Value.ToString();

            frm13.kkk = dataGridView1.Rows[row].Cells[0].Value.ToString();
            frm13.Show();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Form15 frm15=new Form15();
            frm15.tc = tc;
            frm15.Show();
            
        }

        

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button3.Enabled = true;

        }

        private void Form12_Load_1(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlCommand komut = new SqlCommand("select doktorrandevuid,doktoril,doktorilçe,doktorklinik,doktorhastane,doktormuayeneyeri,doktor,tarih, saat from tbldoktorrandevu inner join tbldoktorlar on tbldoktorrandevu.doktorid=tbldoktorlar.doktorid where durum=0 and doktoril=@p1 and doktorilçe=@p2 and doktorklinik=@p3 and doktorhastane=@p4 and doktormuayeneyeri=@p5 and doktor=@p6 and tarih=@p7", bgl.connect());
            komut.Parameters.AddWithValue("@p1", a);
            komut.Parameters.AddWithValue("@p2", b);
            komut.Parameters.AddWithValue("@p3", c);
            komut.Parameters.AddWithValue("@p4", d);
            komut.Parameters.AddWithValue("@p5", h);
            komut.Parameters.AddWithValue("@p6", f);
            komut.Parameters.AddWithValue("@p7", g);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            
        }



    }
}
