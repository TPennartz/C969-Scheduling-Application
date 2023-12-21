using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969Tpennartz.Database
{
    public class City : DbConnection
    {

        public int cityId;

        public string city;

        public int countryId;

        public Country country;



        public int GetId(string city, int countryId)
        {
            using (MySqlConnection connection = new MySqlConnection(DBConnection.Connection))
            {
                connection.Open();
                var userName = new User().GetUserName(C969Tpennartz.LoginForm.mainScreen.UserId);
                string selectQuery = "SELECT cityId FROM city WHERE city = @City AND countryId = @CountryId";
                MySqlCommand selectCmd = new MySqlCommand(selectQuery, connection);
                selectCmd.Parameters.AddWithValue("@City", city);
                selectCmd.Parameters.AddWithValue("@CountryId", countryId);
                object result = selectCmd.ExecuteScalar();
                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
                else
                {
                    string insertQuery = @" INSERT INTO city(city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES(@City, @CountryId, NOW(), @UserName, NOW(), @UserName); SELECT LAST_INSERT_ID();";
                    MySqlCommand insertCmd = new MySqlCommand(insertQuery, connection);
                    insertCmd.Parameters.AddWithValue("@City", city);
                    insertCmd.Parameters.AddWithValue("@CountryId", countryId);
                    insertCmd.Parameters.AddWithValue("@UserName", userName);
                    int cityId = Convert.ToInt32(insertCmd.ExecuteScalar());
                    return cityId;
                }
            }
        }
    }
}

 