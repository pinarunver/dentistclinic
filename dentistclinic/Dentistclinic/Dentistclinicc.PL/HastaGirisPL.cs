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
    public partial class HastaGirisPL : Form
    {
        private HastaGirisBLL hastaGirisBLL;
        public HastaGirisPL()
        {
            InitializeComponent();
            hastaGirisBLL = new HastaGirisBLL(); // Nesneyi burada oluşturun
        }
        OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\onerp\\OneDrive\\Masaüstü\\dentistclinic\\dişaccess1.accdb");



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Veritabanı bağlantısı için bağlantı dizesi (Access dosyanızın konumunu ayarlayın)
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\onerp\OneDrive\Masaüstü\dentistclinic\dişaccess1.accdb";

            // Girilen TC ve Şifre
            string girilenTC = textBox5.Text;
            string girilenSifre = textBox1.Text;

            // SQL sorgusu
            string query = "SELECT * FROM Hasta WHERE HastaTC = @HastaTC AND HastaSifre = @Sifre";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@HastaTC", girilenTC);
                        command.Parameters.AddWithValue("@Sifre", girilenSifre);

                        OleDbDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            // HastaAnaSayfaPL formunu aç
                            HastaAnaSayfaPL hastaAnasayfa = new HastaAnaSayfaPL();

                            // Bilgileri yeni formdaki textboxlara aktar
                            hastaAnasayfa.textBox1.Text = reader["HastaAdi"].ToString();
                            hastaAnasayfa.textBox2.Text = reader["HastaSoyadi"].ToString();
                            hastaAnasayfa.textBox3.Text = reader["HastaTC"].ToString();
                            hastaAnasayfa.textBox4.Text = reader["HastaTelefon"].ToString();
                            hastaAnasayfa.dateTimePicker1.Text = reader["DogumTarihi"].ToString();
                            hastaAnasayfa.textBox5.Text = reader["HastaCinsiyet"].ToString();
                            hastaAnasayfa.textBox6.Text = reader["HastaSifre"].ToString();
                            hastaAnasayfa.textBox7.Text = reader["Mail"].ToString();

                            // Yeni formu göster
                            hastaAnasayfa.Show();

                            // Mevcut formu gizle
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("TC veya şifre hatalı!", "Giriş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


           /* try
            {
                // Kullanıcıdan giriş bilgilerini al
                string hastaTC = textBox5.Text.Trim();  // TC Kimlik No
                string hastaSifre = textBox1.Text.Trim(); // Şifre
             

                // Giriş kontrolü
                bool girisBasarili = hastaGirisBLL.GirisYap(hastaTC, hastaSifre);

                if (girisBasarili)
                {
                    MessageBox.Show("Giriş başarılı. Hoş geldiniz!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Ana sayfaya geçiş yap
                    this.Hide();
                    HastaAnaSayfaPL anaSayfa = new HastaAnaSayfaPL();
                    anaSayfa.Show();
                }
                else
                {
                    MessageBox.Show("TC Kimlik No veya Şifre hatalı.", "Giriş Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Hata mesajını göster
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }*/


    



        private void HastaGirisPL_Load(object sender, EventArgs e)
        {
            this.Location = new Point(300, 200); // Form başlangıç pozisyonu
        }

        private void HastaGirisPL_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Boşluk girişini engelle
            e.Handled = char.IsWhiteSpace(e.KeyChar);
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Sadece rakam girişine izin ver
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnkaydol_click(object sender, EventArgs e)
        {
            
        }

        private void backgroundWorker1_DoWork_1(object sender, DoWorkEventArgs e)
        {
            // Arkada borç veya veri kontrol işlemleri yapılabilir
        }

        private void backgroundWorker1_RunWorkerCompleted_1(object sender, RunWorkerCompletedEventArgs e)
        {
            // Arka plan işlemi tamamlandığında yapılacaklar
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Ana ekrana yönlendirme
            HastaPL hastaEkran = new HastaPL();
            hastaEkran.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            GirisPL girisPL = new GirisPL();
            girisPL.Show();
            this.Hide();
        }
    }
}
