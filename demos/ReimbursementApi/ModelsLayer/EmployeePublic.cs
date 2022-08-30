using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ModelsLayer
{
    //this is the super class to Employee
    public class EmployeePublic
    {
        //constructor
        public EmployeePublic(string firstName, string lastName, bool isManager, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            IsManager = isManager;
            Email = email;
        }

        [Range(4, 10)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsManager { get; set; }
        public string Email { get; set; }
    }
}