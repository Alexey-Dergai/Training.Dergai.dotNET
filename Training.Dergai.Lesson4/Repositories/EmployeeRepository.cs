using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Training.Dergai.Lesson4.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext;
        }

        private ApplicationDbContext ApplicationDbContext { get; }

        public async Task AddAsync(Employee employee)
        {
            await ApplicationDbContext.Employees.AddAsync(employee);  
            await ApplicationDbContext.SaveChangesAsync();  
        }

        public async Task RemoveAsync(Employee employee)
        {
            ApplicationDbContext.Employees.Remove(employee);
            await ApplicationDbContext.SaveChangesAsync();  
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await ApplicationDbContext.Employees.ToListAsync();
        }

        public async Task UpdateAsync(Employee employee)
        {
            ApplicationDbContext.Employees.Update(employee);
            await ApplicationDbContext.SaveChangesAsync();  
        }
    }
}
