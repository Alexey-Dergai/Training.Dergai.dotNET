using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Dergai.Lesson4.Models;

namespace Training.Dergai.Lesson4.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private List<Role> Roles { get; set; }

        public RoleRepository()
        {
            Roles = new List<Role>();
        }

        public void Add(Role role)
        {
            Roles.Add(role);
        }

        public void Remove(Role role)
        {
            Roles.Remove(role);
        }

        public List<Role> GetAll()
        {
            return Roles;
        }
    }
}
