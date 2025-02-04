using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dentistclinic.Entity;



namespace Dentistclinicc.DAL
{
    public class HastaDAL
    {
        private string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\onerp\\OneDrive\\Masaüstü\\dentistclinic\\dişaccess1.accdb";

        public bool HastaEkle(Hasta hasta)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                // TC kontrolü
                string kontrolQuery = "SELECT COUNT(*) FROM Hasta WHERE HastaTC = @HastaTC";
                OleDbCommand kontrolCmd = new OleDbCommand(kontrolQuery, connection);
                kontrolCmd.Parameters.AddWithValue("@HastaTC", hasta.HastaTC);

                int count = (int)kontrolCmd.ExecuteScalar();
                if (count > 0)
                {
                    return false; // Aynı TC mevcut
                }

                // Yeni hasta ekleme
                string query = "INSERT INTO Hasta (HastaAdi, HastaSoyadi, DogumTarihi, HastaTelefon, HastaCinsiyet, HastaTC, HastaSifre, Mail) " +
                               "VALUES (@HastaAdi, @HastaSoyadi, @DogumTarihi, @HastaTelefon, @HastaCinsiyet, @HastaTC, @HastaSifre, @Mail)";
                OleDbCommand cmd = new OleDbCommand(query, connection);
                cmd.Parameters.AddWithValue("@HastaAdi", hasta.HastaAdi);
                cmd.Parameters.AddWithValue("@HastaSoyadi", hasta.HastaSoyadi);
                cmd.Parameters.AddWithValue("@DogumTarihi", hasta.DogumTarihi.ToString("dd.MM.yyyy"));
                cmd.Parameters.AddWithValue("@HastaTelefon", hasta.HastaTelefon);
                cmd.Parameters.AddWithValue("@HastaCinsiyet", hasta.HastaCinsiyet);
                cmd.Parameters.AddWithValue("@HastaTC", hasta.HastaTC);
                cmd.Parameters.AddWithValue("@HastaSifre", hasta.HastaSifre);
                cmd.Parameters.AddWithValue("@Mail", hasta.Mail);

                cmd.ExecuteNonQuery();
                return true;
            }
        }
    }
}




