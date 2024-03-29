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
    public partial class Form20 : Form
    {
        public Form20()
        {
            InitializeComponent();
        }


        Class1 bgl=new Class1();    
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form18 frm18= new Form18();
            frm18.Show();
            this.Hide();
        }


        
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut=new SqlCommand("select * from tbl_sekreterler where sekretertc=@p1 and sekreterşifre=@p2",bgl.connect());
            komut.Parameters.AddWithValue("@p1",textBox1.Text);
            komut.Parameters.AddWithValue("@p2",textBox2.Text);
            SqlDataReader oku=komut.ExecuteReader();
            if(oku.Read())
            {
                 
                Form21  frm21= new Form21();
                frm21.sekretertc = oku[1].ToString();
                frm21.sekretersifre = oku[2].ToString();
                frm21.sekreterresim = oku[3].ToString();
                frm21.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Girdiğiniz şifre yada tc kimlik numarasında hata var,lütfen kontrol ediniz.", "Hata", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }


        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "T.C. Kimlik No";
                textBox1.ForeColor = Color.Gray;
                pictureBox3.Focus();
            }
            
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
            textBox1.ForeColor = Color.Black;
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.Text = "";
            textBox2.ForeColor= Color.Black;

            if(pictureBox5.Visible==true)
            {
                textBox2.UseSystemPasswordChar = true;
            }
            
        }

        private void textBox2_MouseLeave(object sender, EventArgs e)
        {
            if(textBox2.Text =="")
            {
                textBox2.Text = "Parola";
                textBox2.ForeColor = Color.Gray;
                textBox2.UseSystemPasswordChar = false;
                pictureBox3.Focus();
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            pictureBox6.Visible = false;
            pictureBox5.Visible= true;  

            textBox2.UseSystemPasswordChar = true;
            if (textBox2.Text == "Parola")
            {
                textBox2.UseSystemPasswordChar = false;
            }

        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            pictureBox5.Visible = false;
            pictureBox6.Visible = true;

            textBox2.UseSystemPasswordChar = false;
            if(textBox2.Text == "Parola")
            {
                textBox2.UseSystemPasswordChar = false;
            }
        }

        private void Form20_Load(object sender, EventArgs e)
        {

        }

        private void Form20_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
