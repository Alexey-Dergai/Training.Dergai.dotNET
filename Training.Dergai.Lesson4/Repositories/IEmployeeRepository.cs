using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Dergai.Lesson4.Models;

namespace Training.Dergai.Lesson4.Repositories
{
    public interface IEmployeeRepository
    {
        public Task AddAsync(Employee employee);

        public Task RemoveAsync(Employee employee);

        public Task<List<Employee>> GetAllAsync();

        public Task UpdateAsync(Employee employee);
    }
}
