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
    public class HastaGirisDAL
    {



        private accessconnection Accessconnection;

        // Yapıcı metot
        public HastaGirisDAL()
        {
            Accessconnection = new accessconnection();
        }
        private string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\onerp\\OneDrive\\Masaüstü\\dentistclinic\\dişaccess1.accdb";
        public bool GirisKontrol(string hastaTC, string sifre)
        {
            string query = "SELECT COUNT(*) FROM Hasta WHERE HastaTC = @HastaTC AND HastaSifre = @HastaSifre";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    // Parametreleri ekle
                    cmd.Parameters.AddWithValue("@HastaTC", hastaTC);
                    cmd.Parameters.AddWithValue("@HastaSifre", sifre);

                    conn.Open();
                    int count = (int)cmd.ExecuteScalar(); // Sorgudan dönen sayıyı alır
                    return count > 0; // Eğer kayıt varsa true, yoksa false döner
                }
            }
        }



        // Tüm hastaları listeleme

        public List<Hasta> GetAllItems()
        {
            OleDbCommand cmd = Accessconnection.GetOleDbCommand(); // Bağlantı hazır, komut yazılmadı
            cmd.CommandText = "SELECT * FROM Hasta"; // Hasta tablosundaki tüm veriler

            List<Hasta> hastas = new List<Hasta>();
            OleDbDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Hasta hasta = new Hasta();
                hasta.HastaID = Convert.ToInt32(rdr["HastaID"]);
                hasta.HastaAdi = rdr["HastaAdi"].ToString();
                hasta.HastaSoyadi = rdr["HastaSoyadi"].ToString();
                hasta.DogumTarihi = Convert.ToDateTime(rdr["DogumTarihi"]);
                hasta.HastaTelefon = rdr["HastaTelefon"].ToString();
                hasta.HastaCinsiyet = rdr["HastaCinsiyet"].ToString();
                hasta.HastaTC = rdr["HastaTC"].ToString();

                hastas.Add(hasta);
            }
            return hastas;
        }

        public string Arama(HastaGiris hastaGiris)
        {
            using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\onerp\\OneDrive\\Masaüstü\\dentistclinic\\dişaccess1.accdb"))
            {
                connection.Open();
                string query = "SELECT HastaTC FROM Hasta WHERE HastaTC= ? AND Sifre = ?";
                OleDbCommand cmd = new OleDbCommand(query, connection);

                // Parametreleri sırayla ekleyin
                cmd.Parameters.Add(new OleDbParameter("@HastaTC", hastaGiris.HastaTC));
                cmd.Parameters.Add(new OleDbParameter("@HastaSifre", hastaGiris.HastaSifre));

                var result = cmd.ExecuteScalar();
                return result?.ToString();
            }

        }


        // Hasta bilgilerini arama ve döndürme (Textbox doldurma için)
        /*public string Arama(Hasta hasta)
        {
            OleDbCommand cmd = Accessconnection.GetOleDbCommand(); // Bağlantı hazır, komut yazılmadı
            cmd.CommandText = "SELECT * FROM Hasta";
            OleDbDataReader rdr = cmd.ExecuteReader();

            string hastaBilgi = "";
            while (rdr.Read())
            {
                if ((rdr["HastaTC"].ToString() == hasta.HastaTC))
                {
                    hastaBilgi = rdr["HastaAdi"].ToString() + " " + rdr["HastaSoyadi"].ToString();
                    break;
                }
            }
            return hastaBilgi;
        }
        */

        // Yeni hasta ekleme
        /* public string AddNewItem(Hasta hasta)
         {
             string cmdText = "INSERT INTO [Hasta] ([HastaAdi],[HastaSoyadi],[DogumTarihi],[HastaTelefon],[Cinsiyet],[HastaTC])";
             cmdText += String.Format(" Values('{0}','{1}','{2}','{3}','{4}','{5}')", hasta.HastaAdi, hasta.HastaSoyadi, hasta.DogumTarihi.ToString("yyyy-MM-dd"), hasta.HastaTelefon, hasta.Cinsiyet, hasta.HastaTC);

             OleDbCommand cmd = Accessconnection.GetOleDbCommand();
             cmd.CommandText = cmdText;
             cmd.ExecuteNonQuery();
             return hasta.HastaAdi + " " + hasta.HastaSoyadi;
         }*/
        public string AddNewItem(HastaGiris hastaGiris)
        {
            using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\onerp\\OneDrive\\Masaüstü\\dentistclinic\\dişaccess1.accdb"))
            {
                connection.Open();
                string query = "INSERT INTO HastaGiris (Kullaniciadi, Sifre, HastaAdi, HastaSoyadi) VALUES (?, ?, ?, ?)";
                OleDbCommand cmd = new OleDbCommand(query, connection);
                cmd.Parameters.AddWithValue("?", hastaGiris.Kullaniciadi);
                cmd.Parameters.AddWithValue("?", hastaGiris.HastaSifre);
                cmd.Parameters.AddWithValue("?", hastaGiris.HastaAdi);
                cmd.Parameters.AddWithValue("?", hastaGiris.HastaSoyadi);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0 ? hastaGiris.Kullaniciadi : null;
            }
        }


        // Hasta silme
        public int DeleteItem(HastaGiris hastaGiris)
        {
            using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\onerp\\OneDrive\\Masaüstü\\dentistclinic\\dişaccess1.accdb"))
            {
                connection.Open();
                string query = "DELETE FROM HastaGiris WHERE Kullaniciadi = ?";
                OleDbCommand cmd = new OleDbCommand(query, connection);
                cmd.Parameters.AddWithValue("?", hastaGiris.Kullaniciadi);

                return cmd.ExecuteNonQuery(); // Etkilenen satır sayısını döndürür
            }
        }

        /* public int DeleteItem(Hasta hasta)
         {
             OleDbCommand cmd = Accessconnection.GetOleDbCommand();
             cmd.CommandText = string.Format("DELETE FROM Hasta WHERE HastaTC='{0}'", hasta.HastaTC);
             return cmd.ExecuteNonQuery();
         }*/

        // Hasta güncelleme
        public int UpdateItem(HastaGiris hastaGiris)
        {
            using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\onerp\\OneDrive\\Masaüstü\\dentistclinic\\dişaccess1.accdb"))
            {
                connection.Open();
                string query = "UPDATE HastaGiris SET Sifre = ?, HastaAdi = ?, HastaSoyadi = ? WHERE Kullaniciadi = ?";
                OleDbCommand cmd = new OleDbCommand(query, connection);
                cmd.Parameters.AddWithValue("?", hastaGiris.HastaSifre);
                cmd.Parameters.AddWithValue("?", hastaGiris.HastaAdi);
                cmd.Parameters.AddWithValue("?", hastaGiris.HastaSoyadi);
                cmd.Parameters.AddWithValue("?", hastaGiris.Kullaniciadi);

                return cmd.ExecuteNonQuery(); // Etkilenen satır sayısını döndürür
            }
        }
/*
        public int UpdateItem(Hasta hasta)
        {
            OleDbCommand cmd = Accessconnection.GetOleDbCommand();
            cmd.CommandText = string.Format("UPDATE Hasta SET HastaAdi='{0}', HastaSoyadi='{1}', DogumTarihi='{2}', HastaTelefon='{3}', Cinsiyet='{4}' WHERE HastaTC='{5}'", hasta.HastaAdi, hasta.HastaSoyadi, hasta.DogumTarihi.ToString("yyyy-MM-dd"), hasta.HastaTelefon, hasta.Cinsiyet, hasta.HastaTC);
            return cmd.ExecuteNonQuery();
        }*/
    }
}
        


