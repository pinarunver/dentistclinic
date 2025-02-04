using Dentistclinic.Entity;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentistclinicc.DAL
{
    public class HastaAnaSayfaDAL
    {
        private readonly string connectionString = @" Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\onerp\OneDrive\Masaüstü\dentistclinic\dişaccess1.accdb;";
       
        public bool UpdateHastaBilgileri(string tc, string mail, string telefon, string sifre)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    string query = "UPDATE Hasta SET Mail = @mail, HastaTelefon =@HastaTelefon, HastaSifre = @HastaSifre WHERE HastaTC = @HastaTC";
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Mail", mail);
                        command.Parameters.AddWithValue("@HastaTelefon", telefon);
                        command.Parameters.AddWithValue("@HastaSifre", sifre);
                        command.Parameters.AddWithValue("@HastaTC", tc);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
        public Hasta GetHastaBilgileriByTC(string tc)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    string query = "SELECT HastaAdi, HastaSoyadi, HastaTelofon, HastaSifre, Mail, HastaCinsiyet, DogumTarihi FROM Hasta WHERE HastaTC = ?";

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("?", tc);

                        connection.Open();

                        OleDbDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            // Veritabanından alınan bilgileri Hasta nesnesine yükleyelim
                            Hasta hasta = new Hasta()
                            {
                                HastaAdi = reader["HastaAdi"].ToString(),
                                HastaSoyadi = reader["HastaSoyadi"].ToString(),
                                HastaTelefon= reader["HastaTelefon"].ToString(),
                                HastaSifre = reader["HastaSifre"].ToString(),
                                Mail = reader["Mail"].ToString(),
                                HastaCinsiyet = reader["HastaCinsiyet"].ToString(),
                                DogumTarihi = Convert.ToDateTime(reader["DogumTarihi"])
                            };
                            return hasta;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
               
                return null;
            }
        }
        public bool SilHasta(string tc)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    string query = "DELETE FROM Hasta WHERE HastaTC = ?";

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("?", tc);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        // Eğer işlem başarılıysa, etkilenen satır sayısı 0'dan büyük olacaktır
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda
                
                return false;
            }
        }
    }

}

