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
    public partial class Form25 : Form
    {
        public Form25()
        {
            InitializeComponent();
        }

        public string tc = "";
        Tbl_ilaçlar1TableAdapter ds=new Tbl_ilaçlar1TableAdapter();
        private void Form25_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.İlacListele();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form18 frm18= new Form18(); 
            frm18.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.İlacListele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ds.ilacGüncelle(tc);
        }

        private void Form25_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
