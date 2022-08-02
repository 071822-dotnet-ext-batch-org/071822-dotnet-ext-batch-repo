using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("9_ClassesChallenge.Tests")]
namespace _9_ClassesChallenge
{
    internal class Human2
    {
        private string firstName = "Pat";
        private string lastName = "Smyth";
        private string eyeColor;
        private int age;

        private int _weight;
        public int Weight
        {
            get { return _weight; }
            set
            {
                if (value <= 400 && value >= 0)
                    this._weight = value;
                else
                    this._weight = 0;
            }
        }

        public Human2() { }

        public Human2(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public Human2(string firstName, string lastName, string eyeColor)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.eyeColor = eyeColor;
        }

        public Human2(string firstName, string lastName, int age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }

        public Human2(string firstName, string lastName, string eyeColor, int age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.eyeColor = eyeColor;
            this.age = age;
        }

        internal string AboutMe()
        {
            return $"My name is {this.firstName} {this.lastName}.";
        }

        internal string AboutMe2()
        {
            if (this.age == 0 && this.eyeColor == null)
                return $"My name is {firstName} {lastName}.";
            else if (this.age == 0)
                return $"My name is {firstName} {lastName}. My eye color is {this.eyeColor}.";
            else if (this.eyeColor == null)
                return $"My name is {firstName} {lastName}. My age is {this.age}.";
            else
                return $"My name is {firstName} {lastName}. My age is {this.age}. My eye color is {this.eyeColor}.";
        }
    }
}