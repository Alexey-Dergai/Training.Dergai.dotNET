using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Dergai.Lesson4.Services
{
    public interface IEmployeeService
    {
        void CreateEmployee(Employee employee);

        void UpdateEmployee(Employee employee);

        void RemoveEmployee(Employee employee);

        List<Employee> GetAllEmployees();
    }
}
