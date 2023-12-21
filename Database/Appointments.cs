using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969Tpennartz.Database
{


    public class Appointments : DbConnection

    {

        public int AppointmentId;

        public int CustomerId;

        public int userId;

        public string Title;

        public string Description;

        public string Location;

        public string Contact;

        public string Type;

        public string Url;

        public DateTime Start;

        public DateTime End;
        string userName;
        public User currentUser = new User();




        DBqueries ApptConnection;

        BindingList<Appointments> blAppointments;

        public bool ConflictCheck(int appointmentId, int userId, DateTime start, DateTime end)

        {



            TimeSpan startHours = new TimeSpan(8, 0, 0);

            TimeSpan endHours = new TimeSpan(18, 0, 0);

            TimeSpan apptStart = new TimeSpan(start.ToLocalTime().Hour, start.ToLocalTime().Minute, 0);

            TimeSpan apptEnd = new TimeSpan(end.ToLocalTime().Hour, end.ToLocalTime().Minute, 0);

            var sqlString =

                $"SELECT appointmentId FROM appointment WHERE NOT appointmentId = '{appointmentId}' AND userId = {userId} AND start <= '{end:yyyy-MM-dd HH:mm:ss}' AND end >= '{start:yyyy-MM-dd HH:mm:ss}'";

            Cmd = new MySqlCommand(sqlString, Connection);

            Reader = Cmd.ExecuteReader();

            if (Reader.HasRows)

            {

                Reader.Read();

                var conflictAppt = Convert.ToInt32(Reader.GetValue(0));

                if (appointmentId == conflictAppt)

                    return false;

                MessageBox.Show($"There is a time conflict with Appointment {conflictAppt}. Please select a different time.\nYour appointment was not saved.", "New Appointment", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                Reader.Close();

                return true;

            }

            else

            if (end.ToLocalTime().Date != start.ToLocalTime().Date) //Appointments must be on the same date 

            {

                MessageBox.Show("Appointments must start and end on the same day.\nYour appointment was not saved.", "New Appointment", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                Reader.Close();

                return true;

            }

            else

            if (apptEnd < apptStart)

            {

                MessageBox.Show($"Start time cannot be after End time.\nYour appointment was not saved.", "New Appointment", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                Reader.Close();

                return true;

            }

            else

            if (apptStart < startHours || apptStart > endHours || apptEnd < startHours || apptEnd > endHours)

            {

                MessageBox.Show($"The time range {apptStart:g} - {apptEnd:g} does not fall within the set business hours of 8:00 - 18:00");

                Reader.Close();

                return true;

            }

            else

            {

                Reader.Close();

                return false;

            }


        }




        public bool CheckNext15()

        {
            //userName = currentUser.GetUserName(C969Tpennartz.LoginForm.mainScreen.UserId);

            var sqlString =

                $"SELECT a.customerName,a.customerId,b.userId,b.start "

                + $"FROM customer a "

                + $"LEFT JOIN appointment b on a.customerId = b.customerId "

                + $"WHERE userId={userId} "

                + $"AND (start<'{DateTime.Now.AddMinutes(15).ToUniversalTime():yyyy-MM-dd HH:mm:ss}' " //Add 15 minutes to DateTime.Now then convert the time to Utc 

                + $"AND start>'{DateTime.Now.ToUniversalTime():yyyy-MM-dd HH:mm:ss}')";

            Cmd = new MySqlCommand(sqlString, Connection);

            Reader = Cmd.ExecuteReader();

            if (Reader.HasRows)

            {

                Reader.Read();

                MessageBox.Show($"You have an appointment with {Reader.GetValue(0)} at {DateTime.Parse(Reader.GetValue(3).ToString()).ToLocalTime():HH:mm} today");

                Reader.Close();

                return true;

            }

            else

            {

                Reader.Close();

                return false;

            }

        }



    public bool Create(Appointments newAppointment)

        {


           

            var userName = new User().GetUserName(C969Tpennartz.LoginForm.mainScreen.UserId);
            
            var sqlString = 

            "INSERT INTO appointment (customerId, userId, title, description, location, contact, type, start, end, url, createDate, createdBy, lastUpdate, lastUpdateBy) " +

            "VALUES (@CustomerId, @UserId, @Title, @Description, @Location, @Contact, @Type, @Start, @End, @Url, NOW(), @CreatedBy, NOW(), @LastUpdateBy);";

           

            using (var command = new MySqlCommand(sqlString, Connection))

            {

                command.Parameters.AddWithValue("@CustomerId", newAppointment.CustomerId);

                command.Parameters.AddWithValue("@UserId", newAppointment.userId);

                command.Parameters.AddWithValue("@Title", MySqlHelper.EscapeString(newAppointment.Title));

                command.Parameters.AddWithValue("@Description", MySqlHelper.EscapeString(newAppointment.Description));

                command.Parameters.AddWithValue("@Location", MySqlHelper.EscapeString(newAppointment.Location));

                command.Parameters.AddWithValue("@Contact", MySqlHelper.EscapeString(newAppointment.Contact));

                command.Parameters.AddWithValue("@Type", MySqlHelper.EscapeString(newAppointment.Type));

                command.Parameters.AddWithValue("@Start", newAppointment.Start.ToString("yyyy-MM-dd HH:mm:ss"));

                command.Parameters.AddWithValue("@End", newAppointment.End.ToString("yyyy-MM-dd HH:mm:ss"));

                command.Parameters.AddWithValue("@Url", newAppointment.Url);

                command.Parameters.AddWithValue("@CreatedBy", userName);

                command.Parameters.AddWithValue("@LastUpdateBy", userName);



                try

                {

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;

                }

                catch (Exception e)

                {

                    MessageBox.Show($"Please check that all required fields have been filled. \n{e}");

                    return false;

                }

                finally

                {

                    Connection.Close();

                }

            }



        }



        public void Delete(int appointmentId)

        {

            //using appointmentID parameter, "DELETE FROM appointment WHERE appointmentId={appointmentID}; 

            ApptConnection = new DBqueries();

            string sqlString = $"DELETE FROM appointment WHERE appointmentId={appointmentId}";

            var warning = MessageBox.Show($"Are you sure you want to delete appointment {appointmentId}?", $"Delete {appointmentId}?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            switch (warning)

            {

                case DialogResult.Yes:

                    _ = ApptConnection.Query(sqlString);

                    MessageBox.Show($"Successfully deleted appointment {appointmentId}");

                    break;

                default:

                    MessageBox.Show($"No appointments were deleted");

                    break;

            }

        }



        public bool Update(int appointmentId, Appointments appointment)

        {

            try

            {

                ApptConnection = new DBqueries();

                var userName = new User().GetUserName(C969Tpennartz.LoginForm.mainScreen.UserId);

                var sqlString = $"UPDATE appointment SET customerId={appointment.CustomerId},title='"

                    + MySqlHelper.EscapeString(appointment.Title)

                    + "',description='"

                    + MySqlHelper.EscapeString(appointment.Description)

                    + "',location='"

                    + MySqlHelper.EscapeString(appointment.Location)

                    + "',contact='"

                    + MySqlHelper.EscapeString(appointment.Contact)

                    + "',type='"

                    + MySqlHelper.EscapeString(appointment.Type)

                    + "',url='"

                    + $"',start='{appointment.Start:yyyy-MM-dd HH:mm:ss}',end='{appointment.End:yyyy-MM-dd HH:mm:ss}',lastUpdate=now(),lastUpdateBy='{userName}' "  

                    + $"WHERE appointmentId={appointmentId};";

                if (ConflictCheck(appointmentId, userId, appointment.Start, appointment.End))

                    return false;

                else

                {

                    _ = ApptConnection.Query(sqlString);

                    return true;

                }

            }

            catch (Exception e)

            {

                MessageBox.Show($"Please check that all required fields have been filled. \n{e}");

                return false;

            }

        }



        public BindingList<Appointments> GetAppointments()

        {

            ApptConnection = new DBqueries();

            blAppointments = new BindingList<Appointments>();

            string sqlString = "SELECT * FROM appointment";

            var dataIn = ApptConnection.Query(sqlString);

            foreach (var collumnIn in dataIn)

            {

                var appointment = new Appointments();



                appointment.AppointmentId = int.Parse(collumnIn[0]);

                appointment.CustomerId = int.Parse(collumnIn[1]);

                appointment.userId = int.Parse(collumnIn[2]);

                appointment.Title = collumnIn[3];

                appointment.Description = collumnIn[4];

                appointment.Location = collumnIn[5];

                appointment.Contact = collumnIn[6];

                appointment.Type = collumnIn[7];

                appointment.Start = TimeZoneInfo.ConvertTimeFromUtc(DateTime.Parse(collumnIn[9]), TimeZoneInfo.Local);

                appointment.End = TimeZoneInfo.ConvertTimeFromUtc(DateTime.Parse(collumnIn[10]), TimeZoneInfo.Local);

                blAppointments.Add(appointment);

            }

            return blAppointments;

        }



        public Appointments GetAppointments(int appointmentId)  

        {

            ApptConnection = new DBqueries();

            string sqlString = $"SELECT * FROM appointment WHERE appointmentId={appointmentId};";

            var dataIn = ApptConnection.Query(sqlString);

            var appointment = new Appointments();

            foreach (var collumnIn in dataIn) 

            {

                appointment.AppointmentId = int.Parse(collumnIn[0]);

                appointment.CustomerId = int.Parse(collumnIn[1]);

                appointment.userId = int.Parse(collumnIn[2]);

                appointment.Title = collumnIn[3];

                appointment.Description = collumnIn[4];

                appointment.Location = collumnIn[5];

                appointment.Contact = collumnIn[6];

                appointment.Type = collumnIn[7];

                appointment.Start = TimeZoneInfo.ConvertTimeFromUtc(DateTime.Parse(collumnIn[9]), TimeZoneInfo.Local);

                appointment.End = TimeZoneInfo.ConvertTimeFromUtc(DateTime.Parse(collumnIn[10]), TimeZoneInfo.Local);

            }

            return appointment;

        }

    }


}
