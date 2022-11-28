using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Dergai.Lesson4.Models;

namespace Training.Dergai.Lesson4.Repositories
{
    public interface IEmployeeOrganizationRoleRepository
    {
        public void Add(EmployeeOrganizationRole employeeOrganizationRole);

        public void Remove(EmployeeOrganizationRole employeeOrganizationRole);

        public List<EmployeeOrganizationRole> GetAll();

        public void Update(EmployeeOrganizationRole employeeOrganizationRole);
    }
}
