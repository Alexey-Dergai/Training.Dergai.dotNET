using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Dergai.Lesson4.Models
{
    public class EmployeeOrganizationRole
    {
        public Guid EmployeeId { get; set; }

        public Guid OrganizationId { get; set; }

        public Guid RoleId { get; set; }
    }
}
