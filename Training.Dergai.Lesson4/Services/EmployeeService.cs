using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Dergai.Lesson4.Repositories;

namespace Training.Dergai.Lesson4.Services
{
    public class EmployeeService : IEmployeeService
    {
        public EmployeeService(IEmployeeRepository employeeRepository, IEmployeeOrganizationRoleRepository employeeOrganizationRoleRepository)
        {
            EmployeeRepository = employeeRepository;
            EmployeeOrganizationRoleRepository = employeeOrganizationRoleRepository;
        }

        private IEmployeeRepository EmployeeRepository { get; }

        private IEmployeeOrganizationRoleRepository EmployeeOrganizationRoleRepository { get; }

        public void CreateEmployee(Employee employee)
        {
            EmployeeRepository.Add(employee);
        }

        public List<Employee> GetAllEmployees()
        {
            return EmployeeRepository.GetAll();
        }

        public void RemoveEmployee(Employee employee)
        {
            EmployeeRepository.Remove(employee);

            var records = EmployeeOrganizationRoleRepository.GetAll();
            var recordsForEmployee = records.FindAll(x => x.EmployeeId == employee.Id);

            foreach (var rfe in recordsForEmployee)
            {
                EmployeeOrganizationRoleRepository.Remove(rfe);
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            EmployeeRepository.Update(employee);
        }
    }
}
