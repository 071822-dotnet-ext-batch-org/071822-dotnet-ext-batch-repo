using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpsConsole2
{
    public class Game
    {
        public Player GameWinner { get; set; }
        public DateTime MyProperty { get; set; } = DateTime.Now;
        public int NumberOfTies { get; set; }// not sure why we decided to include this
        public List<Round> Rounds { get; set; } = new List<Round>();
        public Player P1 { get; set; } = new Player();
        public Player P2 { get; set; } = new Player("Computer");

    }
}