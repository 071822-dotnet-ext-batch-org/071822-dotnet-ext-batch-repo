using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Player
    {
        public Guid PlayerId { get; set; } = Guid.NewGuid();
        // A Property is a special C# abstaction that is a combination of a Getter and a Setter and the data that they get and set.
        public DateTime DoB { get; set; } = new DateTime(1920, 1, 1);
        public string Fname { get; set; }
        public string Lname { get; set; }
        public bool Gender { get; set; }//true == female, false == male
        public int Wins { get; set; }
        public int Losses { get; set; }

        public Player() { }
        //parameterized constructor
        public Player(string fname, string lname)
        {
            this.Fname = fname;
            this.Lname = lname;
        }
    }
}