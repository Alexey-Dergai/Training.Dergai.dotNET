using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace Training.Dergai.Lesson4.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly string Path = Directory.GetCurrentDirectory() + @"\Employee.txt";

        public void Add(Employee employee)
        {
            var json = JsonSerializer.Serialize(employee);
            
            using (var sw = new StreamWriter(Path, true))
            {
                sw.WriteLine(json);
            }
        }

        public void Remove(Employee employee)
        {
            var employees = GetAll();

            employees.RemoveAll(x => x.Id == employee.Id);

            using (var sw = new StreamWriter(Path, false))
            {
                foreach(var emp in employees)
                {
                    var json = JsonSerializer.Serialize(emp);

                    sw.WriteLine(json);
                }
            }
        }

        public List<Employee> GetAll()
        {
            var employees = new List<Employee>();

            using (var sr = new StreamReader(Path))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    var employee = JsonSerializer.Deserialize<Employee>(line);
                   
                    employees.Add(employee);
                }

            }

            return employees;
        }

        public void Update(Employee employee)
        {
            var employees = GetAll();

            employees.RemoveAll(x => x.Id == employee.Id);
            employees.Add(employee);

            using (var sw = new StreamWriter(Path, false))
            {
                foreach (var emp in employees)
                {
                    var json = JsonSerializer.Serialize(emp);

                    sw.WriteLine(json);
                }
            }
        }
    }
}
