using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inheritanceAndPolymorphism
{
    public class Furniture
    {
        public static int NumEditions = 0;

        //constructors are not inherited
        public Furniture()
        {
            this.Color = "grey";
        }

        public int NumLegs { get; set; } = 3;
        public string Color { get; set; } = "black";
        public string Material { get; set; } = "wood";

        // abstract means that the definition is incomplete.
        protected virtual string SoundWhenBreaking()
        {
            return "default Sound When breaking";
        }


        public virtual string GetNumEditions()
        {
            return Convert.ToString(NumEditions);
        }

        public virtual string AString()
        {
            return "this is a string";
        }



    }
}