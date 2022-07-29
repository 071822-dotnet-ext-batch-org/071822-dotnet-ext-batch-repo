using System;

namespace inheritanceAndPolymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            Furniture f1 = new Furniture();
            Furniture f2 = new Furniture();
            Bed b1 = new Bed();
            Bed b2 = new Bed();
            Console.WriteLine($"The furniture has {f1.NumLegs} legs and the Bed has {b1.NumLegs} legs");
            Console.WriteLine($"The furniture editions number is => {Furniture.NumEditions++}");
            Console.WriteLine($"The bed editions number is => {Bed.NumEditions++}");
            Console.WriteLine(f1.AString());
            Console.WriteLine(b1.AString());

            Furniture.NumEditions++;
            Bed.NumEditions++;
            Furniture.NumEditions++;
            Bed.NumEditions++;
            Furniture.NumEditions++;
            Bed.NumEditions++;

            Console.WriteLine($"F1 => {f1.GetNumEditions()}");
            Console.WriteLine($"F2 =>{f2.GetNumEditions()}");
            Console.WriteLine($"B1 => {b1.GetNumEditions()}");
            Console.WriteLine($"B2 => {b2.GetNumEditions()}");

            Console.WriteLine($"{f1.Color} and {f1.Material}");
            Console.WriteLine($"{b1.Color} and {b1.Material}");


        }
    }
}
