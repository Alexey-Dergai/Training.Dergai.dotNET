using System.Collections.Generic;
using System.Threading.Tasks;
using Training.Dergai.Lesson4.Models;

namespace Training.Dergai.Lesson4.Services
{
    public interface IRoleService
    {
        Task CreateRoleAsync(Role role);

        Task RemoveRoleAsync(Role role);

        Task<List<Role>> GetAllRoles();
    }
}
