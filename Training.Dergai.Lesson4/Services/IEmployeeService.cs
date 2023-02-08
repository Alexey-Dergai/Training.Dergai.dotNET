using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Dergai.Lesson4.Services
{
    public interface IEmployeeService
    {
        Task CreateEmployeeAsync(Employee employee);

        Task UpdateEmployeeAsync(Employee employee);

        Task RemoveEmployeeAsync(Employee employee);

        Task<List<Employee>> GetAllEmployeesAsync();
    }
}
