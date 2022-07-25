using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpsConsole2
{
    public class Player
    {
        //A class has Properties, attributes, constructors, and method (mainly)

        // an attribute is a single piece of data like an age, DoB, name, etc
        // an access modifier controls what parts of code can access a specific class or field (or property, or method)
        private int myAge = 0;

        // A Property is a special C# abstaction that is a combination of a Getter and a Setter and the data that they get and set.
        public DateTime DoB { get; set; } = new DateTime(1920, 1, 1);
        public string Fname { get; set; }
        public string Lname { get; set; }
        public bool Gender { get; set; }//true == female, false == male
        private int wins;
        public int Wins
        {
            get
            {
                return this.wins;
            }
            set
            {
                this.wins++;
            }
        }
        private int losses;
        public int Losses
        {
            get
            {
                return this.losses;
            }
            set
            {
                this.losses++;
            }
        }

        // Constructors are the methods called to instantiate and initialize a class object. these can be overloaded.
        // You are given a default constructor when you don't create one. BUT if ou create a parameterized constructor, 
        // you MUST create your own defualt constructor
        public Player() { }

        //parameterized constructor
        public Player(string fname)
        {
            this.Fname = fname;
        }

        // methods are sets of consecutive steps that the program completes. the can be called indiviudally.
        //getter and setter methods get/set the data while protecting the data.
        public int GetAge()
        {
            return myAge;
        }

        public void SetAge(int myAge)
        {
            if (myAge > 110 || myAge < 18)
            {
                throw new FieldAccessException($"You can't set the age to {myAge}");
            }
            else
            {
                this.myAge = myAge;
            }
        }


    }
}