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
    public partial class Form18 : Form
    {
        public Form18()
        {
            InitializeComponent();
        }

        int artış = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Image = ımageList1.Images[artış];
            if (artış == ımageList1.Images.Count-1)
            {
                artış = 0;
            }
            else
            {
                artış++;
            }
        }

        

        private void beyazToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        private void maviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.DeepSkyBlue;
        }

        private void kırmızıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor= Color.IndianRed;  
        }

        private void kahverengiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Brown;
        }

        private void pembeBarbieGirlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.LightPink;
        }

        private void yeşilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.LightGreen;
        }

        private void sarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Yellow;
        }

        private void hakkımızdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("  Merhabalar ben İrem Ertürk,kendini geliştirmeye çalışan hayatında inişler çıkışlar olan ama yinede yoluna devam eden bir kızım sonunda ne olucağını bilmeden sadece yürüyorum ve bazen umutsuzluklara kapılsamda biliyorum ki her zaman bir ışık olucak dileğim şu ki ömrümü güzel geçirip faydalı işlerde bulunmak ahirettede huzurlu bir hayat sürmek,umarım hepinizin hayalleri gerçekleşir, sağlıklı günler dilerim   :) ", "Hakkımda <3 ",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void randevuAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mhrs mhrs = new Mhrs();
            mhrs.Show();
            this.Hide();
        }

        private void radyoEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void radyoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form19 form19 = new Form19();
            form19.Show();
                
        }

        private void sekreterGirişiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form20 frm20=new Form20();
            frm20.Show();
            this.Hide();
        }

        private void Form18_Load(object sender, EventArgs e)
        {

        }

        private void doktorGrişiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form22 frm22= new Form22();
            frm22.Show();
            this.Hide();
        }

        private void aileHekimiGirişiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form26 form26=new Form26();
            form26.Show();
            this.Hide();
        }

        private void eczaneGirişiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form24 form24=new Form24();
            form24.Show();
            this.Hide();
        }

        private void Form18_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
