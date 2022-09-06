using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReflectionDemoProj
{
    public class First1
    {
        private int Age { get; set; } = 43;
        private string Name { get; set; } = "blimey!";

        public First1() { }

        public First1(int age, string name)
        {
            this.Age = age;
            this.Name = name;
        }

        public int GetMyAge()
        {
            return this.Age;
        }

        public string GetMyName()
        {
            return this.Name;
        }

        private string GetMyNameAndAge(int x, string y)
        {
            return $"{y}'s age is {x}";
        }

        public static void mystaticmethod()
        {

        }
    }
}