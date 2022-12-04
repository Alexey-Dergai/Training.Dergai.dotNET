using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Dergai.Lesson4.Services
{
    public interface IOrganizationService
    {
        void CreateOrganization(Organization organization);

        List<Employee> GetEmployeesForOrganization(Guid organizationId);

        void RemoveEmployeeFromOrganization(Guid organizationId, Guid employeeId);

        void AddEmployeeToOrganization(Guid organizationId, Guid employeeId, Guid roleId);

        void AssignNewRole(Guid organizationId, Guid employeeId, Guid roleId);
    }
}
