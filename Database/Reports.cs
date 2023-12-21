using System;

using System.Linq;

using System.Collections.Generic;

using System.ComponentModel;

using System.IO;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace C969Tpennartz.Database

{

    public class Report : DbConnection

    {

        private string FilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), DateTime.UtcNow.ToString("yyyyMMdd-HHmmss") + ".report"); 

        private DBqueries ReportConnecton;
        private readonly Appointments Appointments = new Appointments();
        private BindingList<Appointments> ListAppointments;
        int currentMonth = DateTime.Now.Month;
        
        public Report()
        {
            ReportConnecton = new DBqueries();
        }
        
        

        public void GenerateReport()

        {

            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\reports\");

            var fileName = DateTime.UtcNow.ToString("yyyyMMdd-HHmmss") + ".report";

            var fileLocation = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\reports\";



            // Create separate FileStream instances for each report method 

            using (var fileStreamAppointments = new FileStream(Path.Combine(fileLocation, fileName), FileMode.Append, FileAccess.Write))

            using (var fileStreamConsultant = new FileStream(Path.Combine(fileLocation, "consultant_" + fileName), FileMode.Append, FileAccess.Write))

            using (var fileStreamCountries = new FileStream(Path.Combine(fileLocation, "countries_" + fileName), FileMode.Append, FileAccess.Write))

            {

                ListAppointments = Appointments.GetAppointments();



                GetAppointmentsMonthly(fileStreamAppointments);

                GetConsultantSchedules(fileStreamConsultant);

                GetCustomerCountries(fileStreamCountries);

            }

        }



        public void GetAppointmentsMonthly(FileStream fileStream)
        {
            int currentMonth = DateTime.Now.Month;
            string query = $"SELECT type, MONTH(start) AS month, COUNT(*) AS count FROM appointment WHERE MONTH(start) = {currentMonth} GROUP BY type, MONTH(start)";
            using (MySqlConnection connection = new MySqlConnection(DBConnection.Connection))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        var occurrencesByTypeAndMonth = new Dictionary<string, Dictionary<int, int>>();
                        while (reader.Read())
                        {
                            string type = reader.GetString("type");
                            int month = reader.GetInt32("month");
                            int count = reader.GetInt32("count");
                            if (!occurrencesByTypeAndMonth.ContainsKey(type))
                            {
                                occurrencesByTypeAndMonth[type] = new Dictionary<int, int>();
                            }
                            if (!occurrencesByTypeAndMonth[type].ContainsKey(month))
                            {
                                occurrencesByTypeAndMonth[type][month] = count;
                            }
                            else
                            { occurrencesByTypeAndMonth[type][month] += count; }
                        }

                        using (StreamWriter reports = new StreamWriter(fileStream))
                        {
                            reports.WriteLine("## Appointments by Type per Month:");
                            foreach (var typeKey in occurrencesByTypeAndMonth)
                            {
                                reports.WriteLine($"### Type: {typeKey.Key}");
                                foreach (var monthKey in typeKey.Value)
                                {
                                    reports.WriteLine($"{monthKey.Key}: {monthKey.Value}");
                                }
                                reports.WriteLine();
                            }
                        }
                    }
                }
            }

        }




                public void GetConsultantSchedules(FileStream fileStream)

        {

            using (StreamWriter reports = new StreamWriter(fileStream))

            {


                reports.WriteLine("\n\n##Consultant Schedules:");



                var sqlString = "SELECT userId, userName FROM user";

                var consultantList = ReportConnecton.Query(sqlString);



                foreach (var consultant in consultantList)

                {

                    var userId = int.Parse(consultant[0]);

                    var userName = consultant[1].ToString();



                    var userAppointments = ListAppointments.Where(a => a.userId == userId).ToList();

                    if (userAppointments.Any())

                    {

                        reports.WriteLine($"User ID: {userId}\nTitle | Customer | Type | Start | End");



                        userAppointments.ForEach(appointment =>

                        {

                            reports.WriteLine($"{appointment.Title} | {appointment.CustomerId} | {appointment.Type} | {appointment.Start:G} | {appointment.End:G}");

                        });

                    }

                }

            }

        }



        public void GetCustomerCountries(FileStream fileStream)

        {

            using (StreamWriter reports = new StreamWriter(fileStream))

            {

                reports.WriteLine("\n##Customers per Country:");



                var sqlString = "SELECT countryId, country FROM country";

                var countryList = ReportConnecton.Query(sqlString);



                var countryByCustomers = countryList.GroupBy(c => c[1].ToString())

                                                   .ToDictionary(grp => grp.Key, grp => grp.Count());



                foreach (var countryKey in countryByCustomers)

                {

                    reports.WriteLine($"{countryKey.Key}: {countryKey.Value}");

                }

            }

        }

    }
}