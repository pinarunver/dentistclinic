using Dentistclinic.Entity;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dentistclinicc.DAL
{
    public class RandevuAlDAL
    {
        private accessconnection Accessconnection;

        // Yapıcı metot
        public RandevuAlDAL()
        {
            Accessconnection = new accessconnection();
        }
        private static string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\onerp\\OneDrive\\Masaüstü\\dentistclinic\\dişaccess1.accdb";
        public static bool RandevuVarMi(RandevuAl randevu)
        {
            using (OleDbConnection baglanti = new OleDbConnection(connectionString))
            {
                try
                {
                    string sorgu = "SELECT COUNT(*) FROM Randevu WHERE RandevuTarihi = @RandevuTarihi AND Saat = @Saat AND DoktorAdi = @DoktorAdi";
                    OleDbCommand komut = new OleDbCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@RandevuTarihi", randevu.RandevuTarihi.ToString("yyyy-MM-dd"));
                    komut.Parameters.AddWithValue("@Saat", randevu.Saat);
                    komut.Parameters.AddWithValue("@DoktorAdi", randevu.DoktorAdi);

                    baglanti.Open();
                    int count = Convert.ToInt32(komut.ExecuteScalar());
                    return count > 0; // Eğer eşleşen bir kayıt varsa true döner
                }
                catch (Exception ex)
                {
                    throw new Exception("Randevu kontrolü sırasında hata oluştu: " + ex.Message);
                }
            }
        }

       

        
            public void RandevuEkle(RandevuAl randevu)
        {
           
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    string query = "INSERT INTO Randevu (HastaAdi, RandevuTürü, RandevuTarihi, Saat, DoktorAdi, Mail) " +
                                   "VALUES (@HastaAdi, @RandevuTürü, @RandevuTarihi, @Saat, @DoktorAdi, @Mail)";

                    OleDbCommand cmd = new OleDbCommand(query, connection);
                    cmd.Parameters.AddWithValue("@HastaAdi", randevu.HastaAdi);
                    cmd.Parameters.AddWithValue("@RandevuTürü", randevu.RandevuTürü);

                    // Tarihi doğru şekilde ekle
                    cmd.Parameters.AddWithValue("@RandevuTarihi", randevu.RandevuTarihi.ToString("yyyy-MM-dd"));

                    cmd.Parameters.AddWithValue("@Saat", randevu.Saat);
                    cmd.Parameters.AddWithValue("@DoktorAdi", randevu.DoktorAdi);
                    cmd.Parameters.AddWithValue("@Mail", randevu.Mail);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            

        }
       
    }
}
