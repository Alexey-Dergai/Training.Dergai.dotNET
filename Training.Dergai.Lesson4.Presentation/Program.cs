using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using Training.Dergai.Lesson4.Models;
using Training.Dergai.Lesson4.Repositories;
using Training.Dergai.Lesson4.Services;

namespace Training.Dergai.Lesson4.Presentation
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var serviceProvider = ConfigureServices();
            var roleService = serviceProvider.GetService<IRoleService>();

            var role = new Role { Name = "Developer" };
            var manager = new Role { Name = "Manager" };

            await roleService.CreateRoleAsync(role);
            await roleService.CreateRoleAsync(manager);

            role.Name = "QA";

            var organization = new Organization { Name = "Ivan Quattro" };
            var honda = new Organization { Name = "Honda Vtec" };
            var organizationService = serviceProvider.GetService<IOrganizationService>();

            await organizationService.CreateOrganizationAsync(organization);
            await organizationService.CreateOrganizationAsync(honda);

            var employee = new Employee { Name = "Korben Javas", Age = 21 };
            var jove = new Employee { Name = "Jove", Age = 222 };
            var employeeService = serviceProvider.GetService<IEmployeeService>();

            await employeeService.CreateEmployeeAsync(employee);
            await employeeService.CreateEmployeeAsync(jove);

            var employees = await employeeService.GetAllEmployeesAsync();

            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.Name}:{emp.Age}");
            }

            jove.Age = 20;

            await employeeService.UpdateEmployeeAsync(jove);

            await organizationService.AddEmployeeToOrganizationAsync(honda.Id, jove.Id, role.Id);
            await organizationService.AddEmployeeToOrganizationAsync(honda.Id, employee.Id, role.Id);
            await organizationService.AssignNewRoleAsync(honda.Id, jove.Id, manager.Id);

            var employeesForHonda = await organizationService.GetEmployeesForOrganizationAsync(honda.Id);

            foreach (var emp in employeesForHonda)
            {
                Console.WriteLine($"{emp.Name}:{emp.Age}");
            }

            await organizationService.RemoveEmployeeFromOrganizationAsync(honda.Id, jove.Id);

            Console.ReadKey();
        }

        private static ServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IOrganizationRepository, OrganizationRepository>();
            services.AddScoped<IEmployeeOrganizationRoleRepository, EmployeeOrganizationRoleRepository>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IOrganizationService, OrganizationService>();

            services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(@"Server=.\;Database=OrganizationsManagementSystem;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;"));
            return services.BuildServiceProvider();
        }
    }
}
