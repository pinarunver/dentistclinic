using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentistclinicc.DAL
{
  public  class HastaRandevuTabloDAL
    {
        private static string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\onerp\OneDrive\Masaüstü\dentistclinic\dişaccess1.accdb";

        public DataTable GetRandevuData()
        {
            DataTable dataTable = new DataTable();
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = "SELECT * FROM Randevu";
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection))
                {
                    try
                    {
                        connection.Open();
                        adapter.Fill(dataTable);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Veritabanı bağlantısı sırasında bir hata oluştu: " + ex.Message);
                    }
                }
            }
            return dataTable;
        }
    }
}
