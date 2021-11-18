using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace zadanie_kuzob
{
    public class DB
    {
        MySqlConnection conn = new MySqlConnection("server=192.168.4.211; user=student; database=kozhevnikov; password=12345");

        public void openConnection()
        {
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();
        }

        public void closeConnection()
        {
            if (conn.State == System.Data.ConnectionState.Open)
                conn.Close();
        }

        public MySqlConnection getConnection()
        {
            return conn;
        }
    }
}
