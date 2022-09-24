using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class EmployeeRegisterDto : EmployeePublic
    {
        //constructor
        public EmployeeRegisterDto(string firstName, string lastName, bool isManager, string email, string password) : base(firstName, lastName, isManager, email)
        {
            this.password = password;
        }
        public string password { get; set; }
    }
}