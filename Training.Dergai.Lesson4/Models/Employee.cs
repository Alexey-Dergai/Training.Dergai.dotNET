using System;
using System.Collections.Generic;

namespace Training.Dergai.Lesson4
{
    public class Employee
    {
        public Employee()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

    }
}   
