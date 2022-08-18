using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelegatesDemo
{
    public class RandomMethods
    {

        public void m1(HouseClass a)
        {
            Console.WriteLine("I'm M1.");
            a.HouseType = "Modern Gothic";
        }

        public void m2(HouseClass a)
        {
            Console.WriteLine("I'm M2.");
            a.YearBuilt = 1865;
        }

        public int m3(HouseClass a)
        {
            Console.WriteLine("I'm M3.");
            return a.HouseType.Length;
        }

        public int m4(HouseClass a)
        {
            Console.WriteLine("I'm M4.");
            return a.YearBuilt;
        }

    }
}