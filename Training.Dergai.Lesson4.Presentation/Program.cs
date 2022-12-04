using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json;
using Training.Dergai.Lesson4.Models;
using Training.Dergai.Lesson4.Repositories;
using Training.Dergai.Lesson4.Services;

namespace Training.Dergai.Lesson4.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IRoleRepository, RoleRepository>()
                .AddSingleton<IEmployeeRepository, EmployeeRepository>()
                .AddSingleton<IOrganizationRepository, OrganizationRepository>()
                .AddSingleton<IEmployeeOrganizationRoleRepository, EmployeeOrganizationRoleRepository>()
                .AddSingleton<IRoleService, RoleService>()
                .AddSingleton<IEmployeeService, EmployeeService>()
                .AddSingleton<IOrganizationService, OrganizationService>()
                .BuildServiceProvider();

            var roleService = serviceProvider.GetService<IRoleService>();
            var role = new Role { Name = "Developer" };
            var manager = new Role { Name = "Manager" };

            roleService.CreateRole(role);

            role.Name = "QA";

            var organization = new Organization { Name = "Ivan Quattro" };
            var honda = new Organization { Name = "Honda Vtec" };
            var organizationService = serviceProvider.GetService<IOrganizationService>();

            organizationService.CreateOrganization(organization);
            organizationService.CreateOrganization(honda);

            var employee = new Employee { Name = "Korben Javas", Age = 21 };
            var jove = new Employee { Name = "Jove", Age = 222 };
            var employeeService = serviceProvider.GetService<IEmployeeService>();

            employeeService.CreateEmployee(employee);
            employeeService.CreateEmployee(jove);

            var employees = employeeService.GetAllEmployees();

            Console.WriteLine(JsonSerializer.Serialize(employees));

            jove.Age = 20;

            employeeService.UpdateEmployee(jove);

            organizationService.AddEmployeeToOrganization(honda.Id, jove.Id, role.Id);
            organizationService.AddEmployeeToOrganization(honda.Id, employee.Id, role.Id);
            organizationService.AssignNewRole(honda.Id, jove.Id, manager.Id);

            var employeesForHonda = organizationService.GetEmployeesForOrganization(honda.Id);

            Console.WriteLine(JsonSerializer.Serialize(employeesForHonda));

            organizationService.RemoveEmployeeFromOrganization(honda.Id, jove.Id);

            Console.ReadKey();
        }
    }
}
