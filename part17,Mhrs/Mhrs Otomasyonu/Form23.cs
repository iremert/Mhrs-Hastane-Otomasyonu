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
using Mhrs_Otomasyonu.DataSet1TableAdapters;

namespace Mhrs_Otomasyonu
{
    public partial class Form23 : Form
    {
        public Form23()
        {
            InitializeComponent();
        }

        public string doktor = "",tc="",resim="";
        DataTable1TableAdapter dt=new DataTable1TableAdapter();
        Tbl_ilaçlarTableAdapter dt2=new Tbl_ilaçlarTableAdapter();

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            richTextBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox1.Text= dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dt2.İlacEkle(textBox1.Text, richTextBox2.Text);
            MessageBox.Show("İlaç eklendi","İlaç",MessageBoxButtons.OK);
            richTextBox2.Text = "";
        }

        private void Form23_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form23_Load(object sender, EventArgs e)
        {
            label9.Text= doktor;

            pictureBox6.Image=Image.FromFile(resim);

            dataGridView1.DataSource=dt.RandevuListele(tc);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form18 frm18 = new Form18();
            frm18.Show();
            this.Hide();
        }
    }
}
