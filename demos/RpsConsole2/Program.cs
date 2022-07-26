using System;
using System.Collections.Generic;

namespace RpsConsole2
{
    class Program
    {
        static void Main(string[] args)
        {
            //create an instance of a Player
            /*            
                        Player p1 = new Player();
                        p1.Fname = "Mark";
                        p1.Lname = "Moore";
                        p1.DoB = new DateTime(1979, 5, 27);

                        Console.WriteLine($"The players name is {p1.Fname} {p1.Lname} and his age is {p1.DoB.ToShortDateString()}.");
                        p1.SetAge(109);
                        Console.WriteLine($"The players age is {p1.GetAge()}");
                        p1.Wins = 10;
                        int wins = p1.Wins;

                        Console.WriteLine($"{p1.Fname} has {p1.Wins} wins");
            */


            Random rand = new Random();// the Random class gets us a pseudorandom decimal between 0 and 1.

            // These List<>'s are analogous to saving the data permanently in a Db. (We aren't doing that... YET.)
            //create a List<Game> to hold all the games
            List<Game> games = new List<Game>();
            // create a List<Player> to hold allthe players.
            List<Player> players = new List<Player>();
            // create a List<Round> to hold all the Rounds
            List<Round> rounds = new List<Round>();

            // Welcome message...
            Console.WriteLine("\t\tWelcome to you favorite game!\n\t\tThis is Rock-Paper Scissors!\n");

            //Instructions to play... explanation of the game flow. which keys are used, etc
            Console.WriteLine("\tPress the number corresponding to Rock, Paper, or Scissors to make your choice.\n\tThe computer will make its choice and you will be notified as to the winner.\n\nTo play, press enter.\n\n");

            //this loop is the beginning of each game.
            while (true)
            {
                //create a Game instance
                Game game = new Game();

                //int computerChoice = -1;
                //int player1Choice = -1;
                int player1wins = 0;//how many rounds p1 has won
                int computerWins = 0;//how many rounds the compouter has won
                int numberOfTies = 0;//how many ties there have been
                //string player1Name = "";
                //string computerName = "Computer";
                string player1ChoiceStr;
                bool successfulConversion = false;
                //bool isTie = true;
                string playAgain = "";// this hold the users answer for if they want to play again.

                // get the users name
                Console.WriteLine("What is your first name?");
                game.P1.Fname = Console.ReadLine();
                Console.WriteLine("What is your last name?");
                game.P1.Lname = Console.ReadLine();

                Console.WriteLine($"Welcome to R-P-S Game, {game.P1.Fname} {game.P1.Lname}.");

                //a while loop to play rounds till one player has 2 rounds won.
                while (player1wins < 2 && computerWins < 2)// the Game object will have a method that will calculate if there is a winner.
                {
                    //create a Round
                    Round round = new Round();

                    //assign the players to the round. They are already in the game instance.
                    round.P1 = game.P1;
                    round.P2 = game.P2;

                    //keep prompting till the user puts in the correct option range
                    do
                    {
                        // get the users choice
                        Console.WriteLine("Please enter...\n\t1 for Rock.\n\t2 for Paper.\n\t3 for Scissors.");
                        player1ChoiceStr = Console.ReadLine();

                        successfulConversion = Int32.TryParse(player1ChoiceStr, out int player1Choice);// store these choices on the round object

                        if (successfulConversion && player1Choice < 4 && player1Choice > 0)
                        {
                            //we need to convert the player1choice to the equivalent GamePiece type adn add it to the round data
                            round.P1Choice = (GamePiece)player1Choice;
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"Please enter a correct number. Either 1, 2, or 3.");
                        }

                    } while (true);

                    // get the computers random choice and add it to the round data
                    round.P2Choice = (GamePiece)(rand.Next(1000) % 3) + 1;// store this on the Round object

                    // evaluate the choices to determine the winner of the round.
                    // if it was a tie
                    if (round.P1Choice == round.P2Choice)
                    {
                        // tell them it was a tie and loop back up to the top to reprompt
                        Console.WriteLine($"This round was a tie!... Let's try again.");
                        // update the tally for this gaming session of how many games the computer and the user have won.
                        numberOfTies++;// ++ increments the int by exactly 1.
                        //isTie = true;

                        //update the roundwinner in the Round
                        round.RoundWinner = 0;
                        //add the round to the game List<>
                        game.Rounds.Add(round);
                        // add the round to the List of rounds
                        rounds.Add(round);
                    }
                    // if the user won
                    else if ((round.P1Choice == GamePiece.ROCK && round.P2Choice == GamePiece.SCISSORS) ||
                                (round.P1Choice == GamePiece.PAPER && round.P2Choice == GamePiece.ROCK) ||
                                    (round.P1Choice == GamePiece.SCISSORS && round.P2Choice == GamePiece.PAPER))
                    {
                        Console.WriteLine($"Congrats, {game.P1.Fname}, you won this round.");
                        // update the tally for this gaming session of how many games the computer and the user have won.

                        //maybe have local variables to store this dat temporarily?
                        player1wins = player1wins + 1;// this method gives you the option of incrementing by more than 1
                                                      // player1wins += 1;
                                                      // player1wins++;
                                                      //isTie = false;

                        //update the roundwinner in the Round
                        round.RoundWinner = 1;
                        //add the round to the game List<>
                        game.Rounds.Add(round);
                        // add the round to the List of rounds
                        rounds.Add(round);

                    }
                    //if the computer won
                    else
                    {// if the computer won
                        Console.WriteLine($"I'm sorry, {game.P2.Fname} won this round.");
                        // update the tally for this gaming session of how many games the computer and the user have won.
                        computerWins += 1;// this method gives you the option of incrementing by more than 1.
                                          //isTie = false;

                        //update the roundwinner in the Round
                        round.RoundWinner = 2;
                        //add the round to the game List<>
                        game.Rounds.Add(round);
                        // add the round to the List of rounds
                        rounds.Add(round);

                    }

                    Console.WriteLine($"\n\tYou chose {round.P1Choice}.\n\tThe {game.P2.Fname} chose {round.P2Choice}.\n");
                    Console.WriteLine($"\tIn this game:\nYou have won {player1wins} rounds,\nThe computer has won {computerWins} rounds, and\nThere have been {numberOfTies} ties.\n\n");
                }//end of 1 game

                //update the game variables for each player
                if (player1wins == 2)
                {
                    //update the w/l records of the players.
                    game.P1.Wins += 1;
                    players.Add(game.P1);
                    if (!players.Contains(game.P2))//this may need to be if 'players.Find(p => p.Fname == "Computer") == null'
                    {
                        game.P2.Losses += 1;
                        players.Add(game.P2);
                    }
                    else
                    {
                        //EXPLAIN THIS
                        players.Find(p => p.Fname == "Computer").Losses++;
                    }
                    //assign the game winner to the gamewinner MyProperty
                    game.GameWinner = game.P1;
                }
                else
                {
                    //update the w/l records of the players.
                    game.P1.Losses += 1;
                    // add both players to the players List.
                    players.Add(game.P1);
                    if (!players.Contains(game.P2))//this may need to be if 'players.Find(p => p.Fname == "Computer") == null'
                    {
                        game.P2.Wins += 1;
                        players.Add(game.P2);
                    }
                    else
                    {
                        //EXPLAIN THIS
                        players.Find(p => p.Fname == "Computer").Wins++;
                    }
                    //assign the game winner to the gamewinner MyProperty
                    game.GameWinner = game.P2;
                }

                //tell the user the rounds played status.
                Console.WriteLine($"So far, your record is {game.P1.Wins}/{game.P1.Losses} and the computer's record is {game.P2.Wins}/{game.P2.Losses}.");

                // ask if they want to play again. (if using rounds, each game would need to be stored.)
                Console.WriteLine($"Hey {game.P1.Fname}, would you like to play another game??\n\tEnter 'Y' to play again anything else to quit the program.");
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
            }// exit gameplay
        }//EoM
    }//EoC
}// EoN

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