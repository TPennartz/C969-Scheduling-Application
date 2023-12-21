using MySql.Data.MySqlClient;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969Tpennartz.Database
{
    public class Customers : DbConnection
    {
        public int customerId;
        public string customerName;
        public int addressId;
        public string active;
        public string address;
        public string address2;
        public string city;
        public string country;
        public string postalCode;
        public string phone;
        
        public DBqueries customerConnection = new DBqueries();
        public BindingList<Customers> bindlistCustomers;
        public User currentUser = new User();
        string userName;
        public void Create(string customerName, bool active, string address, string address2, string postalCode,string phone, string city, string country)
        {
            userName = currentUser.GetUserName(C969Tpennartz.LoginForm.mainScreen.UserId);
            var newCustCountry = new Country();
            var newCustCity = new City();
            var newCustAddress = new Address();
            var countryId = newCustCountry.GetId(country);
            var cityId = newCustCity.GetId(city, countryId);
            var addressId = newCustAddress.GetId(address,address2,cityId,postalCode,phone);
            try
            {
                string sqlString = @" INSERT INTO customer (customerName, active, addressId, createDate, createdBy, lastUpdate, lastUpdateby) VALUES (@customerName, @active, @addressId, NOW(), @userName, NOW(), @userName)";
                _ = customerConnection.Query(sqlString);
            }
            catch(Exception e)
            {
                MessageBox.Show($"Fill required fields.\n{e}");
            }
        }

        public void Update(int customerId, string customerName, bool active, string address, string address2, string postalCode, string phone, string city, string country)
        {
            userName = currentUser.GetUserName(C969Tpennartz.LoginForm.mainScreen.UserId);
            var updateCountry = new Country();
            var updateCity = new City();
            var updateAddress = new Address();
            var newCountryId = updateCountry.GetId(country);
            var newCityId = updateCity.GetId(city, newCountryId);
            var newAddressId = updateAddress.GetId(address, address2, newCityId, postalCode, phone);
            try

            {

                var sqlString =

                    $"INSERT INTO customer(customerName,addressId,active,createDate,createdBy,lastUpdate,lastUpdateBy) " +

                    $"VALUES('" + MySqlHelper.EscapeString(customerName) + $"',{address},{address2}, {active},now(),'{userName}',now(),'{userName}')";

                _ = customerConnection.Query(sqlString);

            }

            catch (Exception e)

            {

                MessageBox.Show($"Please check that all required fields have been filled. \n{e}");

            }

        }

        public void Delete(int customerId)

        {

            string sqlString =

                $"DELETE FROM appointment WHERE customerId={customerId};" +

                $"DELETE FROM customer WHERE customerId={customerId};"; //alternatively, cascade 

            var warning = MessageBox.Show($"Are you sure you want to delete customer {customerId}? All of this customer 's appointments will also be deleted.", $"Delete {customerId}?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            switch (warning)

            {

                case DialogResult.Yes:

                    _ = customerConnection.Query(sqlString);

                    MessageBox.Show($"Successfully deleted customer {customerId}");

                    break;

                default:

                    MessageBox.Show($"No customers were deleted");

                    break;

            }

        }

        public BindingList<Customers> GetCustomers()

        {

            bindlistCustomers = new BindingList<Customers>();

            string sqlString =

                "SELECT a.customerId, a.customerName, a.active, b.addressId, b.address, b.address2, c.cityId, b.postalCode, b.phone, c.city, d.countryId, d.country " +

                "FROM (customer a LEFT JOIN address b ON a.addressId = b.addressId LEFT JOIN city c ON b.cityId = c.cityId LEFT JOIN country d ON c.countryId = d.countryId)";

            var dataIn = customerConnection.Query(sqlString);

            foreach (var collumnIn in dataIn)

            {

                var customer = new Customers();

                var Address = new Address();

                var city = new City();

                var country = new Country();



                customer.customerId = int.Parse(collumnIn[0]);

                customer.customerName = collumnIn[1];

                customer.active = collumnIn[2];

                customer.addressId = Address.addressId = int.Parse(collumnIn[3]);

                Address.address = collumnIn[4];

                Address.address2 = collumnIn[5];

                Address.cityId = city.cityId = int.Parse(collumnIn[6]);

                Address.postalCode = collumnIn[7];

                Address.phone = collumnIn[8];

                city.city = collumnIn[9];

                city.countryId = country.countryId = int.Parse(collumnIn[10]);

                country.country = collumnIn[11];



                city.country = country;

                Address.city = city;

                customer.addressId = addressId;



                bindlistCustomers.Add(customer);

            }

            return bindlistCustomers;

        }


    }

}