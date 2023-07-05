using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Training.Dergai.Lesson4.Models;

namespace Training.Dergai.Lesson4
{
    public class Employee
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public int Age { get; set; }

        public ICollection<EmployeeOrganizationRole> EmployeeOrganizationRoles { get; set; }
    }
}   
