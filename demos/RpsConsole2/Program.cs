using System;
using System.Collections.Generic;
using System.Linq;

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

            // Random rand = new Random();// the Random class gets us a pseudorandom decimal between 0 and 1.

            // // These List<>'s are analogous to saving the data permanently in a Db. (We aren't doing that... YET.)
            // //create a List<Game> to hold all the games
            // List<Game> games = new List<Game>();
            // // create a List<Player> to hold allthe players.
            // List<Player> players = new List<Player>();
            // // create a List<Round> to hold all the Rounds
            // List<Round> rounds = new List<Round>();

            GamePlay gameplay = new GamePlay();

            // maybe I want to add the ability to check out my stats without playing a game?

            // Welcome message...
            Console.WriteLine("\t\tWelcome to you favorite game!\n\t\tThis is Rock-Paper Scissors!\n");

            //Instructions to play... explanation of the game flow. which keys are used, etc
            Console.WriteLine("\tPress the number corresponding to Rock, Paper, or Scissors to make your choice.\n\tThe computer will make its choice and you will be notified as to the winner.\n\n");

            //this loop is the beginning of each game.
            while (true)
            {
                // this creates a new game within the GamePlay Class instance.
                gameplay.NewGame();

                // get the users name
                Console.WriteLine("What is your first and last name?");
                bool playerAlreadyInList = gameplay.P1Name(Console.ReadLine().Split(" "));// [my,name,is,mark,moore]

                if (playerAlreadyInList)
                {
                    Console.WriteLine($"Hey, {gameplay.GetP1().Fname} {gameplay.GetP1().Lname}, it looks like you are a returning player. Welcome back.");
                }
                else
                {
                    Console.WriteLine($"Welcome, {gameplay.GetP1().Fname} {gameplay.GetP1().Lname}. It looks like you are a new player. Complete a game to be permanently added to our records.");
                }

                //a while loop to play rounds till one player has 2 rounds won.
                while (!gameplay.IsThereAWinner())// the Game object will have a method that will calculate if there is a winner.
                {
                    //call PlayGame to create a round and add the current games players to it.
                    gameplay.PlayRound();
                    //keep prompting till the user puts in the correct option range
                    do
                    {
                        Console.WriteLine("Please enter...\n\t1 for Rock.\n\t2 for Paper.\n\t3 for Scissors.");

                        // validate the users choice and assign the 
                        bool successfulConversion = gameplay.ValidateUserChoice(Console.ReadLine());
                        if (successfulConversion) break;
                        else Console.WriteLine($"Please enter a correct number. Either 1, 2, or 3.");

                    } while (true);// this is an infinite loop.


                    // evaluate the round.
                    int roundWinner = gameplay.EvaluatePlayersChoices();

                    // tell them it was a tie and loop back up to the top to reprompt
                    if (roundWinner == 0) Console.WriteLine($"This round was a tie!... Let's try again.");
                    // if the user won
                    else if (roundWinner == 1) Console.WriteLine($"Congrats, {gameplay.GetP1().Fname}, you won this round.");
                    //if the computer won
                    else Console.WriteLine($"I'm sorry, {gameplay.GetP2().Fname} {gameplay.GetP2().Lname} won this round.");

                    Console.WriteLine($"\n\tYou chose {gameplay.GetLastRoundPlayed().P1Choice}.\n\t{gameplay.GetP2().Fname} {gameplay.GetP2().Lname} chose {gameplay.GetLastRoundPlayed().P2Choice}.\n");
                    Console.WriteLine($"\tIn this game:\nYou have won {gameplay.GetPlayer1RoundWins()} rounds,\nThe computer has won {gameplay.GetComputerRoundWins()} rounds, and\nThere have been {gameplay.GetNumberOfTies()} ties.\n\n");
                }//end of 1 game

                //call a method to finalize the game.
                Game g = gameplay.FinalizeGame();

                //tell the user the rounds played status.
                Console.WriteLine($"So far, your record is {g.P1.Wins}/{g.P1.Losses} and the computer's record is {g.P2.Wins}/{g.P2.Losses}.");


                // ask if they want to play again. (if using rounds, each game would need to be stored.)
                Console.WriteLine($"Hey {g.P1.Fname}, would you like to play another game??\n\tEnter 'Y' to play again anything else to quit the program.");
                string playAgain = Console.ReadLine();
                if (String.Equals("Y", playAgain, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"The strings are equal");
                    //call a method to reset the necessary variables to start a new game.
                    gameplay.ResetForNewGame();
                }
                else
                {
                    //continue;// will end the current loop and immediately start the next iteration of the same loop.
                    Console.WriteLine($"I'm sorry to see you go... se la vi.");
                    break;
                }
            }// exit gameplay



            // What code would be necessary to spit out the game stats to the user.

            //what is the users win/loss ratio for all rounds played.

            //stats for the last gamel played

            // go to the final Game played
            // show the opponent.
            // show the choices made and result
            // Game finalgame = games[games.Count - 1];
            // Console.WriteLine($"The final game played was between {finalgame.P1.Fname} and {finalgame.P2.Fname}");
            // Console.WriteLine("For each round, the results were.");
            // foreach (Round r in finalgame.Rounds)
            // {
            //     int rnum = 1;
            //     string roundWinner = "";
            //     switch (r.RoundWinner)
            //     {
            //         case 0:
            //             roundWinner += "nobody";
            //             break;
            //         case 1:
            //             roundWinner += $"{r.P1.Fname}";
            //             break;
            //         case 2:
            //             roundWinner += $"{r.P2.Fname}";
            //             break;
            //         default:
            //             roundWinner += "nobody";
            //             break;
            //     }
            //     Console.WriteLine($" In Round {rnum++}, you chose {r.P1Choice}. The {r.P2.Fname} chose {r.P2Choice}. The winner was {roundWinner}");
            // }
            // Console.WriteLine($"In the end, the game winner was {finalgame.GameWinner.Fname}.");



            //out of all rounds what is the how many of rock to paper to scissors




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