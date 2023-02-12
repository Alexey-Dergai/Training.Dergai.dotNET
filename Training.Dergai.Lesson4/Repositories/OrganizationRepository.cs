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
        private readonly string Path = Directory.GetCurrentDirectory() + @"\Organization.txt";

        public async Task AddAsync(Organization organization)
        {
            using (var stream = new MemoryStream())
            {
                await JsonSerializer.SerializeAsync<Organization>(stream, organization);

                stream.Position = 0;

                using var reader = new StreamReader(stream);
                {
                    var json = await reader.ReadToEndAsync();

                    using (var sw = new StreamWriter(Path, true))
                    {
                        await sw.WriteLineAsync(json);
                    }
                }
            }
        }

        public async Task RemoveAsync(Organization organization)
        {
            var organizations = await GetAllAsync();

            organizations.RemoveAll(x => x.Id == organization.Id);

            using (var sw = new StreamWriter(Path, false))
            {
                foreach (var org in organizations)
                {
                    var json = JsonSerializer.Serialize(org);

                    await sw.WriteLineAsync(json);
                }
            }
        }

        public async Task<List<Organization>> GetAllAsync()
        {
            var organizations = new List<Organization>();

            using (var sr = new StreamReader(Path))
            {
                string line;

                while ((line = await sr.ReadLineAsync()) != null)
                {
                    var organization = JsonSerializer.Deserialize<Organization>(line);

                    organizations.Add(organization);
                }
            }
            return organizations;
        }

        public async Task UpdateAsync(Organization organization)
        {
            var organizations = await GetAllAsync();

            organizations.RemoveAll(x => x.Id == organization.Id);
            organizations.Add(organization);

            using (var sw = new StreamWriter(Path, false))
            {
                foreach (var org in organizations)
                {
                    var json = JsonSerializer.Serialize(org);

                    await sw.WriteLineAsync(json);
                }
            }
        }
    }
}
