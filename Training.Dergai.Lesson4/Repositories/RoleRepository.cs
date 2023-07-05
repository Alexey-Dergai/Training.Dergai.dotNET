using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Training.Dergai.Lesson4.Models;

namespace Training.Dergai.Lesson4.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        public RoleRepository(ApplicationDbContext applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext;
        }

        private ApplicationDbContext ApplicationDbContext { get; }

        public async Task AddAsync(Role role)
        {
            await ApplicationDbContext.Roles.AddAsync(role);
            await ApplicationDbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(Role role)
        {
             ApplicationDbContext.Roles.Remove(role);
             await ApplicationDbContext.SaveChangesAsync();
        }

        public async Task <List<Role>> GetAllAsync()
        {
             return await ApplicationDbContext.Roles.ToListAsync();
        }
    }
}
