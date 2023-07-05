﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Dergai.Lesson4.Models
{
    public class EmployeeOrganizationRole
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public int OrganizationId { get; set; }

        public int RoleId { get; set; }

        public Employee Employee { get; set; } 

        public Organization Organization { get; set; } 

        public Role Role { get; set; } 
        
        
    }
}
