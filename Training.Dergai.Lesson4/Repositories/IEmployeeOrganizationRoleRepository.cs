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
        public Task AddAsync(EmployeeOrganizationRole employeeOrganizationRole);

        public Task RemoveAsync(EmployeeOrganizationRole employeeOrganizationRole);

        public Task<List<EmployeeOrganizationRole>> GetAllAsync();

        public Task UpdateAsync(EmployeeOrganizationRole employeeOrganizationRole);
    }
}
