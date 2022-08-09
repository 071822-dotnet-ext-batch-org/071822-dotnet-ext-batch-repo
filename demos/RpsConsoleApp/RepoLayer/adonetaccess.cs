using System.Data.SqlClient;
using System;
using Models;

namespace RepoLayer
{
    public class adonetaccess
    {
        private static readonly SqlConnection conn = new SqlConnection("Server=tcp:p1rebuild.database.windows.net,1433;Initial Catalog=071822_batch_Db;Persist Security Info=False;User ID=p1rebuild;Password=Have1pie;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        /// <summary>
        /// This method will query the Db for a entity called "The Computer".
        /// If it exists, return the computer object,
        /// If not, return null.
        /// </summary>
        /// <returns></returns>
        public Player? GetComputerIfExists()
        {
            using (SqlCommand command = new SqlCommand($"SELECT Top 1 PlayerId, Fname, Lname, Wins, Losses FROM Players WHERE Fname = 'The' AND Lname = 'Computer'", conn))
            {
                conn.Open();
                SqlDataReader? ret = command.ExecuteReader();

                if (ret.Read())
                {
                    Player p = new Player()
                    {
                        PlayerId = ret.GetGuid(0),
                        Fname = ret.GetString(1),
                        Lname = ret.GetString(2),
                        Wins = ret.GetInt32(3),
                        Losses = ret.GetInt32(4)
                    };
                    conn.Close();
                    return p;
                }
                else
                {
                    conn.Close();
                    return null;
                }
            }
        }

        /// <summary>
        /// This method will check if the player is in the Db and 
        /// return the player object, if it exists
        /// if not, returns null.
        /// </summary>
        /// <param name="playerNames"></param>
        /// <returns></returns>
        public Player? P1Name(string fname, string lname)
        {
            //string query = "SELECT FirstName, LastName, Wins, Losses FROM Players WHERE FirstName = @x AND Lname = @y";
            using (SqlCommand command = new SqlCommand($"SELECT Top 1 PlayerId, Fname, Lname, Wins, Losses FROM Players WHERE Fname = @fname AND Lname = @lname", conn))
            {
                command.Parameters.AddWithValue("@fname", fname);// add dynamic data like this to protect against SQL Injection.
                command.Parameters.AddWithValue("@lname", lname);
                conn.Open();
                SqlDataReader? ret = command.ExecuteReader();

                if (ret.Read())
                {
                    // Player p = new Player()
                    // {
                    //     PlayerId = ret.GetGuid(0),
                    //     Fname = ret.GetString(1),
                    //     Lname = ret.GetString(2),
                    //     Wins = ret.GetInt32(3),
                    //     Losses = ret.GetInt32(4)
                    // };
                    Player p = new Player();
                    p.PlayerId = ret.GetGuid(0);
                    p.Fname = ret.GetString(1);
                    p.Lname = ret.GetString(2);
                    p.Wins = ret.GetInt32(3);
                    p.Losses = ret.GetInt32(4);

                    conn.Close();
                    return p;
                }
                else
                {
                    conn.Close();
                    return null;
                }
            }
        }

        // public void testQuery()
        // {
        //     // using (SqlCommand command = new SqlCommand("SELECT * FROM Customers", conn))
        //     // {
        //     //     conn.Open();
        //     //     SqlDataReader? ret = command.ExecuteReader();

        //     //     while (ret.Read())
        //     //     {
        //     //         Console.WriteLine($"{ret.GetInt32(0)} - {ret[1]} - {ret[2]} - {ret[3]} ");
        //     //     }
        //     // }

        //     using (SqlCommand command = new SqlCommand($"SELECT FirstName, LastName FROM Customers WHERE FirstName = @x", conn))
        //     {
        //         command.Parameters.AddWithValue("@x", "John");
        //         conn.Open();
        //         SqlDataReader? ret = command.ExecuteReader();

        //         while (ret.Read())
        //         {
        //             Console.WriteLine($"{ret[0]} - {ret[1]}");
        //             //when you are mapping the raw data from the Db, you need to place the data into you C3 Class object instance to use within your app.
        //             // Customer c = new Customer() {
        //             //   firstname = ret[1],
        //             //   customerId = ret.GetInt32(0),//type def anything other than a string
        //             //  };

        //             // return c;
        //         }
        //         conn.Close();
        //     }
        // }
    }
}