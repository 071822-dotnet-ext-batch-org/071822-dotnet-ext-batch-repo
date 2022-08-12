using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Game
    {
        public Guid GameId { get; set; } = Guid.NewGuid();
        public Player GameWinner { get; set; } = new Player();
        public DateTime GameDate { get; set; }
        public int NumberOfTies { get; set; }// not sure why we decided to include this
        public List<Round> Rounds { get; set; } = new List<Round>();//a PROPERTY is a data structure that includes a getter and setter along with the field(attribute).
        public Player P1 { get; set; } = new Player();// this player has no data yet.
        public Player P2 { get; set; } = new Player("The", "Computer");

        /*Everything in a class is a Member
        there are types of memebers... fields/attributes, properties, constructors, methods

        

*/
    }
}