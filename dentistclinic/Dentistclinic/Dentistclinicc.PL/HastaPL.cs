using Dentistclinic.Entity;
using Dentistclinicc.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dentistclinicc.PL
{
    public partial class HastaPL : Form
    {
        private HastaBLL hastaBLL = new HastaBLL();

        public HastaPL()
        {
            InitializeComponent();
        }
            // Hata mesajları ve doğrulama işlemleri
         
    private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Hasta yeniHasta = new Hasta
                {
                    HastaAdi = textBox1.Text,
                    HastaSoyadi = textBox2.Text,
                    DogumTarihi = dateTimePicker1.Value,
                    HastaTelefon = textBox4.Text,
                    HastaCinsiyet = textBox5.Text,
                    HastaTC = textBox3.Text,
                    HastaSifre = textBox6.Text,
                    Mail = textBox7.Text
                };

                bool basarili = hastaBLL.HastaEkle(yeniHasta);
                if (basarili)
                {
                    MessageBox.Show("Hasta başarıyla kaydedildi.");
                    Temizle();
                }
                else
                {
                    MessageBox.Show("Bu TC kimlik numarasına sahip bir hasta zaten kayıtlı.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}");
            }
            HastaGirisPL gecis=new HastaGirisPL();
            gecis.Show();
            this.Hide();
        }
    

        private void Temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            dateTimePicker1.Value = DateTime.Now;
        }


        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                errorProvider3.SetError(textBox1, "Bu alan boş geçilemez");
            }
            else
            {
                errorProvider3.Clear();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Trim() == "")
            {
                errorProvider1.SetError(textBox3, "Bu alan boş geçilemez");
            }
            else if (textBox3.Text.Length != 11)
            {
                errorProvider1.SetError(textBox3, "TC Kimlik numarası 11 karakterli olmalıdır.");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void HastaPL_Load(object sender, EventArgs e)
        {
            // Form açıldığında gerekli ayarları yapma
            this.Location = new Point(400, 100); // Form ekranın açılınca yerini belirleme
            errorProvider1.BlinkRate = 100000;
            errorProvider1.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text.Trim() == "")
            {
                errorProvider2.SetError(textBox4, "Bu alan boş geçilemez");
            }
            else if (textBox4.Text.Length != 10)
            {
                errorProvider2.SetError(textBox4, "Telefon numarası 10 haneli olmalıdır.");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            if (textBox2.Text.Trim() == "")
            {
                errorProvider4.SetError(textBox2, "Bu alan boş geçilemez");
            }
            else
            {
                errorProvider4.Clear();
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {
            HastaGirisPL gecis= new HastaGirisPL();
            gecis.Show();
            this.Hide();
        }
    }
}
