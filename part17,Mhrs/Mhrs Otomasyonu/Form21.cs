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
using System.Data.Common;

namespace Mhrs_Otomasyonu
{
    public partial class Form21 : Form
    {
        public Form21()
        {
            InitializeComponent();
        }









        Class1 bgl = new Class1();
        private void button5_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string dosyaYolu = openFileDialog1.FileName;
                pictureBox4.Image = Image.FromFile(dosyaYolu);
            }

        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form18 frm18 = new Form18();
            frm18.Show();
            this.Hide();
        }
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tbldoktorlar ", bgl.connect());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        public string sekretertc = "";
        public string sekretersifre = "";
        public string sekreterresim = "";
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into tbldoktorlar (doktoril,doktorilçe,doktorklinik,doktorhastane,doktormuayeneyeri,doktor,doktorresim,tc,sifre) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", bgl.connect());
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            komut.Parameters.AddWithValue("@p2", textBox2.Text);
            komut.Parameters.AddWithValue("@p3", textBox3.Text);
            komut.Parameters.AddWithValue("@p4", textBox4.Text);
            komut.Parameters.AddWithValue("@p5", textBox5.Text);
            komut.Parameters.AddWithValue("@p6", textBox6.Text);
            komut.Parameters.AddWithValue("@p7", openFileDialog1.FileName);
            komut.Parameters.AddWithValue("@p8", textBox25.Text);
            komut.Parameters.AddWithValue("@p9", textBox24.Text);
            komut.ExecuteNonQuery();
            bgl.connect().Close();
            MessageBox.Show("Doktor eklendi.", "Ekleme", MessageBoxButtons.OK);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listele();
        }
        string id = "";
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[row].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[row].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[row].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[row].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.Rows[row].Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.Rows[row].Cells[6].Value.ToString();
            textBox25.Text = dataGridView1.Rows[row].Cells[8].Value.ToString();
            textBox24.Text = dataGridView1.Rows[row].Cells[9].Value.ToString();
            pictureBox4.Image = Image.FromFile(dataGridView1.Rows[row].Cells[7].Value.ToString());
            id = dataGridView1.Rows[row].Cells[0].Value.ToString();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update tbldoktorlar set doktoril=@p1,doktorilçe=@p2,doktorklinik=@p3,doktorhastane=@p4,doktormuayeneyeri=@p5,doktor=@p6,doktorresim=@p7,tc=@p9,sifre=@p10 where doktorid=@p8", bgl.connect());
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            komut.Parameters.AddWithValue("@p2", textBox2.Text);
            komut.Parameters.AddWithValue("@p3", textBox3.Text);
            komut.Parameters.AddWithValue("@p4", textBox4.Text);
            komut.Parameters.AddWithValue("@p5", textBox5.Text);
            komut.Parameters.AddWithValue("@p6", textBox6.Text);
            komut.Parameters.AddWithValue("@p7", openFileDialog1.FileName);
            komut.Parameters.AddWithValue("@p8", id);
            komut.Parameters.AddWithValue("@p9", textBox25.Text);
            komut.Parameters.AddWithValue("@p10", textBox24.Text);
            komut.ExecuteNonQuery();
            bgl.connect().Close();
            MessageBox.Show("Doktor güncellendi.", "Güncelle", MessageBoxButtons.OK);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from tbldoktorlar where doktorid=@p1", bgl.connect());
            komut.Parameters.AddWithValue("@p1", id);
            komut.ExecuteNonQuery();
            bgl.connect().Close();
            MessageBox.Show("Doktor silindi.", "Silme", MessageBoxButtons.OK);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            int roww = dataGridView2.SelectedCells[0].RowIndex;
            SqlCommand komut = new SqlCommand("delete from tbldoktorrandevu where doktorrandevuid=@p1", bgl.connect());
            komut.Parameters.AddWithValue("@p1", dataGridView2.Rows[roww].Cells[0].Value.ToString());
            komut.ExecuteNonQuery();
            MessageBox.Show("Doktor Silindi", "Silmek", MessageBoxButtons.OK);
        }















        //randevu doktor eklemek
        void listele2()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select doktorrandevuid,doktor,tarih,saat,durum from tbldoktorrandevu inner join tbldoktorlar on tbldoktorrandevu.doktorid= tbldoktorlar.doktorid", bgl.connect());
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            bgl.connect().Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from tbldoktorlar where doktorid=@p1", bgl.connect());
            komut.Parameters.AddWithValue("@p1", comboBox1.SelectedValue);

            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                pictureBox6.Image = Image.FromFile(oku[7].ToString());
            }
            bgl.connect().Close();
           

            CheckBox[] checkBoxess = { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8, checkBox9, checkBox10, checkBox11, checkBox12, checkBox15, checkBox16, checkBox17, checkBox18 };


            foreach (CheckBox checkbox in checkBoxess)
            {
                checkbox.Checked = false;
                checkbox.Enabled = true;
            }
        }

        void temizlee()
        {
            checkBox1.Checked = false; checkBox2.Checked = false;
            checkBox3.Checked = false; checkBox4.Checked = false;
            checkBox5.Checked = false; checkBox6.Checked = false;
            checkBox7.Checked = false; checkBox8.Checked = false;
            checkBox9.Checked = false; checkBox10.Checked = false;
            checkBox11.Checked = false; checkBox11.Checked = false;
            checkBox12.Checked = false; checkBox15.Checked = false;
            checkBox16.Checked = false; checkBox17.Checked = false;
            checkBox18.Checked = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {

            CheckBox[] checkBoxes = { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8, checkBox9, checkBox10, checkBox11, checkBox12, checkBox15, checkBox16, checkBox17, checkBox18 };



            //şimdi ise seçilenlere baktık
            List<string> ekle = new List<string>();
            foreach (CheckBox checkbox in checkBoxes)
            {
                if (checkbox.Checked == true && checkbox.Enabled == true)
                {
                    ekle.Add(checkbox.Text);
                }
            }



            //eklemek
            foreach (string saaat in ekle)
            {
                SqlCommand komut2 = new SqlCommand("insert into tbldoktorrandevu (doktorid, tarih, saat) values (@p1, @p2, @p3)", bgl.connect());
                komut2.Parameters.AddWithValue("@p1", comboBox1.SelectedValue);
                komut2.Parameters.AddWithValue("@p2", dateTimePicker1.Text);
                komut2.Parameters.AddWithValue("@p3", saaat);
                komut2.ExecuteNonQuery();

            }


            bgl.connect().Close();
            MessageBox.Show("Doktora Randevu Atandı", "Randevu", MessageBoxButtons.OK);
            temizlee();

            foreach (CheckBox checkbox in checkBoxes)
{
    checkbox.Checked = false;
    checkbox.Enabled = true;
}


        }

        private void button8_Click(object sender, EventArgs e)
        {
            listele2();
        }

        private void dateTimePicker1_MouseEnter(object sender, EventArgs e)
        {
            //önceden seçili saatleri getir
            SqlCommand komut1 = new SqlCommand("select saat from tbldoktorrandevu where doktorid=@p1 and tarih=@p2", bgl.connect());
            komut1.Parameters.AddWithValue("@p1", comboBox1.SelectedValue);
            komut1.Parameters.AddWithValue("@p2", dateTimePicker1.Text);
            SqlDataReader oku = komut1.ExecuteReader();

            List<string> saat = new List<string>();

            // Burada while döngüsüne ihtiyacınız yok, çünkü tek bir oku.Read() çağrısı yeterli olacak.
            // Bu nedenle, aşağıdaki şekilde güncelleyebilirsiniz:
            while (oku.Read())
            {
                saat.Add(oku[0].ToString());
            }


            oku.Close();

            CheckBox[] checkBoxesss = { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8, checkBox9, checkBox10, checkBox11, checkBox12, checkBox15, checkBox16, checkBox17, checkBox18 };

            // Artık önceden seçili saatleri kontrol etmek için for döngüsü içerisine gireceksiniz.
            // while döngüsünü burada kullanmıyorsunuz çünkü yukarıda tek bir oku.Read() çağrısı yaptınız.
            for (int i = 0; i < checkBoxesss.Length; i++)
            {
                if (saat.Contains(checkBoxesss[i].Text))
                {
                    checkBoxesss[i].Checked = true;
                    checkBoxesss[i].Enabled = false;
                }
            }

        }



















        //ortada
        private void Form21_Load(object sender, EventArgs e)
        {
            Form20 form20 = new Form20();
            label9.Text = sekretertc;


            //listele
            listele();

            //comboboxa doktor çekmek
            SqlDataAdapter da = new SqlDataAdapter("select * from tbldoktorlar", bgl.connect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.ValueMember = "doktorid";
            comboBox1.DisplayMember = "doktor";
            comboBox1.DataSource = dt;


            //listele
            listele2();

            //sekreterfoto
            pictureBox8.Image = Image.FromFile(sekreterresim);


            //listele sekreter
            DataTable dt2 = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from tbl_sekreterler", bgl.connect());
            dataAdapter.Fill(dt2);
            dataGridView3.DataSource = dt2;


            //listele aşı rendevu
            DataTable dt3 = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter("select * from tbl_asirandevu", bgl.connect());
            da3.Fill(dt3);
            dataGridView4.DataSource = dt3;



            //listele ezcacı
            DataTable dt4 = new DataTable();
            SqlDataAdapter da4 = new SqlDataAdapter("select * from tbl_eczaci", bgl.connect());
            da4.Fill(dt4);
            dataGridView5.DataSource = dt4;

            //ailehekimi listele
            DataTable dt8 = new DataTable();
            SqlDataAdapter da8 = new SqlDataAdapter("select * from tbl_ailehekimi ", bgl.connect());
            da8.Fill(dt8);
            dataGridView6.DataSource = dt8;


            //ailehekini comboboxa getir
            DataTable dt9 = new DataTable();
            SqlDataAdapter da9 = new SqlDataAdapter("select * from tbl_ailehekimi",bgl.connect());
            da9.Fill(dt9);
            comboBox2.ValueMember = "ailehekimiid";
            comboBox2.DisplayMember = "ailehekimi";
            comboBox2.DataSource= dt9;

            //ailehekimirandevu listele
            DataTable dt10 = new DataTable();
            SqlDataAdapter da10 = new SqlDataAdapter("select id,ailehekimi,tarih,saat,durum from tbl_ailehekimirandevu inner join tbl_ailehekimi on tbl_ailehekimirandevu.ailehekimiid= tbl_ailehekimi.ailehekimiid", bgl.connect());
            da10.Fill(dt10);
            dataGridView7.DataSource = dt10;
            bgl.connect().Close();
        }


















        //sekreter işlemleri
        private void button16_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update tbl_sekreterler set sekreterşifre=@p1 , sekreterresim=@p2",bgl.connect());
            komut.Parameters.AddWithValue("@p1",textBox18.Text);
            komut.Parameters.AddWithValue("@p2",openFileDialog1.FileName);
            komut.ExecuteNonQuery();
            MessageBox.Show("Güncellendiniz","Güncelleme",MessageBoxButtons.OK);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox8.Image=Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into tbl_sekreterler (sekretertc,sekreterşifre,sekreterresim) values(@p1,@p2,@p3)",bgl.connect());
            komut.Parameters.AddWithValue("@p1",textBox12.Text);
            komut.Parameters.AddWithValue("@p2", textBox11.Text);
            komut.Parameters.AddWithValue("@p3",openFileDialog1.FileName);
            komut.ExecuteNonQuery();
            bgl.connect().Close();
            MessageBox.Show("Sekreter eklendi", "Ekleme", MessageBoxButtons.OK);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox7.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DataTable dt=new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from tbl_sekreterler",bgl.connect());  
            dataAdapter.Fill(dt);
            dataGridView3.DataSource = dt;  

        }
        string idd = "";
        private void dataGridView3_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int row = dataGridView3.SelectedCells[0].RowIndex;
            textBox12.Text = dataGridView3.Rows[row].Cells[1].Value.ToString();
            textBox11.Text = dataGridView3.Rows[row].Cells[2].Value.ToString();
            pictureBox7.Image=Image.FromFile( dataGridView3.Rows[row].Cells[3].Value.ToString());
            idd= dataGridView3.Rows[row].Cells[0].Value.ToString();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update tbl_sekreterler set sekretertc=@p1,sekreterşifre=@p2,sekreterresim=@p3 where sekreterİd=@p4",bgl.connect());
            komut.Parameters.AddWithValue("@p1",textBox12.Text);
            komut.Parameters.AddWithValue("@p2",textBox11.Text);
            komut.Parameters.AddWithValue("@p3",openFileDialog1.FileName);
            komut.Parameters.AddWithValue("@p4", idd);
            komut.ExecuteNonQuery();
            bgl.connect().Close();
            MessageBox.Show("Sekreter güncellendi.", "Güncelleme", MessageBoxButtons.OK);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from tbl_sekreterler where sekreterid=@p1",bgl.connect());
            komut.Parameters.AddWithValue("@p1",idd);
            komut.ExecuteNonQuery();
            bgl.connect().Close();
            MessageBox.Show("Sekreter silindi.", "Silmek", MessageBoxButtons.OK);
        }






















        //aşi randevu eklemek
        string deger = "";
        private void button21_Click(object sender, EventArgs e)
        {
            CheckBox[] checkboxes2 = { checkBox14, checkBox13, checkBox19, checkBox20, checkBox21, checkBox22, checkBox23, checkBox24, checkBox25, checkBox26, checkBox27, checkBox28, checkBox29, checkBox30, checkBox31, checkBox31, checkBox32 };
            List<string> ekle2 = new List<string>();
            
            foreach (CheckBox checkBox in checkboxes2)
            {
                if(checkBox.Checked==true && checkBox.Enabled==true)
                {
                    ekle2.Add(checkBox.Text);
                }
            }


            foreach(string ekle in ekle2)
            {
                SqlCommand komut = new SqlCommand("insert into tbl_asirandevu (asituru,il,ilce,hastane,muayene,tarih,saat) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7)", bgl.connect());

                komut.Parameters.AddWithValue("@p1", deger);
                komut.Parameters.AddWithValue("@p2", textBox14.Text);
                komut.Parameters.AddWithValue("@p3", textBox13.Text);
                komut.Parameters.AddWithValue("@p4", textBox10.Text);
                komut.Parameters.AddWithValue("@p5", textBox9.Text);
                komut.Parameters.AddWithValue("@p6", dateTimePicker2.Text);
                komut.Parameters.AddWithValue("@p7", ekle);
                komut.ExecuteNonQuery();
            }
            bgl.connect().Close();
            MessageBox.Show("Aşı Randevusu eklendi","Eklemek",MessageBoxButtons.OK);

            foreach (CheckBox checkBox in checkboxes2)
            {
                checkBox .Checked = false;
                checkBox .Enabled = true;
            }

        }

        private void button18_Click(object sender, EventArgs e)
        {
            deger = "Biontech";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            deger = "Sinovac";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            deger = "Turkovac";
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            CheckBox[] checkboxes2 = { checkBox14, checkBox13, checkBox19, checkBox20, checkBox21, checkBox22, checkBox23, checkBox24, checkBox25, checkBox26, checkBox27, checkBox28, checkBox29, checkBox30, checkBox31, checkBox31, checkBox32 };

            foreach (CheckBox checkBox in checkboxes2)
            {
                checkBox.Checked = false;
                checkBox.Enabled = true;
            }

            SqlCommand komut = new SqlCommand("select saat from tbl_asirandevu where asituru=@p1 and il=@p2 and ilce=@p3 and hastane=@p4 and muayene=@p5 and tarih=@p6", bgl.connect());
            komut.Parameters.AddWithValue("@p1", deger);
            komut.Parameters.AddWithValue("@p2", textBox14.Text);
            komut.Parameters.AddWithValue("@p3", textBox13.Text);
            komut.Parameters.AddWithValue("@p4", textBox10.Text);
            komut.Parameters.AddWithValue("@p5", textBox9.Text);
            komut.Parameters.AddWithValue("@p6", dateTimePicker2.Text);

            List<string> saat2 = new List<string>();
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                saat2.Add(oku[0].ToString());
            }

            foreach (string saat in saat2)
            {
                foreach (CheckBox box in checkboxes2)
                {
                    if (box.Text == saat)
                    {
                        box.Checked = true;
                        box.Enabled = false;
                    }
                }

            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_asirandevu",bgl.connect());
            da.Fill(dt);
            dataGridView4.DataSource = dt;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            SqlCommand komut=new SqlCommand("delete from tbl_asirandevu where aşırandevuid=@p1",bgl.connect());
            int roww = dataGridView4.SelectedCells[0].RowIndex;

            komut.Parameters.AddWithValue("@p1", dataGridView4.Rows[roww].Cells[0].Value.ToString());
            komut.ExecuteNonQuery();
            bgl.connect().Close();
            MessageBox.Show("Aşı Randevusu silindi.","Silmek",MessageBoxButtons.OK);
        }























        private void button26_Click(object sender, EventArgs e)
        {
            SqlCommand komut=new SqlCommand("insert into tbl_eczaci (eczaciadsoyad,eczacitc,eczacisifre) values(@p1,@p2,@p3)",bgl.connect());
            komut.Parameters.AddWithValue("@p1",textBox15.Text);
            komut.Parameters.AddWithValue("@p2", textBox8.Text);
            komut.Parameters.AddWithValue("@p3", textBox7.Text);
            komut.ExecuteNonQuery();
            bgl.connect().Close();
            MessageBox.Show("Eczacı eklendi.","Eklemek",MessageBoxButtons.OK);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_eczaci", bgl.connect());
            da.Fill(dt);
            dataGridView5.DataSource = dt;
        }

        string id2 = "";
        private void button24_Click(object sender, EventArgs e)
        {
            
            SqlCommand komut = new SqlCommand("update tbl_eczaci set eczaciadsoyad=@p1,eczacitc=@p2,eczacisifre=@p3 where eczaciid=@p4",bgl.connect());
            komut.Parameters.AddWithValue("@p1",textBox15.Text);
            komut.Parameters.AddWithValue("@p2",textBox8.Text);
            komut.Parameters.AddWithValue("@p3",textBox7.Text);
            komut.Parameters.AddWithValue("@p4", id2);
            komut.ExecuteNonQuery();
            bgl.connect().Close();
            MessageBox.Show("Eczacı güncellendi.", "Güncellemek", MessageBoxButtons.OK);
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridView5.SelectedCells[0].RowIndex;
            textBox15.Text = dataGridView5.Rows[row].Cells[1].Value.ToString();
            textBox8.Text= dataGridView5.Rows[row].Cells[2].Value.ToString();
            textBox7.Text= dataGridView5.Rows[row].Cells[3].Value.ToString();
            int roww = dataGridView5.SelectedCells[0].RowIndex;
            id2 = dataGridView5.Rows[roww].Cells[0].Value.ToString();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from tbl_eczaci where eczaciid=@p1", bgl.connect());
            komut.Parameters.AddWithValue("@p1",id2);
            komut.ExecuteNonQuery();
            bgl.connect().Close();
            MessageBox.Show("Eczacı silindi.", "Silmek", MessageBoxButtons.OK);
        }
























        private void button30_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into tbl_ailehekimi (il,ilce,mahalle,hastane,ailehekimi,tc,sifre) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7)", bgl.connect());
            komut.Parameters.AddWithValue("@p1", textBox22.Text);
            komut.Parameters.AddWithValue("@p2", textBox21.Text);
            komut.Parameters.AddWithValue("@p3", textBox20.Text);
            komut.Parameters.AddWithValue("@p4", textBox19.Text);
            komut.Parameters.AddWithValue("@p5", textBox16.Text);
            komut.Parameters.AddWithValue("@p6", textBox23.Text);
            komut.Parameters.AddWithValue("@p7", textBox17.Text);
            komut.ExecuteNonQuery();
            bgl.connect().Close();
            MessageBox.Show("Aile Hekimi eklendi.", "Ekleme", MessageBoxButtons.OK);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_ailehekimi ", bgl.connect());
            da.Fill(dt);
            dataGridView6.DataSource = dt;
        }
        string id3 = "";
        private void button28_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update tbl_ailehekimi set il=@p1,ilce=@p2,mahalle=@p3,hastane=@p4,ailehekimi=@p5,tc=@p7,sifre=@p8 where ailehekimiid=@p6", bgl.connect());
            komut.Parameters.AddWithValue("@p1", textBox22.Text);
            komut.Parameters.AddWithValue("@p2", textBox21.Text);
            komut.Parameters.AddWithValue("@p3", textBox20.Text);
            komut.Parameters.AddWithValue("@p4", textBox19.Text);
            komut.Parameters.AddWithValue("@p5", textBox16.Text);
            komut.Parameters.AddWithValue("@p7", textBox23.Text);
            komut.Parameters.AddWithValue("@p8", textBox17.Text);
            komut.Parameters.AddWithValue("@p6", id3);
           
            komut.ExecuteNonQuery();
            bgl.connect().Close();
            MessageBox.Show("Aile Hekimi güncellendi.", "Güncelle", MessageBoxButtons.OK);
        }

        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridView6.SelectedCells[0].RowIndex;
            textBox22.Text = dataGridView6.Rows[row].Cells[1].Value.ToString();
            textBox21.Text = dataGridView6.Rows[row].Cells[2].Value.ToString();
            textBox20.Text = dataGridView6.Rows[row].Cells[3].Value.ToString();
            textBox19.Text = dataGridView6.Rows[row].Cells[4].Value.ToString();
            textBox16.Text = dataGridView6.Rows[row].Cells[5].Value.ToString();
            textBox23.Text = dataGridView6.Rows[row].Cells[6].Value.ToString();
            textBox17.Text = dataGridView6.Rows[row].Cells[7].Value.ToString();
            id3 = dataGridView6.Rows[row].Cells[0].Value.ToString();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from tbl_ailehekimi where ailehekimiid=@p1", bgl.connect());
            komut.Parameters.AddWithValue("@p1", id3);
            komut.ExecuteNonQuery();
            bgl.connect().Close();
            MessageBox.Show("Aile Hekimi silindi.", "Silme", MessageBoxButtons.OK);
        }

        private void button33_Click(object sender, EventArgs e)
        {
            CheckBox[] checkboxes2 = { checkBox48, checkBox47, checkBox46, checkBox45, checkBox44, checkBox43, checkBox42, checkBox41, checkBox40, checkBox39, checkBox38, checkBox37, checkBox36, checkBox35, checkBox34, checkBox33 };
            
            //şimdi ise seçilenlere baktık
            List<string> ekle = new List<string>();
            foreach (CheckBox checkbox in checkboxes2)
            {
                if (checkbox.Checked == true && checkbox.Enabled == true)
                {
                    ekle.Add(checkbox.Text);
                }
            }



            //eklemek
            foreach (string saaat in ekle)
            {
                SqlCommand komut2 = new SqlCommand("insert into tbl_ailehekimirandevu (ailehekimiid, tarih, saat) values (@p1, @p2, @p3)", bgl.connect());
                komut2.Parameters.AddWithValue("@p1", comboBox2.SelectedValue);
                komut2.Parameters.AddWithValue("@p2", dateTimePicker3.Text);
                komut2.Parameters.AddWithValue("@p3", saaat);
                komut2.ExecuteNonQuery();

            }


            bgl.connect().Close();
            MessageBox.Show("Aile Hekimine Randevu Atandı", "Randevu", MessageBoxButtons.OK);
            

            foreach (CheckBox checkbox in checkboxes2)
{
    checkbox.Checked = false;
    checkbox.Enabled = true;
}

        }


        private void button31_Click(object sender, EventArgs e)
        {
            DataTable dt10 = new DataTable();
            SqlDataAdapter da10 = new SqlDataAdapter("select id,ailehekimi,tarih,saat,durum from tbl_ailehekimirandevu inner join tbl_ailehekimi on tbl_ailehekimirandevu.ailehekimiid= tbl_ailehekimi.ailehekimiid", bgl.connect());
            da10.Fill(dt10);
            dataGridView7.DataSource = dt10;
            bgl.connect().Close();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            int roww = dataGridView7.SelectedCells[0].RowIndex;
            SqlCommand komut = new SqlCommand("delete from tbl_ailehekimirandevu where id=@p1", bgl.connect());
            komut.Parameters.AddWithValue("@p1", dataGridView7.Rows[roww].Cells[0].Value.ToString());
            komut.ExecuteNonQuery();
            MessageBox.Show("Aile Hekimi Silindi", "Silmek", MessageBoxButtons.OK);
        }


        private void dateTimePicker3_MouseEnter(object sender, EventArgs e)
        {
            CheckBox[] checkboxes2 = { checkBox48, checkBox47, checkBox46, checkBox45, checkBox44, checkBox43, checkBox42, checkBox41, checkBox40, checkBox39, checkBox38, checkBox37, checkBox36, checkBox35, checkBox34, checkBox33 };

            foreach (CheckBox checkbox in checkboxes2)
            {
                checkbox.Checked = false;
                checkbox.Enabled = true;
            }

            //önceden seçili saatleri getir
            SqlCommand komut1 = new SqlCommand("select saat from tbl_ailehekimirandevu where ailehekimiid=@p1 and tarih=@p2", bgl.connect());
            komut1.Parameters.AddWithValue("@p1", comboBox2.SelectedValue);
            komut1.Parameters.AddWithValue("@p2", dateTimePicker3.Text);
            SqlDataReader oku = komut1.ExecuteReader();

            List<string> saat = new List<string>();

            while (oku.Read())
            {
                saat.Add(oku[0].ToString());
            }


            oku.Close();

            for (int i = 0; i < checkboxes2.Length; i++)
            {
                if (saat.Contains(checkboxes2[i].Text))  //******
                {
                    checkboxes2[i].Checked = true;
                    checkboxes2[i].Enabled = false;
                }
            }
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void Form21_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
