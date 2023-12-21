using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969Tpennartz.Database
{
    class DBConnection
    {
        private static string _connection = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
        public static string Connection
        {
            get => _connection; set => _connection = value;
        }
        public static MySqlCommand Cmd { get; set; }
        public MySqlDataReader Reader { get; set; }
        public static MySqlDataAdapter adapter { get; set; }


    }
       public class DbConnection
      {
            public static MySqlConnection Connection { get; set; }
            public static MySqlCommand Cmd { get; set; }
            public MySqlDataReader Reader { get; set; }
            public static MySqlDataAdapter adapter { get; set; }
            public static void StartConnection()
            {
                try
                {
                    string constr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
                    Connection = new MySqlConnection(constr);
                   //Open connection
                    Connection.Open();

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            public static void closeConnection()
            {
               try
                {

                   if (Connection != null)
                    {
                        Connection.Close();
                   }
                    Connection = null;
                }
                catch (MySqlException ex)
                    {
                    MessageBox.Show(ex.Message);
                   }
            }
        }
    }






