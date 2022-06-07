using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Create_MacAddress_DB
{
    internal class Program
    {
        static MySqlConnection Connection;
        
        /// <summary>
        /// creates a random 6bit byte array.
        /// </summary>
        /// <returns></returns>
        private static string CreateMac_Address()
        {
            var random = new Random();
            var buffer = new byte[6];
            random.NextBytes(buffer);
            var result = String.Concat(buffer.Select(x => string.Format("{0}:", x.ToString("X2"))).ToArray());
            return result.TrimEnd(':');
        }
        /// <summary>
        /// coinflip
        /// </summary>
        /// <returns></returns>
        private static int CreateIs_Avail()
        {
            var random = new Random();
            var num = random.Next(100000);
            if (num <= 50000)
                return 1;
            return 0;
        }

        private static bool OpenConnection() 
        {
            try
            {
                Connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server. Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }
        private static bool CloseConnection()
        {
            try
            {
                Connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        
        static void Main(string[] args)
        {
            string server = "localhost";
            string database = "mac_addresses";
            string uid = "jpetko";
            string password = "philo74";
            string connectionString = "SERVER=" + server + "; DATABASE=" + database + "; UID=" + uid + "; PASSWORD=" + password + ";";
            Connection = new MySqlConnection(connectionString);
            List<string> MacAddresses = new List<string>();
            if (OpenConnection())
            {
                for (int x = 0; x <= 1000; x++) 
                {
                    MacAddresses.Add(CreateMac_Address());
                    string query = "INSERT INTO available_mac (MAC_Address,isAvailable) VALUES('" + CreateMac_Address() + "',' " + CreateIs_Avail() + "')";
                    
                    MySqlCommand cmd = new MySqlCommand(query,Connection);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine(query);
                    Thread.Sleep(50); //allows for better randomization and Random class used in CreatMac_Address is based on system time.
                }
            }

            CloseConnection();
        }
    }
}
