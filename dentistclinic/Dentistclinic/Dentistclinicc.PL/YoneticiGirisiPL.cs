using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Dentistclinicc.PL
{
    public partial class YoneticiGirisiPL : Form
    {
        public YoneticiGirisiPL()
        {
            InitializeComponent();
        }

        private void btngiris_Click_Click(object sender, EventArgs e)
        {
            // Sabit yönetici bilgileri
            string yoneticiTc = "12345678910";
            string yoneticiSifre = "123456";

            // Kullanıcıdan alınan bilgiler
            string girilenTc = textBox5.Text.Trim();
            string girilenSifre = textBox1.Text.Trim();

            // TC ve şifre kontrolü
            if (girilenTc == yoneticiTc && girilenSifre == yoneticiSifre)
            {
                MessageBox.Show("Giriş başarılı! Yönetici paneline yönlendiriliyorsunuz.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Yönetici paneline geçiş
                YoneticiAnaSayfaPL yoneticiPanel = new YoneticiAnaSayfaPL();
                yoneticiPanel.Show();
                this.Hide(); // Giriş formunu gizle
            }
            else
            {
                MessageBox.Show("Hatalı TC veya şifre! Lütfen tekrar deneyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {
            GirisPL girisPL = new GirisPL();
            girisPL.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void YoneticiGirisiPL_Load(object sender, EventArgs e)
        {

        }
    }
}
    

