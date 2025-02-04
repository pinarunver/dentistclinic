using Dentistclinic.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dentistclinicc.DAL;
using System.Data.OleDb;
using System.Net;
using System.Net.Mail;


namespace Dentistclinicc.BLL
{
    public class RandevuAlBLL
    {
        public static bool RandevuEkle(RandevuAl randevu)
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\onerp\\OneDrive\\Masaüstü\\dentistclinic\\dişaccess1.accdb";
            // Aynı gün, aynı saat ve aynı doktora randevu olup olmadığını kontrol et
            bool randevuVar = RandevuAlDAL.RandevuVarMi(randevu);
            if (randevuVar)
            {
                throw new Exception("Bu tarih, saat ve doktor için zaten bir randevu alınmış.");
            }

            try
            {
                using (OleDbConnection baglanti = new OleDbConnection(connectionString))
                {
                    string sorgu = "INSERT INTO Randevu (HastaAdi, RandevuTürü, RandevuTarihi, Saat, DoktorAdi, Mail) " +
                                   "VALUES (@HastaAdi, @RandevuTuru, @RandevuTarihi, @Saat, @DoktorAdi, @Mail)";

                    OleDbCommand komut = new OleDbCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@HastaAdi", randevu.HastaAdi);
                    komut.Parameters.AddWithValue("@RandevuTuru", randevu.RandevuTürü);
                    komut.Parameters.AddWithValue("@RandevuTarihi", randevu.RandevuTarihi.ToString("MM/dd/yyyy"));
                    komut.Parameters.AddWithValue("@Saat", randevu.Saat);
                    komut.Parameters.AddWithValue("@DoktorAdi", randevu.DoktorAdi);
                    komut.Parameters.AddWithValue("@Mail", randevu.Mail);

                    baglanti.Open();
                    int result = komut.ExecuteNonQuery();
                    return result > 0; // Etkilenen satır sayısını kontrol et
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Veritabanına ekleme sırasında hata oluştu: " + ex.Message);
            }
        }

        

        public static void MailGonder1(RandevuAl randevu)
        {
            try
            {
                string subject = "Randevu Bilgileriniz";
                string body = $"Merhaba {randevu.HastaAdi},\n\n" +
                              $"Randevu Türü: {randevu.RandevuTürü}\n" +
                              $"Randevu Tarihi: {randevu.RandevuTarihi:dd/MM/yyyy}\n" +
                              $"Saat: {randevu.Saat}\n" +
                              $"Doktor Adı: {randevu.DoktorAdi}\n\n" +
                              $"Randevunuza zamanında gelmenizi rica ederiz.\n" +
                              $"Sağlıklı günler dileriz!";

                MailMessage mail = new MailMessage
                {
                    From = new MailAddress("dentistclinic8181@gmail.com"),
                    Subject = subject,
                    Body = body
                };

                mail.To.Add(randevu.Mail);

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("dentistclinic8181@gmail.com", "apnt ufni lsir qbji"),
                    EnableSsl = true
                };

                smtpClient.Send(mail);
            }
            catch (Exception ex)
            {
                throw new Exception("E-posta gönderilirken hata oluştu: " + ex.Message);
            }
        }


        private RandevuAlDAL dal = new RandevuAlDAL();

        public void RandevuOnayla(RandevuAl randevu)
        {
            // İş kuralları eklenebilir
            if (string.IsNullOrEmpty(randevu.Mail))
                throw new Exception("Mail alanı boş bırakılamaz!");

            // Randevu veritabanına ekleniyor
            dal.RandevuEkle(randevu);

            // Mail gönderme işlemi
            MailGonder1(randevu);
        }

        
        }
    }

