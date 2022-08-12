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
        /// This method will check if the player exists and return true if the playerId is in the Db.
        /// If not, returns false.
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns></returns>
        public bool ExistsPlayerById(Guid playerId)
        {
            using (SqlCommand command = new SqlCommand($"SELECT Top 1 PlayerId FROM Players WHERE PlayerId = @x", conn))
            {
                command.Parameters.AddWithValue("@x", playerId);// add dynamic data like this to protect against SQL Injection.
                conn.Open();
                SqlDataReader? ret = command.ExecuteReader();
                //return ret.Read() ? true : false;// this ternary operator is the same as the below if/else statement.
                if (ret.Read())
                {
                    conn.Close();
                    return true;
                }
                else
                {
                    conn.Close();
                    return false;
                }
            }
        }


        /// <summary>
        /// This method inserts a player to the Db.
        /// Returns 1 if successful. Returns 0 if unsuccessful.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int InsertNewPlayer(Player p)
        {
            using (SqlCommand command = new SqlCommand($"INSERT INTO Players VALUES (@playerId, @fname, @lname, @wins, @losses)", conn))
            {
                command.Parameters.AddWithValue("@fname", p.Fname);// add dynamic data like this to protect against SQL Injection.
                command.Parameters.AddWithValue("@lname", p.Lname);
                command.Parameters.AddWithValue("@wins", p.Wins);
                command.Parameters.AddWithValue("@losses", p.Losses);
                command.Parameters.AddWithValue("@playerId", p.PlayerId);
                conn.Open();
                int ret = command.ExecuteNonQuery();

                if (ret == 1)
                {
                    conn.Close();
                    return ret;
                }
                else
                {
                    conn.Close();
                    return ret;
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
                    Player p = new Player();
                    p.PlayerId = ret.GetGuid(0);
                    p.Fname = ret.GetString(1);
                    p.Lname = ret.GetString(2);
                    p.Wins = ret.GetInt32(3);
                    p.Losses = ret.GetInt32(4);
                    //Console.WriteLine($"p - {p.PlayerId} {p.Fname} {p.Lname} {p.Wins} {p.Losses}");
                    //Console.WriteLine($"ret - {ret.GetGuid(0)} {ret.GetString(1)} {ret.GetString(2)} {ret.GetInt32(3)} {ret.GetInt32(4)}");
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
        /// This method updates the table row that already exists with the specified PlayerId
        /// If sussessful, return true
        /// if unseccessful returns false;
        /// </summary>
        /// <param name="p"></param>
        public int UpdatePlayerById(Player p)
        {
            using (SqlCommand command = new SqlCommand($"UPDATE Players SET Fname = @a, Lname = @b, Wins = @c, Losses = @d WHERE PlayerId = @x", conn))
            {
                command.Parameters.AddWithValue("@a", p.Fname);// add dynamic data like this to protect against SQL Injection.
                command.Parameters.AddWithValue("@b", p.Lname);
                command.Parameters.AddWithValue("@c", p.Wins);
                command.Parameters.AddWithValue("@d", p.Losses);
                command.Parameters.AddWithValue("@x", p.PlayerId);

                conn.Open();
                int ret = command.ExecuteNonQuery();// if not successful, we will get a 0 back. Otherwise, 1.
                conn.Close();
                return ret;
            }
        }

        public int UpdateComputer(Player p)
        {
            using (SqlCommand command = new SqlCommand($"UPDATE Players SET Fname = @a, Lname = @b, Wins = @c, Losses = @d WHERE PlayerId = @x", conn))
            {
                command.Parameters.AddWithValue("@a", p.Fname);// add dynamic data like this to protect against SQL Injection.
                command.Parameters.AddWithValue("@b", p.Lname);
                command.Parameters.AddWithValue("@c", p.Wins);
                command.Parameters.AddWithValue("@d", p.Losses);
                command.Parameters.AddWithValue("@x", p.PlayerId);

                conn.Open();
                int ret = command.ExecuteNonQuery();// if not successful, we will get a 0 back. Otherwise, 1.
                conn.Close();
                //Console.WriteLine($"The ret is {ret}.");
                return ret;
            }
        }

        public int PersistGame(Game r)
        {
            using (SqlCommand command = new SqlCommand($"INSERT INTO Games (GameId, NumTies, P1, P2, GameWinner_PlayerId) VALUES (@gameid, @numties, @p1, @p2, @gameWinner)", conn))
            {
                command.Parameters.AddWithValue("@gameid", r.GameId);// add dynamic data like this to protect against SQL Injection.
                //command.Parameters.AddWithValue("@date", r.GameDate);
                command.Parameters.AddWithValue("@numties", r.NumberOfTies);
                command.Parameters.AddWithValue("@p1", r.P1.PlayerId);
                command.Parameters.AddWithValue("@p2", r.P2.PlayerId);
                command.Parameters.AddWithValue("@gameWinner", r.GameWinner.PlayerId);
                conn.Open();
                int ret = command.ExecuteNonQuery();

                if (ret == 1)
                {
                    conn.Close();
                    return ret;
                }
                else
                {
                    conn.Close();
                    return ret;
                }
            }
        }

        public int PersistRounds(Round r)
        {
            using (SqlCommand command = new SqlCommand($"INSERT INTO Rounds VALUES (@RoundId, @p1Choice, @p2choice, @roundWinner, @gameId)", conn))
            {
                command.Parameters.AddWithValue("@RoundId", r.RoundId);// add dynamic data like this to protect against SQL Injection.
                command.Parameters.AddWithValue("@p1Choice", (((int)r.P1Choice) - 1));
                command.Parameters.AddWithValue("@p2choice", (((int)r.P2Choice) - 1));
                command.Parameters.AddWithValue("@roundWinner", r.RoundWinner);
                command.Parameters.AddWithValue("@gameId", r.GameId);
                conn.Open();
                int ret = command.ExecuteNonQuery();

                if (ret == 1)
                {
                    conn.Close();
                    return ret;
                }
                else
                {
                    conn.Close();
                    return ret;
                }
            }
        }
    }
}