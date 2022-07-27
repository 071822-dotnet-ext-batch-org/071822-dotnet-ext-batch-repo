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

        internal void NewGame()
        {
            this._CurrentGame = new Game();
        }

        internal void P1Name(string[] playerNames)
        {
            this._CurrentGame.P1.Fname = playerNames[0];
            this._CurrentGame.P1.Lname = playerNames[1];
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
            // return true of one of hte player has 2 round wins.




        }
    }//EoC
}//EoN