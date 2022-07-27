using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpsConsole2
{
    public class Round
    {
        public GamePiece P1Choice { get; set; }
        public GamePiece P2Choice { get; set; }
        public Player P1 { get; set; } = null;
        public Player P2 { get; set; } = null;
        public int RoundWinner { get; set; } = 0;// tie round = 0, p1 wins = 1, p2(computer) wins = 2.
    }
}