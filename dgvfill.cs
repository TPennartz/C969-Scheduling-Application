using C969Tpennartz.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969Tpennartz
{
    class dgvfill : DbConnection
    {
        private BindingList<Appointments> AllAppointments = new BindingList<Appointments>();
        private BindingList<Customers> AllCustomers = new BindingList<Customers>();
        private Appointments Appointment = new Appointments();
        private Customers Customers = new Customers();

        //public DataTable FillCustomers()
        //{
        //    var Customerdgv = new DataTable();
        //    AllCustomers = Customers.GetCustomers();
        //    Customerdgv.Columns.Add("Customer ID");
        //    Customerdgv.Columns.Add("Name");
        //    Customerdgv.Columns.Add("Status");
        //    Customerdgv.Columns.Add("Phone");
        //    Customerdgv.Columns.Add("Address");
        //    Customerdgv.Columns.Add("Address 2");
        //    Customerdgv.Columns.Add("City");
        //    Customerdgv.Columns.Add("Zip");
        //    Customerdgv.Columns.Add("Country");
        //    foreach (var entry in AllCustomers)
        //    {
        //        string customerStatus = entry.active == "False" ? "Inactive" : "Active";

        //            Customerdgv.Rows.Add(entry.customerId, entry.customerName, customerStatus, entry.address.phone, entry.address.address, entry.address.address2, entry.address.city.city, entry.address.postalCode, entry.address.city.country.country);

                
                
        //    }
           // return Customerdgv;

       // }

        public DataView FillAppointments(string filter)
        {
            return FillAppointments(filter, Appointment);
        }

        public DataView FillAppointments(string filter, Appointments appointments)
        {
            var dgvcustapp = new DataTable();

            AllAppointments = appointments.GetAppointments();

            dgvcustapp.Columns.Add("Appointment ID");

            dgvcustapp.Columns.Add("Customer");

            dgvcustapp.Columns.Add("Date");

            dgvcustapp.Columns.Add("Start");

            dgvcustapp.Columns.Add("End");

            dgvcustapp.Columns.Add("Title");

            dgvcustapp.Columns.Add("Type");

            foreach (var entry in AllAppointments)

            {

                var sqlString = $"SELECT customerName FROM customer WHERE customerId = {entry.CustomerId}";

                Cmd = new MySqlCommand(sqlString, Connection);

                Reader = Cmd.ExecuteReader();

                if (Reader.HasRows)

                {

                    Reader.Read();

                    var customerName = Reader.GetString(0);

                    dgvcustapp.Rows.Add(entry.AppointmentId, customerName, entry.Start.ToString("MM/dd/yyyy"), entry.Start.ToString("HH:mm"), entry.End.ToString("HH:mm"), entry.Title, entry.Type);

                }

                Reader.Close();

            }

            var dvAppointments = new DataView(dgvcustapp);

            dvAppointments.RowFilter = filter;

            return dvAppointments;

        }

    }

}
