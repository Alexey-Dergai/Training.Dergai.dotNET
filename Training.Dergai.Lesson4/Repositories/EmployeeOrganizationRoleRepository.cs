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
        private readonly string Path = @"D:\Education\.NET\Новая папка\Training.Dergay.Lesson1.Gdc\Training.Dergai.Lesson4\FileStorage\EmployeeOrganizationRole.txt";

        public void Add(EmployeeOrganizationRole employeeOrganizationRole)
        {
            var json = JsonSerializer.Serialize(employeeOrganizationRole);

            using (var sw = new StreamWriter(Path, true))
            {
                sw.WriteLine(json);
            }
        }

        public void Remove(EmployeeOrganizationRole employeeOrganizationRole)
        {
            var employeeOrganizationRoles = GetAll();

            employeeOrganizationRoles.RemoveAll(x => x.EmployeeId == employeeOrganizationRole.EmployeeId && x.OrganizationId == employeeOrganizationRole.OrganizationId && x.RoleId == employeeOrganizationRole.RoleId);

            using (var sw = new StreamWriter(Path, false))
            {
                foreach (var eor in employeeOrganizationRoles)
                {
                    var json = JsonSerializer.Serialize(eor);

                    sw.WriteLine(json);
                }
            }
        }

        public List<EmployeeOrganizationRole> GetAll()
        {
            var employeeOrganizationRoles = new List<EmployeeOrganizationRole>();

            using (var sr = new StreamReader(Path))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    var employeeOrganizationRole = JsonSerializer.Deserialize<EmployeeOrganizationRole>(line);

                    employeeOrganizationRoles.Add(employeeOrganizationRole);
                }
            }
            return employeeOrganizationRoles;
        }

        public void Update(EmployeeOrganizationRole employeeOrganizationRole)
        {
            var employeeOrganizationRoles = GetAll();

            employeeOrganizationRoles.RemoveAll(x => x.EmployeeId == employeeOrganizationRole.EmployeeId && x.OrganizationId == employeeOrganizationRole.OrganizationId && x.RoleId == employeeOrganizationRole.RoleId);
            employeeOrganizationRoles.Add(employeeOrganizationRole);

            using (var sw = new StreamWriter(Path, false))
            {
                foreach (var eor in employeeOrganizationRoles)
                {
                    var json = JsonSerializer.Serialize(eor);

                    sw.WriteLine(json);
                }
            }
        }
    }
}
