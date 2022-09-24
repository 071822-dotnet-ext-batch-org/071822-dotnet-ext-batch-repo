using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class ApprovalDto
    {
        public Guid EmployeeID { get; set; }
        public Guid RequestID { get; set; }
        public int Status { get; set; }
    }
}
