using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public void CreateRole(Role role)
        {
            RoleRepository.Add(role);
        }

        public List<Role> GetAllRoles()
        {
            return RoleRepository.GetAll();
        }

        public void RemoveRole(Role role)
        {
            RoleRepository.Remove(role);
        }
    }
}
