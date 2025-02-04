using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace Dentistclinicc.DAL
{
    public class DoktorRandevuDurumDAL
    {
        private static string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\onerp\OneDrive\Masaüstü\dentistclinic\dişaccess1.accdb";

        public DataTable GetDoktorlar()
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = "SELECT DISTINCT DoktorAdi FROM Randevu";
                OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                DataTable doktorlar = new DataTable();
                adapter.Fill(doktorlar);
                return doktorlar;
            }
        }

        public DataTable GetRandevuSayisiByDoktor(string doktorAdi)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = @"SELECT 
                    RandevuTarihi, 
                    COUNT(*) AS RandevuSayisi 
                FROM Randevu
                WHERE DoktorAdi = @DoktorAdi
                GROUP BY RandevuTarihi
                ORDER BY RandevuTarihi";

                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("@DoktorAdi", doktorAdi);
                OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                DataTable randevuSayisi = new DataTable();
                adapter.Fill(randevuSayisi);
                return randevuSayisi;
            }
        }
    }
}

    
