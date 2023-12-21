using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


//{
//    public class DBqueries : DbConnection
//    {
//        public List<List<string>> Query(string input)
//        {
//            Cmd = new MySqlCommand(input, Connection);
//           // if (Reader != null && !Reader.IsClosed)
//           // {
//              //  Reader.Close();
//            //}

//            Reader = Cmd.ExecuteReader();
//            var resultList = new List<List<string>>();
//            var columns = Reader.FieldCount;
//            while (Reader.Read())
//            {
//                List<string> dataEntry = new List<string>();
//                int count = 0;
//                while(count < columns)
//                {
//                    dataEntry.Add(Reader.GetString(count));
//                    count++;
//                }
//                resultList.Add(dataEntry);

//            }
//            Reader.Close();
//            return resultList;
//       }

//    }
//}
namespace C969Tpennartz.Database

{

    public class DBqueries : DbConnection

    {

        public List<List<string>> Query(string input)

        {

            StartConnection(); // Ensure the connection is open 



            using (MySqlCommand command = new MySqlCommand(input, Connection))

            {

                using (MySqlDataReader reader = command.ExecuteReader())

                {

                    var resultList = new List<List<string>>();



                    var columns = reader.FieldCount;



                    while (reader.Read())

                    {

                        List<string> dataEntry = new List<string>();



                        for (int count = 0; count < columns; count++)

                        {

                            dataEntry.Add(reader[count].ToString());

                        }



                        resultList.Add(dataEntry);

                    }



                    reader.Close();



                    return resultList;

                }

            }

        }

    }

}

 