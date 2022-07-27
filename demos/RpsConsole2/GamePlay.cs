using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpsConsole2
{
    internal class GamePlay
    {
        /** a class library is a class that has functionality that I hav eunilize in another class or program.
            The benefit of a class library is that I can swap out the file for another
            while keep the endpoints the same adn completely change the functionality, security, databases used, 
            or methodology of the method used b the main program.
        **/

        private readonly Random rand = new Random();// the Random class gets us a pseudorandom decimal between 0 and 1.

        // These List<>'s are analogous to saving the data permanently in a Db. (We aren't doing that... YET.)
        //create a List<Game> to hold all the games
        private readonly List<Game> _games = new List<Game>();
        // create a List<Player> to hold allthe players.
        private readonly List<Player> _players = new List<Player>();
        // create a List<Round> to hold all the Rounds
        private readonly List<Round> _rounds = new List<Round>();
        private int player1wins = 0;//how many rounds p1 has won
        private int computerWins = 0;//how many rounds the compouter has won

        private Game _CurrentGame;

        /// <summary>
        /// This will create a game and add the computer to the P2 spot.
        /// </summary>
        internal void NewGame()
        {
            this._CurrentGame = new Game();
            // this._CurrentGame.P2 = this._players.Find(p => p.Fname == "The" && p.Lname == "Computer");
        }

        /// <summary>
        /// This method will:
        /// 1) Take P1's first and lasts names, 
        /// 2) verify that the player doesn't exist already,
        /// 3) add the player to the game,
        /// 4) return 1 if the player was already in the players
        /// 5) return 0 if not.
        /// </summary>
        /// <param name="playerNames"></param>
        /// <returns></returns>
        internal int P1Name(string[] playerNames)
        {
            foreach (Player p in this._players)
            {
                //see if the player is already in the List<Player>
                if (p.Fname.Equals(playerNames[0]) && p.Lname.Equals(playerNames[1]))
                {
                    //add this existing player to the current game.
                    this._CurrentGame.P1 = p;
                    return 1;//tell the main method that the player was already in the system
                }
            }

            // we won't add the player to the List<Player> till they have completed a full game.
            this._CurrentGame.P1.Fname = playerNames[0];
            this._CurrentGame.P1.Lname = playerNames[1];
            return 0;
        }

        internal Player GetP1()
        {
            return this._CurrentGame.P1;
        }

        /// <summary>
        /// returns true if one of the 2 players has won 2 rounds,
        /// return false if not.
        /// </summary>
        /// <returns></returns>
        internal bool IsThereAWinner()
        {
            // return true of one of the players has 2 round wins.




        }

        /// <summary>
        /// This method creates a round, adds the players to it, and adds the round to the current game..
        /// </summary>
        internal void PlayRound()
        {
            Round r = new Round(this._CurrentGame.P1, this._CurrentGame.P2);
            this._CurrentGame.Rounds.Add(r);
        }

        /// <summary>
        /// This method will:
        /// 1) validate the string can be comverted to an int
        /// 2) verify that the int is >0 and <4
        /// 3) if the conversion is successull and in range, get the computer choice and return true,
        /// 4) false if not.
        /// </summary>
        /// <param name="p12choiceStr"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        internal bool ValidateUserChoice(string p12choiceStr)
        {
            bool s = Int32.TryParse(p12choiceStr, out int res);// store these choices on the round object
            if (res > 0 && res < 4)
            {
                this._CurrentGame.Rounds[this._CurrentGame.Rounds.Count - 1].P2Choice = (GamePiece)((rand.Next(1000) % 3) + 1);
                this._CurrentGame.Rounds[this._CurrentGame.Rounds.Count - 1].P1Choice = (GamePiece)res;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Thss method will evaluate the players choices and 
        /// return 0 if the round was a tie, 
        /// 1 of P1 won the round, 
        /// 2 of P2 won the round.
        /// </summary>
        /// <returns></returns>
        internal int EvaluatePlayersChoices()
        {
            GamePiece p1Choice = this._CurrentGame.Rounds[this._CurrentGame.Rounds.Count - 1].P1Choice;
            GamePiece p2Choice = this._CurrentGame.Rounds[this._CurrentGame.Rounds.Count - 1].P2Choice;
            int numberOfTies = this._CurrentGame.NumberOfTies;
            Round round = this._CurrentGame.Rounds[this._CurrentGame.Rounds.Count - 1];

            // evaluate the choices to determine the winner of the round.
            // if it was a tie
            if (p1Choice == p2Choice)
            {
                // tell them it was a tie and loop back up to the top to reprompt
                //Console.WriteLine($"This round was a tie!... Let's try again.");
                // update the tally for this gaming session of how many games the computer and the user have won.
                numberOfTies++;// ++ increments the int by exactly 1.

                //update the roundwinner in the Round
                round.RoundWinner = 0;
                //add the round to the game List<>
                game.Rounds.Add(round);
                // add the round to the List of rounds
                rounds.Add(round);
            }
            // if the user won
            else if ((p1Choice == GamePiece.ROCK && p2Choice == GamePiece.SCISSORS) ||
                        (p1Choice == GamePiece.PAPER && p2Choice == GamePiece.ROCK) ||
                            (p1Choice == GamePiece.SCISSORS && p2Choice == GamePiece.PAPER))
            {
                Console.WriteLine($"Congrats, {game.P1.Fname}, you won this round.");
                // update the tally for this gaming session of how many games the computer and the user have won.

                //maybe have local variables to store this data temporarily?
                player1wins = player1wins + 1;// this method gives you the option of incrementing by more than 1

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
        }
    }//EoC
}//EoN