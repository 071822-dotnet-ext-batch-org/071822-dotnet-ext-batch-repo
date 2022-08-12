using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Round
    {
        //a constructor that takes 2 players.
        public Guid RoundId { get; set; } = Guid.NewGuid();
        public Guid GameId;
        public Round(Player p1, Player p2)
        {
            this.P1 = p1;
            this.P2 = p2;
        }

        public GamePiece P1Choice { get; set; }
        public GamePiece P2Choice { get; set; }
        public Player P1 { get; set; } = null;
        public Player P2 { get; set; } = null;
        public Guid RoundWinner { get; set; }// tie round = 0, p1 wins = 1, p2(computer) wins = 2.


    }
}