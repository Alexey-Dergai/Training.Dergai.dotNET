using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Dergai.Lesson4.Models;

namespace Training.Dergai.Lesson4
{
    public class Organization
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<EmployeeOrganizationRole> EmployeeOrganizationRoles { get; set; }
    }
}
