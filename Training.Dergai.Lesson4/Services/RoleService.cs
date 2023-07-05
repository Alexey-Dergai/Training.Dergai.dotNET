using System.Collections.Generic;
using System.Threading.Tasks;
using Training.Dergai.Lesson4.Models;
using Training.Dergai.Lesson4.Repositories;

namespace Training.Dergai.Lesson4.Services
{
    public class RoleService : IRoleService
    {
        public RoleService(IRoleRepository roleRepository)
        {
            RoleRepository = roleRepository;
        }

        private IRoleRepository RoleRepository { get; }

        public async Task CreateRoleAsync(Role role)
        {
            await RoleRepository.AddAsync(role);
        }

        public async Task<List<Role>> GetAllRoles()
        {
            return await RoleRepository.GetAllAsync();
        }

        public async Task RemoveRoleAsync(Role role)
        {
            await RoleRepository.RemoveAsync(role);
        }
    }
}
