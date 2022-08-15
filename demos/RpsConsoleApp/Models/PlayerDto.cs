using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{    
    public class PlayerDto
    {
        //public static int sharedInt { get; set; }
        public string Fname { get; set; } = "";
        public string Lname { get; set; } = "";
    }
}


/*
 * A static variable is shared between instances of the class,
 * 
 * The default value oyou give will be a unique value ot each instance.
 * 
 * **/