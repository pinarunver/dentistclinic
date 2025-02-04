using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dentistclinicc.PL
{
    public partial class YoneticiAnaSayfaPL : Form
    {
        public YoneticiAnaSayfaPL()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void btngiris_Click_Click(object sender, EventArgs e)
        {
            DoktorRandevuDurumPL gecis=new DoktorRandevuDurumPL();
            gecis.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            HastaRandevuTabloPL gecis = new HastaRandevuTabloPL();
            gecis.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            YoneticiGirisiPL gecis  =new YoneticiGirisiPL();
            gecis.Show();   
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void YoneticiAnaSayfaPL_Load(object sender, EventArgs e)
        {

        }
    }
}
