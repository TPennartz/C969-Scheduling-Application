using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969Tpennartz.Database
{

    public class User : DbConnection

    {

        public int userId;

        public string userName;

        public string GetUserName(int userId)

        {

            var sqlString = $"SELECT userName FROM user WHERE userId = {userId}";

            Cmd = new MySqlCommand(sqlString, Connection);
            Reader = Cmd.ExecuteReader();
            //if (Reader != null)
            //{
                //Reader.Close();
            //}
           

           

            if (Reader.HasRows)

            {

                Reader.Read();

                userName = Reader.GetFieldValue<string>(0);

                Reader.Close();

            }

            else

            {


                Reader.Close();

            }

            return userName;

        }

    }

}
