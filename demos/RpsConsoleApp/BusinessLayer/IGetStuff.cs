using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace BusinessLayer
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