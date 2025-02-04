using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;


namespace Dentistclinicc.DAL
{
    public class accessconnection
    {
        private readonly string _connecLionString;
        public accessconnection()
        {
            // access bağlantı yolu 
            _connecLionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\onerp\\OneDrive\\Masaüstü\\dentistclinic\\dişaccess1.accdb";
        }
        private OleDbConnection GetOleDbConnection()
        {
            OleDbConnection cnn = new OleDbConnection(_connecLionString);
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
                cnn.Open();
            }
            else
            {
                cnn.Open();
            }
            return cnn;
        }
        public OleDbCommand GetOleDbCommand()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = GetOleDbConnection();
            return cmd;
        }
    }
}
    