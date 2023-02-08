using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Dergai.Lesson4.Models;

namespace Training.Dergai.Lesson4.Repositories
{
    public interface IOrganizationRepository
    {
        public Task AddAsync(Organization organization);

        public Task RemoveAsync(Organization organization);

        public Task<List<Organization>> GetAllAsync();

        public Task UpdateAsync(Organization organization);
    }
}
