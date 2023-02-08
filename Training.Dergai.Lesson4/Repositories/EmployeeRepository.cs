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

        public async Task AddAsync(Employee employee)
        {
            var json = JsonSerializer.Serialize(employee);
            
            using (var sw = new StreamWriter(Path, true))
            {
                await sw.WriteLineAsync(json);
            }
        }

        public async Task RemoveAsync(Employee employee)
        {
            var employees = await GetAllAsync();

            employees.RemoveAll(x => x.Id == employee.Id);

            using (var sw = new StreamWriter(Path, false))
            {
                foreach(var emp in employees)
                {
                    var json = JsonSerializer.Serialize(emp);

                    await sw.WriteLineAsync(json);
                }
            }
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            var employees = new List<Employee>();

            using (var sr = new StreamReader(Path))
            {
                string line;

                while ((line = await sr.ReadLineAsync()) != null)
                {
                    var employee = JsonSerializer.Deserialize<Employee>(line);
                   
                    employees.Add(employee);
                }

            }

            return employees;
        }

        public async Task UpdateAsync(Employee employee)
        {
            var employees = await GetAllAsync();

            employees.RemoveAll(x => x.Id == employee.Id);
            employees.Add(employee);

            using (var sw = new StreamWriter(Path, false))
            {
                foreach (var emp in employees)
                {
                    var json = JsonSerializer.Serialize(emp);

                    await sw.WriteLineAsync(json);
                }
            }
        }
    }
}
