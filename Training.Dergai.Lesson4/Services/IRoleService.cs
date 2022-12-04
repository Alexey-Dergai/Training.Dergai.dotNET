using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Dergai.Lesson4.Models;

namespace Training.Dergai.Lesson4.Services
{
    public interface IRoleService
    {
        void CreateRole(Role role);

        void RemoveRole(Role role);

        List<Role> GetAllRoles();
    }
}
