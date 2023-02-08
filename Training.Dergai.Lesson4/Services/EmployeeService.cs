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

        public async Task CreateEmployeeAsync(Employee employee)
        {
            await EmployeeRepository.AddAsync(employee);
        }

        public Task<List<Employee>> GetAllEmployeesAsync()
        {
            return EmployeeRepository.GetAllAsync();
        }

        public async Task RemoveEmployeeAsync(Employee employee)
        {
            await EmployeeRepository.RemoveAsync(employee);

            var records = await EmployeeOrganizationRoleRepository.GetAllAsync();
            var recordsForEmployee = records.FindAll(x => x.EmployeeId == employee.Id);

            foreach (var rfe in recordsForEmployee)
            {
                await EmployeeOrganizationRoleRepository.RemoveAsync(rfe);
            }
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            await EmployeeRepository.UpdateAsync(employee);
        }
    }
}
