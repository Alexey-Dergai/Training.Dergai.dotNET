using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Dergai.Lesson4.Models
{
    public class Role
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public ICollection<EmployeeOrganizationRole> EmployeeOrganizationRoles { get; set; }
    }
}
