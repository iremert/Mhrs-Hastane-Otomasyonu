using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mhrs_Otomasyonu
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            Form9 frm9 = Application.OpenForms["Form9"] as Form9;
            if (frm9 != null)
            {
                if (comboBox1.Text == "Açık Renk")
                {
                    frm9.BackColor = Color.White;
                }
                else if (comboBox1.Text == "Koyu Renk")
                {
                    frm9.BackColor = Color.Black;
                }
                else if (comboBox1.Text == "Pembe Renk(barbie girl aşko <3)")
                {
                    frm9.BackColor = Color.LightPink;
                }
            }
            Form11 frm11 = Application.OpenForms["Form11"] as Form11;
            if (frm11 != null)
            {
                if (comboBox1.Text == "Açık Renk")
                {
                    frm11.BackColor = Color.White;
                }
                else if (comboBox1.Text == "Koyu Renk")
                {
                    frm11.BackColor = Color.Black;
                }
                else if (comboBox1.Text == "Pembe Renk(barbie girl aşko <3)")
                {
                    frm11.BackColor = Color.LightPink;
                }
            }

            Form12 frm12 = Application.OpenForms["Form12"] as Form12;
            if (frm12 != null)
            {
                if (comboBox1.Text == "Açık Renk")
                {
                    frm12.BackColor = Color.White;
                }
                else if (comboBox1.Text == "Koyu Renk")
                {
                    frm12.BackColor = Color.Black;
                }
                else if (comboBox1.Text == "Pembe Renk(barbie girl aşko <3)")
                {
                    frm12.BackColor = Color.LightPink;
                }
            }
        }

        private void Form10_Load(object sender, EventArgs e)
        {

        }

    }
}
