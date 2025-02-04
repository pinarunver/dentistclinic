using Dentistclinic.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dentistclinicc.BLL;
using System.Data.OleDb;


namespace Dentistclinicc.PL
{
    public partial class HastaAnaSayfaPL : Form
    {
        public HastaAnaSayfaPL()
        {
            InitializeComponent();
        }

        private void HastaAnaSayfaPL_Load(object sender, EventArgs e)
        {

        }

        private void btngiris_Click_Click(object sender, EventArgs e)
        {
           
                // Veritabanı bağlantı dizesi (Access veritabanınızın yolunu düzenleyin)
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\onerp\OneDrive\Masaüstü\dentistclinic\dişaccess1.accdb";

                // Hasta adını HastaAnaSayfaPL formundan al
                string hastaAdi = textBox1.Text;

                // SQL sorgusu (Hasta tablosundan adı eşleşen kaydı getir)
                string query = "SELECT Mail, HastaAdi FROM Hasta WHERE HastaAdi = @HastaAdi";

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        using (OleDbCommand command = new OleDbCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@HastaAdi", hastaAdi);

                            OleDbDataReader reader = command.ExecuteReader();

                            if (reader.Read())
                            {
                                // Yeni formu aç ve bilgileri aktar
                                RandevuAlPL randevuAlForm = new RandevuAlPL();

                                randevuAlForm.textBox2.Text = reader["HastaAdi"].ToString();
                                randevuAlForm.textBox1.Text = reader["Mail"].ToString();

                                randevuAlForm.Show();

                                // Mevcut formu gizle (isteğe bağlı)
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Hasta bilgisi bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.Message, "Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tc = textBox3.Text;
            string mail = textBox7.Text;
            string telefon = textBox4.Text;
            string sifre = textBox6.Text;

            if (string.IsNullOrEmpty(tc) || tc.Length != 11)
            {
                MessageBox.Show("Geçerli bir TC Kimlik Numarası giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(mail) || string.IsNullOrEmpty(telefon) || string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            HastaAnaSayfaBLL hastaBLL = new HastaAnaSayfaBLL();
            bool sonuc = hastaBLL.HastaBilgiGuncelle(tc, mail, telefon, sifre);

            if (sonuc)
            {
                MessageBox.Show("Bilgiler başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Güncelleme sırasında bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string tc = textBox3.Text;

            // TC Kimlik Numarası doğrulama
            if (string.IsNullOrEmpty(tc) || tc.Length != 11)
            {
                MessageBox.Show("Geçerli bir TC Kimlik Numarası giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // BLL katmanını çağırarak hastayı silme işlemi yapıyoruz
            HastaAnaSayfaBLL hastaBLL = new HastaAnaSayfaBLL();
            bool sonuc = hastaBLL.SilHasta(tc);

            // Silme işlemi başarılıysa kullanıcıya bilgi veriyoruz
            if (sonuc)
            {
                MessageBox.Show("Hasta kaydı başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Silme işlemi sırasında bir hata oluştu veya bu TC'ye ait kayıt bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            HastaGirisPL gecis=new HastaGirisPL();
            gecis.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {
            HastaGirisPL gecis=new HastaGirisPL();
            gecis.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
    

