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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        Class1 bgl=new Class1();

        
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Form3 frm3= new Form3();
            frm3.Show();
            
        }
        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            Mhrs form=new Mhrs();
            form.Show();
            this.Hide();
        }

        DateTime now = DateTime.Now;
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox3.Text=="" || textBox4.Text=="" || comboBox1.Text=="" || textBox2.Text=="" || textBox5.Text=="" || textBox6.Text=="" )
            {
                timer3.Start();
            }
           
            else
            {
                if (checkBox1.Checked == true)
                {
                    SqlCommand komut2 = new SqlCommand("select * from tbl_hastalar where hastatc=@p1", bgl.connect());
                    komut2.Parameters.AddWithValue("@p1", textBox1.Text);
                    SqlDataReader oku = komut2.ExecuteReader();
                    if (oku.Read())
                    {
                        timer1.Start();
                    }
                    else
                    {
                        SqlCommand komut = new SqlCommand("insert into tbl_hastalar (hastatc,hastaad,hastasoyad,hastacinsiyet,hastadoğumtarihi,sifre,yemek,sanslinumara) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.connect());
                        komut.Parameters.AddWithValue("@p1", textBox1.Text);
                        komut.Parameters.AddWithValue("@p2", textBox3.Text);
                        komut.Parameters.AddWithValue("@p3", textBox4.Text);
                        komut.Parameters.AddWithValue("@p4", comboBox1.Text);
                        komut.Parameters.AddWithValue("@p5", dateTimePicker1.Text);
                        komut.Parameters.AddWithValue("@p6", textBox2.Text);
                        komut.Parameters.AddWithValue("@p7", textBox5.Text);
                        komut.Parameters.AddWithValue("@p8", textBox6.Text);
                        komut.ExecuteNonQuery();
                        bgl.connect().Close();
                        MessageBox.Show("Hasta üye İşlemi gerçekleşti.", "Üye Ol", MessageBoxButtons.OK);

                        textBox1.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        comboBox1.SelectedIndex = -1;
                        dateTimePicker1.Text = now.ToString();
                        textBox2.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                    }
                        
                }
                else
                {
                    timer2.Start();
                }
            }
            

           

            
            
        }

        int tick = 0,tick2=0,tick3=0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            tick++;
            toolStripStatusLabel1.Text = "Önceden bu tc ile üye olunmuş, lütfen bilgilerinizi tekrar kontrol ediniz.";
            if(tick==20)
            {
                timer1.Stop();
                toolStripStatusLabel1.Text = "";
            }

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            tick3++;
            toolStripStatusLabel1.Text = "Boş alan bıraktınız, lütfen kontrol ediniz !!!";
            if(tick3==20)
            {
                timer3.Stop();
                toolStripStatusLabel1.Text = "";
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            tick2++;
            toolStripStatusLabel1.Text = "Okudum kabul ediyorum kısmını işaretlemeniz gerekiyor!!!";
            if(tick2==10)
            {
                timer2.Stop();
                toolStripStatusLabel1.Text = "";
            }
        }
    }
}
