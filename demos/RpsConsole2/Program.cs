using System;

namespace RpsConsole2
{
    class Program
    {
        static void Main(string[] args)
        {
            //create an instance of a Player
            // Player p1 = new Player();
            // p1.Fname = "Mark";
            // p1.Lname = "Moore";
            // p1.DoB = new DateTime(1979, 5, 27);

            // Console.WriteLine($"The players name is {p1.Fname} {p1.Lname} and his age is {p1.DoB.ToShortDateString()}.");
            // p1.SetAge(109);
            // Console.WriteLine($"The players age is {p1.GetAge()}");
            // p1.Wins = 10;
            // int wins = p1.Wins;

            // Console.WriteLine($"{p1.Fname} has {p1.Wins} wins");






            //create players to play the game
            Player p1 = new Player();
            Player p2computer = new Player();

            // Welcome message...
            Console.WriteLine("\t\tWelcome to you favorite game!\n\t\tThis is Rock-Paper Scissors!\n");

            //Instructions to play... explanation of the game flow. which keys are used, etc
            Console.WriteLine("\tPress the number corresponding to Rock, Paper, or Scissors to make your choice.\n\tThe computer will make its choice and you will be notified as to the winner.\n\nTo play, press enter.\n\n");

            // (unseen to the user) create some variables to store which choice the user made, 
            // computer choice, computer wins, user wins, number of ties, player1 name (user), player2 name (computer for now)

            //we want the games variables outside the game loop so that they don't geet reset with every new game.
            // int computerGameWins = 0;
            // int player1GameWins = 0;

            //this loop is for each beginning of a game.
            while (true)
            {
                int computerChoice = -1;
                Random rand = new Random();// the Random class gets us a pseudorandom decimal between 0 and 1.
                int player1Choice = -1;
                int player1wins = 0;//how many rounds p1 has won
                int computerWins = 0;//how many rounds the compouter has won
                int numberOfTies = 0;//how many ties there have been
                //string player1Name = "";
                //string computerName = "Computer";
                string player1ChoiceStr;
                bool successfulConversion = false;
                //bool isTie = true;
                string playAgain = "";

                // get the users name
                Console.WriteLine("What is your name?");
                p1.Fname = Console.ReadLine();

                Console.WriteLine($"Welcome to R-P-S Game, {p1.Fname}");

                //a while loop to keep prompting the user for choices till there isn't a tie.
                while (player1wins < 2 && computerWins < 2)// the Game object will have a method that will calculate if there is a winner.
                {
                    // get the users choice
                    Console.WriteLine("Please enter...\n\t1 for Rock.\n\t2 for Paper.\n\t3 for Scissors.");
                    player1ChoiceStr = Console.ReadLine();

                    successfulConversion = Int32.TryParse(player1ChoiceStr, out player1Choice);// store these choices on the round object

                    // get the computers random choice
                    computerChoice = (rand.Next(1000) % 3) + 1;// store this on the Round object
                    Console.WriteLine(computerChoice);

                    // evaluate the choices to determine the winner of the round.
                    // if it was a tie
                    if (player1Choice == computerChoice)
                    {
                        // tell them it was a tie and loop back up to the top to reprompt
                        Console.WriteLine($"This round was a tie!... Let's try again.");
                        // update the tally for this gaming session of how many games the computer and the user have won.
                        numberOfTies++;// ++ increments the int by exactly 1.
                        //isTie = true;
                    }
                    // if the user won
                    else if ((player1Choice == 1 && computerChoice == 3) ||
                                (player1Choice == 2 && computerChoice == 1) ||
                                    (player1Choice == 3 && computerChoice == 2))
                    {
                        Console.WriteLine($"Congrats, {p1.Fname}, you won this round.");
                        // update the tally for this gaming session of how many games the computer and the user have won.

                        //maybe have local variables to store this dat temporarily?
                        player1wins = player1wins + 1;// this method gives you the option of incrementing by more than 1
                                                      // player1wins += 1;
                                                      // player1wins++;
                                                      //isTie = false;
                    }
                    //if the computer won
                    else
                    {// if the computer won
                        Console.WriteLine($"I'm sorry, {p2computer.Fname} won this round.");
                        // update the tally for this gaming session of how many games the computer and the user have won.
                        computerWins += 1;// this method gives you the option of incrementing by more than 1.
                        //isTie = false;
                    }

                    Console.WriteLine($"\tIn this game, you have won {player1wins} rounds, the computer has won {computerWins} rounds, amd there have been {numberOfTies} ties.\n\n");
                }

                //update the games won variables for each player
                if (player1wins == 2)
                {
                    //player1GameWins++;
                    p1.Wins = 1;
                }
                else
                {
                    //computerGameWins++;
                    p2computer.Wins = 1;
                }


                //tell the user the rounds played status.
                Console.WriteLine($"So far, you have won {p1.Wins} games and the computer has won {p2computer.Wins}");

                // ask if they want to play again. (if using rounds, each game would need to be stored.)
                Console.WriteLine($"Hey {p1.Fname}, would you like to play another game??\n\tEnter 'Y' to play again anything else to quit the program.");
                playAgain = Console.ReadLine();
                if (String.Equals("Y", playAgain, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"The strings are equal");
                    //isTie = true;
                }
                else
                {
                    //continue;// will end the current loop and immediately start the next iteration of the same loop.
                    Console.WriteLine($"I'm sorry to see you go... se la vi.");
                    break;
                }
            }
        }
    }
}

//REMEMBER TO VALIDATE USER INPUT
// try
// {
//     player1Choice = Int32.Parse(player1ChoiceStr);
// }
// catch (OverflowException ex)
// {
//     //this method to write to the console is string interpolation.
//     Console.WriteLine($"The parse method failed because '{ex.Message}'.");

// }
// catch (FormatException ex)
// {
//     Console.WriteLine($"The parse method failed because {ex.Message}");//this method to write to the console is string interpolation.
// }
// catch (ArgumentNullException ex)
// {
//     Console.WriteLine("The parse method failed because {0}", ex.Message);// This is Composite Formatting.
// }