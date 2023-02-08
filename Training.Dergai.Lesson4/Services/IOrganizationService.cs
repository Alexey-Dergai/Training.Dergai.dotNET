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

        Task<List<Employee>> GetEmployeesForOrganizationAsync(Guid organizationId);

        Task RemoveEmployeeFromOrganizationAsync(Guid organizationId, Guid employeeId);

        Task AddEmployeeToOrganizationAsync(Guid organizationId, Guid employeeId, Guid roleId);

        Task AssignNewRoleAsync(Guid organizationId, Guid employeeId, Guid roleId);
    }
}
