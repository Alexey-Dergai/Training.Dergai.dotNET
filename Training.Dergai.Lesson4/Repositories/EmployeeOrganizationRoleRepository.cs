using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using Training.Dergai.Lesson4.Models;


namespace Training.Dergai.Lesson4.Repositories
{
    public class EmployeeOrganizationRoleRepository : IEmployeeOrganizationRoleRepository
    {
        private readonly string Path = Directory.GetCurrentDirectory() + @"\EmployeeOrganizationRole.txt";

        public async Task AddAsync(EmployeeOrganizationRole employeeOrganizationRole)
        {
            var json = JsonSerializer.Serialize(employeeOrganizationRole);

            using (var sw = new StreamWriter(Path, true))
            {
                await sw.WriteLineAsync(json);
            }
        }

        public async Task RemoveAsync(EmployeeOrganizationRole employeeOrganizationRole)
        {
            var employeeOrganizationRoles = await GetAllAsync();

            employeeOrganizationRoles.RemoveAll(x => x.EmployeeId == employeeOrganizationRole.EmployeeId && x.OrganizationId == employeeOrganizationRole.OrganizationId && x.RoleId == employeeOrganizationRole.RoleId);

            using (var sw = new StreamWriter(Path, false))
            {
                foreach (var eor in employeeOrganizationRoles)
                {
                    var json = JsonSerializer.Serialize(eor);

                    await sw.WriteLineAsync(json);
                }
            }
        }

        public async Task<List<EmployeeOrganizationRole>> GetAllAsync()
        {
            var employeeOrganizationRoles = new List<EmployeeOrganizationRole>();

            using (var sr = new StreamReader(Path))
            {
                string line;

                while ((line = await sr.ReadLineAsync()) != null)
                {
                    var employeeOrganizationRole = JsonSerializer.Deserialize<EmployeeOrganizationRole>(line);

                    employeeOrganizationRoles.Add(employeeOrganizationRole);
                }
            }

            return employeeOrganizationRoles;
        }

        public async Task UpdateAsync(EmployeeOrganizationRole employeeOrganizationRole)
        {
            var employeeOrganizationRoles = await GetAllAsync();

            employeeOrganizationRoles.RemoveAll(x => x.EmployeeId == employeeOrganizationRole.EmployeeId && x.OrganizationId == employeeOrganizationRole.OrganizationId && x.RoleId == employeeOrganizationRole.RoleId);
            employeeOrganizationRoles.Add(employeeOrganizationRole);

            using (var sw = new StreamWriter(Path, false))
            {
                foreach (var eor in employeeOrganizationRoles)
                {
                    var json = JsonSerializer.Serialize(eor);

                    await sw.WriteLineAsync(json);
                }
            }
        }
    }
}
