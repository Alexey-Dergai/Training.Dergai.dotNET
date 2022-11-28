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
        public void Add(Employee employee);

        public void Remove(Employee employee);

        public List<Employee> GetAll();

        public void Update(Employee employee);
    }
}
