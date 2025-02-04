using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dentistclinicc.BLL; // BLL Katmanı bağlantısı
using Dentistclinic.Entity; // Entity Katmanı bağlantısı
using System.Data.OleDb;
using Tulpep.NotificationWindow; // Popup mesajları için
using Dentistclinicc.DAL;


namespace Dentistclinicc.PL
{
    public partial class RandevuAlPL : Form
    {
        public RandevuAlPL()
        {
            InitializeComponent();
        }

        private RandevuAlBLL bll = new RandevuAlBLL();
        private void btngiris_Click_Click(object sender, EventArgs e)
        {
           
                try
                {
                    // Kullanıcıdan gelen verileri alıp entity'ye atama
                    RandevuAl yeniRandevu = new RandevuAl
                    {
                        HastaAdi = textBox2.Text,
                        RandevuTürü = comboBox1.Text,
                        RandevuTarihi = dateTimePicker1.Value,
                        Saat = comboBox2.Text,
                        DoktorAdi = comboBox3.Text,
                        Mail = textBox1.Text
                    };

                    // Randevu ekleme işlemi
                    bool eklendiMi = false;
                    try
                    {
                        eklendiMi = RandevuAlBLL.RandevuEkle(yeniRandevu);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message); // Eğer aynı randevu varsa hata mesajı gösterir
                        return;
                    }

                    if (eklendiMi)
                    {
                        MessageBox.Show("Randevu başarıyla oluşturuldu.");
                        // E-posta gönderim işlemi
                        RandevuAlBLL.MailGonder1(yeniRandevu);

                        // Formu temizle
                        textBox2.Clear();
                        comboBox1.SelectedIndex = -1;
                        dateTimePicker1.Value = DateTime.Now;
                        comboBox2.SelectedIndex = -1;
                        comboBox3.SelectedIndex = -1;
                        textBox1.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Randevu oluşturulurken bir hata oluştu.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            




        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RandevuAlPL_Load(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {
            HastaAnaSayfaPL gecis= new HastaAnaSayfaPL();
            gecis.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
