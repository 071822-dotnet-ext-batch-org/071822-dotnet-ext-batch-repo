using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpsConsole2
{
    public interface IGetStuff
    {
        public Player GetP2();
        public Player GetP1();
        public Round GetLastRoundPlayed();
        public int GetPlayer1RoundWins();
        public bool IsThereAWinner();

    }
}