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
    public partial class Form27 : Form
    {
        public Form27()
        {
            InitializeComponent();
        }

        public string ailehekimi = "",tc="";
        DataTable2TableAdapter da=new DataTable2TableAdapter();
        Tbl_ilaçlarTableAdapter da2=new Tbl_ilaçlarTableAdapter();
        private void Form27_Load(object sender, EventArgs e)
        {
            label9.Text= ailehekimi;
            dataGridView1.DataSource=da.GetData(tc);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            da2.İlacEkle(textBox1.Text,richTextBox2.Text);
            MessageBox.Show("İlaç eklendi.","İlaç",MessageBoxButtons.OK);
            richTextBox2.Text = "";
            
        }

        private void Form27_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form18 frm18=new Form18();
            frm18.Show();
            this.Hide();
        }
    }
}
