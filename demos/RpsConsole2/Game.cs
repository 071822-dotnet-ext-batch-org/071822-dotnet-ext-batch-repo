using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpsConsole2
{
    public class Game
    {
        public Player GameWinner { get; set; }
        public DateTime GameDate { get; set; } = DateTime.Now;
        public int NumberOfTies { get; set; }// not sure why we decided to include this
        public List<Round> Rounds { get; set; } = new List<Round>();//a PROPERTY is a data structure that includes a getter and setter along with the field(attribute).
        public Player P1 { get; set; } = new Player();// this player has no data yet.
        public Player P2 { get; set; } = new Player("The", "Computer");

        /*Everything in a class is a Member
        there are types of memebers... fields/attributes, properties, constructors, methods

*/
    }
}