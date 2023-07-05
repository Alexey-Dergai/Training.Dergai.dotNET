using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Training.Dergai.Lesson4.Repositories
{
    public class OrganizationRepository : IOrganizationRepository
    {
        public OrganizationRepository(ApplicationDbContext applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext;
        }

        private ApplicationDbContext ApplicationDbContext { get; }

        public async Task AddAsync(Organization organization)
        {
            await ApplicationDbContext.Organizations.AddAsync(organization);
            await ApplicationDbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(Organization organization)
        {
            ApplicationDbContext.Organizations.Remove(organization);    
            await ApplicationDbContext.SaveChangesAsync();
        }

        public async Task<List<Organization>> GetAllAsync()
        {
            return await ApplicationDbContext.Organizations.ToListAsync();
        }

        public async Task UpdateAsync(Organization organization)
        {
            ApplicationDbContext.Organizations.Update(organization);
            await ApplicationDbContext.SaveChangesAsync();  
        }
    }
}
