using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpsConsole2
{
    public class GamePlay : IGamePlay, IGetStuff
    {
        /** a class library is a class that has functionality that I hav eunilize in another class or program.
            The benefit of a class library is that I can swap out the file for another
            while keep the endpoints the same and completely change the functionality, security, databases used, 
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
        public void NewGame()
        {
            this._CurrentGame = new Game();
        }

        /// <summary>
        /// This method will:
        /// 1) Take P1's first and lasts names, 
        /// 2) verify that the player doesn't exist already,
        /// 3) add the player to the game,
        /// 4) return true if the player was already in the players list
        /// 5) return false if not.
        /// </summary>
        /// <param name="playerNames"></param>
        /// <returns></returns>
        public bool P1Name(string[] playerNames)
        {
            foreach (Player p in this._players) // [p1, p2, p3, p4, p5]
            {
                //see if the player is already in the List<Player>
                if (p.Fname.Equals(playerNames[0]) && p.Lname.Equals(playerNames[1]))
                {
                    //add this existing player to the current game.
                    this._CurrentGame.P1 = p;
                    return true;//tell the main method that the player was already in the system
                }
            }

            // we won't add the player to the List<Player> till they have completed a full game.
            if (playerNames.Length > 1)
            {
                this._CurrentGame.P1.Fname = playerNames[0];
                this._CurrentGame.P1.Lname = playerNames[1];
            }
            else if (playerNames.Length == 1)
            {
                this._CurrentGame.P1.Fname = playerNames[0];
                this._CurrentGame.P1.Lname = "default";
            }
            else
            {
                this._CurrentGame.P1.Fname = "default";
                this._CurrentGame.P1.Lname = "name";
            }
            return false;
        }

        public Player GetP2()
        {
            return this._CurrentGame.P2;
        }

        public Player GetP1()
        {
            return this._CurrentGame.P1;
        }

        /// <summary>
        /// returns true if one of the 2 players has won 2 rounds,
        /// return false if not.
        /// </summary>
        /// <returns></returns>
        public bool IsThereAWinner()
        {
            // return true of one of the players has 2 round wins.
            if (player1wins == 2 || computerWins == 2)
            {
                return true;
            }
            else return false;
        }

        /// <summary>
        /// This method creates a round, adds the players to it, and adds the round to the current game..
        /// </summary>
        public void PlayRound()
        {
            Round r = new Round(this._CurrentGame.P1, this._CurrentGame.P2);
            this._CurrentGame.Rounds.Add(r);
        }

        /// <summary>
        /// This method will:
        /// 1) validate the string can be converted to an int
        /// 2) verify that the int is >0 and less than 4
        /// 3) if the conversion is successull and in range, get the computer choice and return true,
        /// 4) false if not.
        /// </summary>
        /// <param name="p12choiceStr"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public bool ValidateUserChoice(string p12choiceStr)
        {
            bool success = Int32.TryParse(p12choiceStr, out int result);// store these choices on the round object
            if (result > 0 && result < 4)
            {
                //ArrayName[0] will accesss the first elelment of an array.
                // arrayName[1] 2nd element
                // arrayName[3]
                // if there are 3 filled elements of an array or List<>, the Count = 3 but the last element is element #2

                int indexOfLastRoundAdded = this._CurrentGame.Rounds.Count - 1;// gets the element number of the final round added to the rounds list in the game
                Round lastRoundAddedToTheListOfRoundsInTheGame = this._CurrentGame.Rounds[indexOfLastRoundAdded];
                lastRoundAddedToTheListOfRoundsInTheGame.P2Choice = (GamePiece)((rand.Next(1000) % 3) + 1);// this action would be better in another method that would be called from Main()

                this._CurrentGame.Rounds[this._CurrentGame.Rounds.Count - 1].P1Choice = (GamePiece)result;
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
        public int EvaluatePlayersChoices()
        {
            GamePiece p1Choice = this._CurrentGame.Rounds[this._CurrentGame.Rounds.Count - 1].P1Choice;
            GamePiece p2Choice = this._CurrentGame.Rounds[this._CurrentGame.Rounds.Count - 1].P2Choice;
            //int numberOfTies = this._CurrentGame.NumberOfTies;
            Round round = this._CurrentGame.Rounds[this._CurrentGame.Rounds.Count - 1];

            // evaluate the choices to determine the winner of the round.            
            if (p1Choice == p2Choice)// if it was a tie
            {
                // update the tally for this gaming session of how many games the computer and the user have won.
                //numberOfTies++;// ++ increments the int by exactly 1.
                this._CurrentGame.NumberOfTies++;

                //update the roundwinner in the Round
                round.RoundWinner = 0;
                // add the round to the List of rounds
                this._rounds.Add(round);
                return 0;
            }
            // if the user won
            else if ((p1Choice == GamePiece.ROCK && p2Choice == GamePiece.SCISSORS) ||
                        (p1Choice == GamePiece.PAPER && p2Choice == GamePiece.ROCK) ||
                            (p1Choice == GamePiece.SCISSORS && p2Choice == GamePiece.PAPER))
            {
                player1wins = player1wins + 1;// this method gives you the option of incrementing by more than 1
                //update the roundwinner in the Round
                round.RoundWinner = 1;
                // add the round to the List of rounds
                this._rounds.Add(round);
                return 1;
            }
            else//if the computer won
            {
                // update the tally for this gaming session of how many games the computer and the user have won.
                computerWins += 1;// this method gives you the option of incrementing by more than 1.
                //update the roundwinner in the Round
                round.RoundWinner = 2;
                // add the round to the List of rounds
                this._rounds.Add(round);
                return 2;
            }
        }

        public Round GetLastRoundPlayed()
        {
            Round r = this._CurrentGame.Rounds[this._CurrentGame.Rounds.Count - 1];
            return r;
        }

        public int GetPlayer1RoundWins()
        {
            return this.player1wins;
        }

        public int GetComputerRoundWins()
        {
            return this.computerWins;
        }

        public int GetNumberOfTies()
        {
            return this._CurrentGame.NumberOfTies;
        }

        public Game FinalizeGame()
        {
            //assign the gamewinner
            if (player1wins == 2)
            {
                this._CurrentGame.GameWinner = this._CurrentGame.P1;
                this._CurrentGame.P1.Wins++;
                //this._CurrentGame.P1.Wins = this._CurrentGame.P1.Wins +1;

                this._CurrentGame.P2.Losses++;
            }
            else
            {
                this._CurrentGame.GameWinner = this._CurrentGame.P2;
                this._CurrentGame.P2.Wins++;
                this._CurrentGame.P1.Losses++;
            }
            //add/update the p1 to the List<Player>
            if (!_players.Exists(p => p.Fname == this._CurrentGame.P1.Fname && p.Lname == this._CurrentGame.P1.Lname))
            {
                this._players.Add(this._CurrentGame.P1);
            }
            else
            {
                //shouldn't have to make any changes to the player in the list because the P1 in currentGame is a reference to it
                // this means that P1 points to the same player as the List player. 
            }

            // add the game to the game list
            this._games.Add(this._CurrentGame);
            return this._CurrentGame;
        }

        /// <summary>
        /// This method resets the GamePlaye class to start a new game.
        /// </summary>
        public void ResetForNewGame()
        {
            player1wins = 0;//how many rounds p1 has won
            computerWins = 0;//how many rounds the compouter has won
            _CurrentGame = null;
        }

        void IGamePlay.GetAnError() { }

        public void ShowAccessAmbiguity()
        {
            Player p = new Player();
            p.testint = 1;
            int testint = 0;
            testint = 5;
            p.testint = testint;
            Console.WriteLine(p.testint);
        }

    }//EoC
}//EoN