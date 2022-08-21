using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class UpdatedRequestDto
    {
        public UpdatedRequestDto(Guid requestId, string firstName, string lastName, int status)
        {
            RequestId = requestId;
            FirstName = firstName;
            LastName = lastName;
            Status = status;
        }

        public Guid RequestId { get; set; } /* = string.Empty;// better than ""*/
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Status { get; set; }
    }
}
