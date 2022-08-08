using System.Data.SqlClient;
using System;

namespace RepoLayer
{
    public class adonetaccess
    {
        private static readonly SqlConnection conn = new SqlConnection("Server=tcp:p1rebuild.database.windows.net,1433;Initial Catalog=071822_batch_Db;Persist Security Info=False;User ID=p1rebuild;Password=Have1pie;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");



        public void testQuery()
        {
            // using (SqlCommand command = new SqlCommand("SELECT * FROM Customers", conn))
            // {
            //     conn.Open();
            //     SqlDataReader? ret = command.ExecuteReader();

            //     while (ret.Read())
            //     {
            //         Console.WriteLine($"{ret.GetInt32(0)} - {ret[1]} - {ret[2]} - {ret[3]} ");
            //     }
            // }
            // conn.Close();


            using (SqlCommand command = new SqlCommand($"SELECT FirstName, LastName FROM Customers WHERE FirstName = @x", conn))
            {
                conn.Open();
                command.Parameters.AddWithValue("@x", "John");
                SqlDataReader? ret = command.ExecuteReader();

                while (ret.Read())
                {
                    Console.WriteLine($"{ret[0]} - {ret[1]}");




                    //when youa re mapping the raw data from the Db, you need to place the data into you C3 Class object instance
                    // to use within your app.
                    // Customer c = new Customer() {
                    //   firstname = ret[1],
                    //   customerId = ret.GetInt32(0),//type def anything other than a string
                    //  };

                    // return c;
                }
            }
        }
    }
}