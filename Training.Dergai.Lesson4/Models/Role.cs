using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Dergai.Lesson4.Models
{
    public class Role
    {
        public Role()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        
        public string Name { get; set; }
    }
    
}
