using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969Tpennartz.Database
{
    class Login_user : DbConnection
    {
        
        
        public int VerifyLogin(string userName, string password)
        {
            
            Cmd = new MySqlCommand("SELECT userId FROM user WHERE userName = '" + userName + "' AND password = '" + password + "'", Connection);
            Reader = Cmd.ExecuteReader();
            try
            {
                Reader.Read();
                if (Reader.HasRows) 
                {
                    var users = Reader.GetValue(0) ?? -1;
                    using (StreamWriter logFile = new StreamWriter("C969log.txt", true))
                    {

                        logFile.WriteLine($"Successful Authentication for user {Convert.ToInt32(Reader.GetValue(0))}({userName} at {DateTime.Now:s}");
                    }
                    var userId = Convert.ToInt32(Reader.GetValue(0));
                    Reader.Close();
                    return userId;
                
                }
                else 
                { 
                    Reader.Close();
                    using (StreamWriter logFile = new StreamWriter("C969log.txt", true))
                     {
                        logFile.WriteLine($"Failed to authenticate for \"{userName}\" at {DateTime.Now:s}");
                     }
                     return 0;
                    
                  
                }
            }
            catch (Exception ex)
            {
                Reader.Close();
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
            
    }
}
