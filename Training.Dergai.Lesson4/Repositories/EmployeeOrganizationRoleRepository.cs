using System.Collections.Generic;
using System.Threading.Tasks;
using Training.Dergai.Lesson4.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Training.Dergai.Lesson4.Repositories
{
    public class EmployeeOrganizationRoleRepository : IEmployeeOrganizationRoleRepository
    {
        public EmployeeOrganizationRoleRepository(ApplicationDbContext applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext;
        }

        private ApplicationDbContext ApplicationDbContext { get; }

        public async Task AddAsync(EmployeeOrganizationRole employeeOrganizationRole)
        {
            await ApplicationDbContext.EmployeeOrganizationRoles.AddAsync(employeeOrganizationRole);
            await ApplicationDbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(EmployeeOrganizationRole employeeOrganizationRole)
        {
            ApplicationDbContext.EmployeeOrganizationRoles.Remove(employeeOrganizationRole);
            await ApplicationDbContext.SaveChangesAsync();
        }

        public async Task <List<EmployeeOrganizationRole>> GetAllAsync()
        {
            return await ApplicationDbContext.EmployeeOrganizationRoles.ToListAsync();
        }

        public async Task UpdateAsync(EmployeeOrganizationRole employeeOrganizationRole)
        {
            ApplicationDbContext.EmployeeOrganizationRoles.Update(employeeOrganizationRole);
            await ApplicationDbContext.SaveChangesAsync();
        }
    }
}
