using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969Tpennartz.Database
{

    public class Address : DbConnection

    {

        public int addressId;

        public string address;

        public string address2;

        public int cityId;

        public string postalCode;

        public string phone;

        public City city;



        public int GetId(string address, string address2, int cityId, string postalCode, string phone)

        {

            using (MySqlConnection connection = new MySqlConnection(DBConnection.Connection))

            {

                connection.Open();



                var userName = new User().GetUserName(C969Tpennartz.LoginForm.mainScreen.UserId);



                string selectQuery = @" 

            SELECT addressId  

            FROM address  

            WHERE address = @Address  

            AND address2 = @Address2  

            AND cityId = @CityId  

            AND postalCode = @PostalCode  

            AND phone = @Phone";



                MySqlCommand selectCmd = new MySqlCommand(selectQuery, connection);

                selectCmd.Parameters.AddWithValue("@Address", address);

                selectCmd.Parameters.AddWithValue("@Address2", address2);

                selectCmd.Parameters.AddWithValue("@CityId", cityId);

                selectCmd.Parameters.AddWithValue("@PostalCode", postalCode);

                selectCmd.Parameters.AddWithValue("@Phone", phone);



                object result = selectCmd.ExecuteScalar();



                if (result != null) // Address exists 

                {

                    return Convert.ToInt32(result);

                }

                else // Create new address 

                {

                    string insertQuery = @" 

                INSERT INTO address(address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy)  

                VALUES(@Address, @Address2, @CityId, @PostalCode, @Phone, NOW(), @UserName, NOW(), @UserName); 

                SELECT LAST_INSERT_ID();";



                    MySqlCommand insertCmd = new MySqlCommand(insertQuery, connection);

                    insertCmd.Parameters.AddWithValue("@Address", address);

                    insertCmd.Parameters.AddWithValue("@Address2", address2);

                    insertCmd.Parameters.AddWithValue("@CityId", cityId);

                    insertCmd.Parameters.AddWithValue("@PostalCode", postalCode);

                    insertCmd.Parameters.AddWithValue("@Phone", phone);

                    insertCmd.Parameters.AddWithValue("@UserName", userName);



                    int addressId = Convert.ToInt32(insertCmd.ExecuteScalar());

                    return addressId;

                }

            }

        }
    }
}