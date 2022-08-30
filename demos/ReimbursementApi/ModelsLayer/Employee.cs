namespace ModelsLayer
{
    public class Employee : EmployeePublic
    {
        public Employee(Guid employeeID, string firstName, string lastName, bool isManager, string email, string passWord) : base(firstName, lastName, isManager, email)
        {
            EmployeeID = employeeID;
            PassWord = passWord;
        }

        public Guid EmployeeID { get; set; }
        public string PassWord { get; set; }
    }
}