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
    public partial class GirisPL : Form
    {
        public GirisPL()
        {
            InitializeComponent();
        }

        private void btngiris_Click_Click(object sender, EventArgs e)
        {
            YoneticiGirisiPL gecis = new YoneticiGirisiPL();
            gecis.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HastaGirisPL gecis = new HastaGirisPL();
            gecis.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void GirisPL_Load(object sender, EventArgs e)
        {

        }
    }
}
