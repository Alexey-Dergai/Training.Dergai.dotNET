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
        public void Add(Organization organization);

        public void Remove(Organization organization);

        public List<Organization> GetAll();

        public void Update(Organization organization);
    }
}
