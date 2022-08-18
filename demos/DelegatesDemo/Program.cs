// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;

namespace DelegatesDemo
{
    public class Program
    {
        //1. Declare the delegate TYPE
        public delegate void RandoMethCall(HouseClass h);

        public static void Main(string[] args)
        {
            // HouseClass houseClass = new HouseClass();
            RandomMethods rm = new RandomMethods();

            //2. Create an instance of the delegate type.
            RandoMethCall rmc;

            //assign the methods to the instance
            rmc = rm.m1;
            rmc += rm.m2;

            //create the type that the delegate can accept.
            HouseClass hc = new HouseClass();
            hc.HouseType = "Elizabethan";
            hc.YearBuilt = 1810;

            rmc(hc);

            Console.WriteLine($"The {hc.HouseType} home was built in {hc.YearBuilt}");

            Action<HouseClass> actionDel = rm.m1;
            actionDel += rm.m2;
            hc.HouseType = "Elizabethan";// length 11
            hc.YearBuilt = 1810;

            actionDel(hc);
            Console.WriteLine($"The {hc.HouseType} home was built in {hc.YearBuilt}");


            // a func<> delegate returns a value BUT only the value returned form the final method in the invocation list.
            Func<HouseClass, int> funkyDel;
            funkyDel = rm.m4;
            funkyDel += rm.m3;

            int yearBuilt = funkyDel(hc);
            Console.WriteLine($"The year the house was built is 1865 => {yearBuilt}");


        }

    }
}

