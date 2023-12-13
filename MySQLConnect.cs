using System;
using MySql.Data.MySqlClient;
namespace PokemonReviewApp
{
	public class MySQLConnect
	{
        static MySqlConnection con;

        public static void Connect(string user, string password)
        {
            con = new MySqlConnection();

            try
            {
                con.ConnectionString = "server = localhost; User Id = " + user + "; " +
                    "Persist Security Info = True; database = hello; Password = " + password;
                con.Open();
                Console.WriteLine("Succesfully connected!");

            }

            catch (Exception e)
            {
                Console.WriteLine("Not Successful! due to " + e.ToString());
            }
        }
    }
}

