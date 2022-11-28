using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Dergai.Lesson4.Models;

namespace Training.Dergai.Lesson4.Repositories
{
    public interface IRoleRepository
    {
        public void Add(Role role);

        public void Remove(Role role);

        public List<Role> GetAll();
    }
}
