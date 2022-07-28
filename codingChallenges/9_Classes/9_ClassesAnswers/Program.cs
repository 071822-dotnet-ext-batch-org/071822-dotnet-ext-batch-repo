using System;

namespace _9_ClassesChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Human jane = new Human();
            Human dick = new Human("Dick", "Butkus");
            System.Console.WriteLine(dick.AboutMe());

            Human2 mark = new Human2("Mark", "Moore", 42);//set all four values upon instantiation of the object
            Human2 bobby = new Human2("Bobby", "Brady", "green", 30);//set all four values upon instantiation of the object
            Human2 Arely = new Human2("Arely", "Moore", "brown");//set all four values upon instantiation of the object

            System.Console.WriteLine(mark.AboutMe2());
            System.Console.WriteLine(Arely.AboutMe2());
            System.Console.WriteLine(bobby.AboutMe2());

            System.Console.WriteLine(dick.AboutMe());
            bobby.Weight = 400;
            System.Console.WriteLine("Bobby's weight was set to 400...");
            System.Console.WriteLine("Bobby's weight was set to 401...");
            bobby.Weight = 401;
            System.Console.WriteLine($"Bobby's waight is now {bobby.Weight}");

        }
    }
}
