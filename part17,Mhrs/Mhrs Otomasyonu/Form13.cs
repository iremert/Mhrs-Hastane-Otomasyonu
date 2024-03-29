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
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }

        Class1 bgl=new Class1();
        public string kk, a, b, c, d, hasta, tc,kkk;

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Doktora Not Ekle";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if(textBox1.Text == "Doktora Not Ekle")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }


        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand komut= new SqlCommand("update tbldoktorrandevu set durum=1,hastatc=@p1,hastasikayet=@p2 where doktorrandevuid=@p3",bgl.connect());
            komut.Parameters.AddWithValue("@p1",tc);
            komut.Parameters.AddWithValue("@p2",textBox1.Text);
            komut.Parameters.AddWithValue("@p3", kkk);
            komut.ExecuteNonQuery();
            bgl.connect().Close();
            MessageBox.Show("Randevu alındı.");
            
            this.Hide();
        }

        
        private void Form13_Load(object sender, EventArgs e)
        {
            label8.Text =kk;
            label9.Text = a;
            label10.Text = b;
            label11.Text = c;
            label12.Text = d;

            label13.Text = hasta;
        }
    }
}
