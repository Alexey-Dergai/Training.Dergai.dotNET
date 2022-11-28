using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace Training.Dergai.Lesson4.Repositories
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly string Path = @"D:\Education\.NET\Новая папка\Training.Dergay.Lesson1.Gdc\Training.Dergai.Lesson4\FileStorage\Organization.txt";

        public void Add(Organization organization)
        {
            var json = JsonSerializer.Serialize(organization);

            using (var sw = new StreamWriter(Path, true))
            {
                sw.WriteLine(json);
            }
        }

        public void Remove(Organization organization)
        {
            var organizations = GetAll();

            organizations.RemoveAll(x => x.Id == organization.Id);

            using (var sw = new StreamWriter(Path, false))
            {
                foreach (var org in organizations)
                {
                    var json = JsonSerializer.Serialize(org);

                    sw.WriteLine(json);
                }
            }
        }

        public List<Organization> GetAll()
        {
            var organizations = new List<Organization>();

            using (var sr = new StreamReader(Path))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    var organization = JsonSerializer.Deserialize<Organization>(line);

                    organizations.Add(organization);
                }
            }
            return organizations;
        }

        public void Update(Organization organization)
        {
            var organizations = GetAll();

            organizations.RemoveAll(x => x.Id == organization.Id);
            organizations.Add(organization);

            using (var sw = new StreamWriter(Path, false))
            {
                foreach (var org in organizations)
                {
                    var json = JsonSerializer.Serialize(org);

                    sw.WriteLine(json);
                }
            }
        }
    }
}
