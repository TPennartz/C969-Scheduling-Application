using C969Tpennartz.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;
using MySql.Data.MySqlClient;
using System.Diagnostics.Metrics;
using System.Collections;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Linq.Expressions;

namespace C969Tpennartz
{

    public partial class MainPage : Form
    {
        DataTable at = new DataTable();
        DateTime currentDate;
        public User currentUser = new User();
        string UserName;

        public int UserId { get; set; }
        private dgvfill _dgvfill = new dgvfill();
        private Customers Customers = new Customers();
        private Appointments Appointments = new Appointments();
        private EditingState currentState;



        private struct EditingState
        {
            public EditingState(int id, bool editing) => (Id, Editing) = (id, editing);
            public int Id { get; }
            public bool Editing { get; }
        }
        public MainPage(int userId)
        {
            GetCustomers();
            UserId = userId;
            MainPage_Update();
            InitializeComponent();
        }


        private void MainPage_Update()
        {
            Appointments = new Appointments() { userId = UserId };
            _ = Appointments.CheckNext15();
            //dtpAppointStart.MinDate = new DateTime
            //    (
            //    DateTime.Now.Year,
            //    DateTime.Now.Month,
            //    DateTime.Now.Day,
            //    DateTime.Now.Hour,
            //    DateTime.Now.Minute,
            //    0,
            //    0
            //    );
        }
        // The Lambda expression here is used to select a filter based of which criteria is met
        private void UpdateDataTables()
        {
            var selectedDate = monthCalandar1.SelectionStart;
            RadioButton selectedFilter = new RadioButton();
            selectedFilter = new[] { weekly_radio, Monthly_Radio }.FirstOrDefault(rb => rb.Checked);
            Func<RadioButton, string> filterSelector = rb =>
            {
                if (rb == weekly_radio)
                    return $"Date >= '{selectedDate:MM/dd/yyyy}' AND Date <= '{selectedDate.AddDays(7):MM/dd/yyyy}'";
                else if (rb == Monthly_Radio)
                    return $"Date >= '{selectedDate:MM/dd/yyyy}' AND Date <= '{selectedDate:MM}/{DateTime.DaysInMonth(selectedDate.Year, selectedDate.Month)}/{selectedDate.Year}'";
                else
                    return $"";
            };
            GetCustomers();
            dgvCalendar.DataSource = _dgvfill.FillAppointments(filterSelector(selectedFilter));

        }


        private void Exit_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Delete_appointment_button_Click(object sender, EventArgs e)
        {
            Appointments = new Appointments();
            var appointmentId = Convert.ToInt32(dgvCalendar.CurrentRow.Cells[0].Value);
            Appointments.Delete(appointmentId);
            UpdateDataTables();

        }

        private void Modify_appointment_button_Click(object sender, EventArgs e)
        {

            var id = Convert.ToInt32(dgvCalendar.CurrentRow.Cells[0].Value);
            Appointments = new Appointments();

            Appointments = Appointments.GetAppointments(id);

            tbApptTitle.Text = Appointments.Title;

            tbApptDescription.Text = Appointments.Description;

            tbApptLocation.Text = Appointments.Location;

            tbApptContact.Text = Appointments.Contact;

            tbApptType.Text = Appointments.Type;

            dtpAppointStart.Value = Appointments.Start;

            dtpAppointEnd.Value = Appointments.End;



            UpdateDataTables();

            foreach (DataGridViewRow row in dgvCalendar.Rows)

            {

                if (Convert.ToInt32(row.Cells[0].Value) == Appointments.CustomerId)

                {

                    dgvCalendar.Rows[row.Index].Selected = true;


                }

            }

            currentState = new EditingState(id, true);



        }

        private void tabControlMainScreen_Selecting(object sender, TabControlCancelEventArgs e)

        {

            if (currentState.Editing)

            {

                var Confirm = MessageBox.Show($"You have unsaved changes. Continue without saving?", "Continue without saving?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (Confirm == DialogResult.OK)

                {

                    ClearFields();

                    currentState = new EditingState(-1, false);

                }

                else if (Confirm == DialogResult.Cancel)

                {

                    e.Cancel = true;

                }

            }

        }


        // I used Lambda expression here to call the method UpdateDataTables so I didnt have to repeat it 3 seperate times
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e) => UpdateDataTables();



        private void Weekly_Radio_CheckedChanged(object sender, EventArgs e) => UpdateDataTables();

        private void Monthly_Radio_CheckedChanged(object sender, EventArgs e) => UpdateDataTables();



        private void btnCancel_Click(object sender, EventArgs e)

        {

            DialogResult clear = currentState.Editing ? MessageBox.Show($"Stop editing? All fields will be reset.", "Stop editing?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) : MessageBox.Show($"Clear all fields?", "Stop editing?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (clear == DialogResult.Yes)

            {

                ClearFields();

                currentState = new EditingState(-1, false);


            }

        }

        private void btnGenReports_Click(object sender, EventArgs e)

        {


        }

        private void ClearFields()

        {

            tbCustName.Text = "";

            tbCustAddress.Text = "";

            tbCustAddress2.Text = "";

            tbCustZip.Text = "";

            tbCustPhone.Text = "";

            tbCustCity.Text = "";

            cbCountry.Text = "";

            tbApptTitle.Text = "";

            tbApptDescription.Text = "";

            tbApptLocation.Text = "";

            tbApptContact.Text = "";

            tbApptType.Text = "";



        }



        protected void SubmitCustomer()

        {

            try

            {

                var customer = new ValidateCustomer()

                {

                    CustomerName = tbCustName.Text,

                    PhoneNumber = tbCustPhone.Text,

                    CustAddress = tbCustAddress.Text,

                    CustAddress2 = tbCustAddress2.Text,

                    CustCity = tbCustCity.Text,

                    CustCountry = cbCountry.Text,

                    CustZip = tbCustZip.Text

                };

                Dictionary<string, string> fieldNames = new Dictionary<string, string>()

                {

                    { "CustomerName", "Name" },

                    { "PhoneNumber", "Phone" },

                    { "CustAddress", "Address"},

                    { "CustAddress2", "Address Line 2" },

                    { "CustCity", "City" },

                    { "CustCountry", "Country" },

                    { "CustZip", "Postal Code" }

                };

                var context = new ValidationContext(customer);

                var results = new List<ValidationResult>();

                var isValid = Validator.TryValidateObject(customer, context, results, true);

                var errorString = "Please correct the following:\n";



                if (isValid)

                {

                    if (currentState.Editing)

                    {

                        if (MessageBox.Show($"Are you sure you want to edit Customer ID {currentState.Id}?", "Confirm changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                        {

                            Customers.Update(currentState.Id, tbCustName.Text, true, tbCustAddress.Text, tbCustAddress2.Text, tbCustZip.Text, tbCustPhone.Text, tbCustCity.Text, cbCountry.Text);

                            UpdateDataTables();

                            currentState = new EditingState(-1, false);

                            ClearFields();


                        }

                    }

                    else

                    {



                        Customers.Create(tbCustName.Text, true, tbCustAddress.Text, tbCustAddress2.Text, tbCustZip.Text, tbCustPhone.Text, tbCustCity.Text, cbCountry.Text);

                        UpdateDataTables();

                        ClearFields();



                    }

                }

                else

                {

                    results.ForEach(r =>

                    {

                        errorString += r.ErrorMessage + "\n";

                    });

                    foreach (var name in fieldNames)

                    {

                        errorString = errorString.Replace(name.Key, name.Value);

                    }

                    MessageBox.Show(errorString, "There was an error in your submission", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }

            catch (Exception i)

            {

                MessageBox.Show($"{i}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }



        protected void SubmitAppt()

        {

            var appointment = new ApptValidate()

            {

                ApptTitle = tbApptTitle.Text,

                ApptDescription = tbApptDescription.Text,

                ApptType = tbApptType.Text,

                ApptContact = tbApptContact.Text,

                ApptLocation = tbApptLocation.Text

            };

            Dictionary<string, string> fieldNames = new Dictionary<string, string>()

            {


                { "ApptTitle", "Title" },

                { "ApptDescription", "Description" },

                { "ApptType", "Type" },

                { "ApptContact", "Contact" },

                { "ApptLocation", "Location" },

                { "ApptStart", "Start" },

                { "ApptEnd", "End" }

            };

            var context = new ValidationContext(Appointments);

            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(Appointments, context, results, true);

            var errorString = "Please correct the following:\n";


            if (isValid)

            {

                Appointments = new Appointments();

                dtpAppointStart.Value = DateTime.SpecifyKind(dtpAppointStart.Value, DateTimeKind.Local);

                dtpAppointEnd.Value = DateTime.SpecifyKind(dtpAppointEnd.Value, DateTimeKind.Local);

                Appointments.Title = tbApptTitle.Text;

                Appointments.Description = tbApptDescription.Text;

                Appointments.Location = tbApptLocation.Text;

                Appointments.Contact = tbApptContact.Text;

                Appointments.Type = tbApptType.Text;

                Appointments.Url = ApptUrl.Text;

                Appointments.Start = dtpAppointStart.Value.ToUniversalTime();

                Appointments.End = dtpAppointEnd.Value.ToUniversalTime();

                Appointments.userId = LoginForm.mainScreen.UserId;

                Appointments.CustomerId = Convert.ToInt32(Customerdgv.CurrentRow.Cells[0].Value);
                if (Appointments.CustomerId == 0)
                {
                    MessageBox.Show("Please select a customer.");
                    return;

                }
                else
                {
                    UpdateDataTables();
                }



                bool hasConflict = Appointments.ConflictCheck(Appointments.AppointmentId, Appointments.userId, Appointments.Start, Appointments.End);
                if (!hasConflict)
                {


                    UpdateDataTables();
                }
                else
                {
                    MessageBox.Show("Please validate your input.");
                    return;
                }


                if (!currentState.Editing)

                {

                    var success = Appointments.Create(Appointments);

                    if (success)

                    {

                        ClearFields();

                    }

                }

                else

                {
                    // MessageBox.Show("You have a time conflict with another appointment.");
                    //return;

                    var success = Appointments.Update(currentState.Id, Appointments);

                    if (success)

                    {

                        ClearFields();

                        currentState = new EditingState(-1, false);


                    }

                    currentState = new EditingState(-1, false);

                }

                UpdateDataTables();
            }


            else

            {

                results.ForEach(r =>

                {

                    errorString += r.ErrorMessage + "\n";

                });

                foreach (var name in fieldNames)

                {

                    errorString = errorString.Replace(name.Key, name.Value);

                }

                MessageBox.Show(errorString, "There was an error in your submission", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }



        }



        private void dtpApptStart_DateChanged(object sender, EventArgs e)

        {

            monthCalandar1.MinDate = dtpAppointStart.Value;
        }

        private void Add_appointment_button_Click(object sender, EventArgs e)
        {
            SubmitAppt();
            UpdateDataTables();
        }

        private void Add_customer_button_Click(object sender, EventArgs e)
        {

            string customerName = tbCustName.Text;

            bool active = true;

            string address = tbCustAddress.Text;

            string address2 = tbCustAddress2.Text;

            string postalCode = tbCustZip.Text;

            string phone = tbCustPhone.Text;

            string city = tbCustCity.Text;

            string country = cbCountry.Text;

            string userName = LoginForm.UserSession.UserName;



            var newCustCountry = new Country();

            var newCustCity = new City();

            var newCustAddress = new Address();



            var countryId = newCustCountry.GetId(country);

            var cityId = newCustCity.GetId(city, countryId);

            var addressId = newCustAddress.GetId(address, address2, cityId, postalCode, phone);



            try

            {
                if (tbCustName.Text == "")
                {
                    if (tbCustName.Text == "")
                    {
                        MessageBox.Show("Please at least fill in a Customer Name.");
                        return;
                    }
                }
                else
                {

                    using (MySqlConnection connection = new MySqlConnection(DBConnection.Connection))

                    {

                        connection.Open();



                        string sqlString = @" 

                INSERT INTO customer (customerName, active, addressId, createDate, createdBy, lastUpdate, lastUpdateby) 

                VALUES (@customerName, @active, @addressId, NOW(), @userName, NOW(), @userName)";



                        MySqlCommand command = new MySqlCommand(sqlString, connection);

                        command.Parameters.AddWithValue("@customerName", customerName);

                        command.Parameters.AddWithValue("@active", active);

                        command.Parameters.AddWithValue("@addressId", addressId);

                        command.Parameters.AddWithValue("@userName", userName);



                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)

                        {

                            MessageBox.Show("Customer added successfully.");
                            GetCustomers();

                        }

                        else

                        {

                            MessageBox.Show("Failed to add customer.");

                        }

                    }

                }
            }

            catch (Exception ex)

            {

                MessageBox.Show($"Error adding customer: {ex.Message}");

            }
            finally
            {
                UpdateDataTables();
                GetCustomers();
                ClearFields();
            }

        }
    




        public void GetCustomers()
        {
            MySqlConnection connection = new MySqlConnection(DBConnection.Connection);

            connection.Open();
            string query = $"SELECT a.customerId, a.customerName, a.active, b.addressId, b.address, b.address2, c.cityId, b.postalCode, b.phone, c.city, d.countryId, d.country  FROM(customer a LEFT JOIN address b ON a.addressId = b.addressId LEFT JOIN city c ON b.cityId = c.cityId LEFT JOIN country d ON c.countryId = d.countryId)";
            MySqlCommand Cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter adapt = new MySqlDataAdapter(selectCommand: Cmd);

            DataTable dt = new DataTable();
            adapt.Fill(dt);
            if (Customerdgv != null)
            {
                Customerdgv.DataSource = dt;
            }
            //connection.Close();

        }

        private void Modify_customer_button_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(Customerdgv.CurrentRow.Cells[0].Value);
            Customers = new Customers();



            tbCustName.Text = Customerdgv.CurrentRow.Cells[1].Value.ToString();

            tbCustAddress.Text = Customerdgv.CurrentRow.Cells[4].Value.ToString();

            tbCustAddress2.Text = Customerdgv.CurrentRow.Cells[5].Value.ToString();

            tbCustCity.Text = Customerdgv.CurrentRow.Cells[9].Value.ToString();

            tbCustZip.Text = Customerdgv.CurrentRow.Cells[7].Value.ToString();

            cbCountry.Text = Customerdgv.CurrentRow.Cells[11].Value.ToString();

            tbCustPhone.Text = Customerdgv.CurrentRow.Cells[8].Value.ToString();


        }

        private void ClearFields(object sender, EventArgs e)
        {

            tbCustName.Text = "";

            tbCustAddress.Text = "";

            tbCustAddress2.Text = "";

            tbCustZip.Text = "";

            tbCustPhone.Text = "";

            tbCustCity.Text = "";

            cbCountry.Text = "";

            tbApptTitle.Text = "";

            tbApptDescription.Text = "";

            tbApptLocation.Text = "";

            tbApptContact.Text = "";

            tbApptType.Text = "";

            ApptUrl.Text = "";

        }

        private void Appt_Save(object sender, EventArgs e)
        {
            SubmitAppt();
            UpdateDataTables();
            GetCustomers();
        }

        private void Delete_customer_button_Click(object sender, EventArgs e)
        {
            {
                Customers = new Customers();
                var customerId = Convert.ToInt32(Customerdgv.CurrentRow.Cells[0].Value);
                Customers.Delete(customerId);
                GetCustomers();

            }
        }

        private void AllReports_Click(object sender, EventArgs e)
        {
            var Report = new Report();
            Report.GenerateReport();
            MessageBox.Show("Reports are saved to: " + Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\reports\");


        }

        private void Save_cust_Click(object sender, EventArgs e)
        {

            {
                string customerName = tbCustName.Text;
                string address = tbCustAddress.Text;
                string address2 = tbCustAddress2.Text;
                string postalCode = tbCustZip.Text;
                string phone = tbCustPhone.Text;
                string city = tbCustCity.Text;
                string country = cbCountry.Text;
                

                string updateQuery = @" UPDATE customer a LEFT JOIN address b ON a.addressId = b.addressId LEFT JOIN city c ON b.cityId = c.cityId LEFT JOIN country d ON c.countryId = d.countryId SET a.customerName = @customerName, b.address = @address, b.address2 = @address2, b.postalCode = @postalCode, b.phone = @phone, c.city = @city, d.country = @country WHERE a.customerName = @customerName ";
                
                using (MySqlConnection connection = new MySqlConnection(DBConnection.Connection))
                {
                    using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@customerName", customerName); 
                        command.Parameters.AddWithValue("@address", address);
                        command.Parameters.AddWithValue("@address2", address2);
                        command.Parameters.AddWithValue("@postalCode", postalCode);
                        command.Parameters.AddWithValue("@phone", phone);
                        command.Parameters.AddWithValue("@city", city);
                        command.Parameters.AddWithValue("@country", country);
                         
                        try 
                        { 
                            connection.Open(); int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0) 
                            { 
                                MessageBox.Show("Update successful.");
                            } 
                            else 
                            { 
                                MessageBox.Show("Update failed. Customer ID might not exist or values are the same."); } } catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
                    }
                    GetCustomers();
                }




            }
        }

    }
}
        