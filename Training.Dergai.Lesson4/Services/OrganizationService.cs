using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.Dergai.Lesson4.Models;
using Training.Dergai.Lesson4.Repositories;

namespace Training.Dergai.Lesson4.Services
{
    public class OrganizationService : IOrganizationService
    {
        public OrganizationService(
            IOrganizationRepository organizationRepository,
            IEmployeeRepository employeeRepository,
            IEmployeeOrganizationRoleRepository employeeOrganizationRoleRepository)
        {
            OrganizationRepository = organizationRepository;
            EmployeeRepository = employeeRepository;
            EmployeeOrganizationRoleRepository = employeeOrganizationRoleRepository;
        }

        private IOrganizationRepository OrganizationRepository { get; }

        private IEmployeeRepository EmployeeRepository { get; }

        private IEmployeeOrganizationRoleRepository EmployeeOrganizationRoleRepository { get; }

        public async Task AddEmployeeToOrganizationAsync(int organizationId, int employeeId, int roleId)
        {
            var employeeOrgRole = new EmployeeOrganizationRole
            {
                EmployeeId = employeeId,
                OrganizationId = organizationId,
                RoleId = roleId
            };

            await EmployeeOrganizationRoleRepository.AddAsync(employeeOrgRole);
        }

        public async Task AssignNewRoleAsync(int organizationId, int employeeId, int roleId)
        {
            await RemoveEmployeeFromOrganizationAsync(organizationId, employeeId);
            await AddEmployeeToOrganizationAsync(organizationId, employeeId, roleId);
        }

        public async Task CreateOrganizationAsync(Organization organization)
        {
            await OrganizationRepository.AddAsync(organization);
        }

        public async Task<List<Employee>> GetEmployeesForOrganizationAsync(int organizationId)
        {
            var empOrgRoles = await EmployeeOrganizationRoleRepository.GetAllAsync();
            empOrgRoles = empOrgRoles.FindAll(e => e.OrganizationId == organizationId);

            var employees = await EmployeeRepository.GetAllAsync();
            employees = employees.FindAll(emp => empOrgRoles.Select(e => e.EmployeeId).Contains(emp.Id));

            return employees;
        }

        public async Task RemoveEmployeeFromOrganizationAsync(int organizationId, int employeeId)
        {
            var emplOrgRoles = await EmployeeOrganizationRoleRepository.GetAllAsync();
            emplOrgRoles = emplOrgRoles.FindAll(x => x.OrganizationId == organizationId && x.EmployeeId == employeeId);

            foreach (var empOrgRole in emplOrgRoles)
            {
                await EmployeeOrganizationRoleRepository.RemoveAsync(empOrgRole);
            }
        }
    }
}
