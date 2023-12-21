using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969Tpennartz.Database
{

    public class Country : DbConnection

    {

        public int countryId;

        public string country;

        public int GetId(string country)

        {

            using (MySqlConnection connection = new MySqlConnection(DBConnection.Connection))

            {

                connection.Open();



                var userName = new User().GetUserName(C969Tpennartz.LoginForm.mainScreen.UserId);



                string selectQuery = "SELECT countryId FROM country WHERE country = @Country";

                MySqlCommand selectCmd = new MySqlCommand(selectQuery, connection);

                selectCmd.Parameters.AddWithValue("@Country", country);



                object result = selectCmd.ExecuteScalar();



                if (result != null) // Country exists 

                {

                    return Convert.ToInt32(result);

                }

                else // Create new country 

                {

                    string insertQuery = @" 

                INSERT INTO country(country, createDate, createdBy, lastUpdate, lastUpdateBy) 

                VALUES(@Country, NOW(), @UserName, NOW(), @UserName); 

                SELECT LAST_INSERT_ID();";



                    MySqlCommand insertCmd = new MySqlCommand(insertQuery, connection);

                    insertCmd.Parameters.AddWithValue("@Country", country);

                    insertCmd.Parameters.AddWithValue("@UserName", userName);



                    int countryId = Convert.ToInt32(insertCmd.ExecuteScalar());

                    return countryId;

                }

            }

        }
    }
}




 