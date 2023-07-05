using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Dergai.Lesson4.Services
{
    public interface IOrganizationService
    {
        Task CreateOrganizationAsync(Organization organization);

        Task<List<Employee>> GetEmployeesForOrganizationAsync(int organizationId);

        Task RemoveEmployeeFromOrganizationAsync(int organizationId, int employeeId);

        Task AddEmployeeToOrganizationAsync(int organizationId, int employeeId, int roleId);

        Task AssignNewRoleAsync(int organizationId, int employeeId, int roleId);
    }
}
