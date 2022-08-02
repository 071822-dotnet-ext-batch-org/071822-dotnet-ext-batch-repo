using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("9_ClassesChallenge.Tests")]
namespace _9_ClassesChallenge
{
    internal class Human
    {
        private string firstName = "Pat";
        private string lastName = "Smyth";

        public Human() { }

        public Human(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        internal string AboutMe()
        {
            return $"My name is {this.firstName} {this.lastName}.";
        }
    }//end of class
}//end of namespace