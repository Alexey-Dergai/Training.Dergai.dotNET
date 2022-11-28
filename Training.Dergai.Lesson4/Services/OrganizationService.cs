using System;
using System.Collections.Generic;
using System.Linq;
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

        public void AddEmployeeToOrganization(Guid organizationId, Guid employeeId, Guid roleId)
        {
            var employeeOrgRole = new EmployeeOrganizationRole
            {
                EmployeeId = employeeId,
                OrganizationId = organizationId,
                RoleId = roleId
            };

            EmployeeOrganizationRoleRepository.Add(employeeOrgRole);
        }

        public void AssignNewRole(Guid organizationId, Guid employeeId, Guid roleId)
        {
            RemoveEmployeeFromOrganization(organizationId, employeeId);
            AddEmployeeToOrganization(organizationId, employeeId, roleId);
        }

        public void CreateOrganization(Organization organization)
        {
            OrganizationRepository.Add(organization);
        }

        public List<Employee> GetEmployeesForOrganization(Guid organizationId)
        {
            var empOrgRoles = EmployeeOrganizationRoleRepository
                .GetAll()
                .FindAll(e => e.OrganizationId == organizationId);
            var employees = EmployeeRepository
                .GetAll()
                .FindAll(emp => empOrgRoles.Select(e => e.EmployeeId).Contains(emp.Id));

            return employees;
        }

        public void RemoveEmployeeFromOrganization(Guid organizationId, Guid employeeId)
        {
            var emplOrgRoles = EmployeeOrganizationRoleRepository.GetAll().FindAll(x => x.OrganizationId == organizationId && x.EmployeeId == employeeId);

            foreach (var empOrgRole in emplOrgRoles)
            {
                EmployeeOrganizationRoleRepository.Remove(empOrgRole);
            }
        }
    }
}
