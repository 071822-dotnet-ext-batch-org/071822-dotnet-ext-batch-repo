using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inheritanceAndPolymorphism
{
    public class Bed : Furniture
    {
        //base is the direct parent construcor.
        public Bed() : base()
        {
            this.Material = "cotton";
        }

        public override string GetNumEditions()
        {
            return $" I've got a different GetNumEditions method. => {Convert.ToString(NumEditions)}";
        }

        public override string AString()
        {
            return "this is a DIFFERENT string";
        }

        protected override string SoundWhenBreaking()
        {
            return "screeeeech";
        }

    }
}