using System.Collections.Generic;
using System.Threading.Tasks;
using Training.Dergai.Lesson4.Models;

namespace Training.Dergai.Lesson4.Repositories
{
    public interface IRoleRepository
    {
        public Task AddAsync(Role role);

        public Task RemoveAsync(Role role);

        public Task <List<Role>> GetAllAsync();
    }
}
