using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace Migration
{
    public class ConnectDB
    {
        SqlConnection conn = new SqlConnection();
        public string dataBase = "StoreConnect"; 

        public ConnectDB()
        {
            conn.ConnectionString = "Data Source=localhost;Initial Catalog=" + dataBase + ";" +
                "Persist Security Info=False;Integrated Security=SSPI;Connection Timeout=0;Connect Timeout=0";
        }

        public SqlConnection Conectar()
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }

        public SqlConnection Desconectar()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
            return conn;
        }
    }
}
