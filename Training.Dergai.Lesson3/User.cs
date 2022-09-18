using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Dergai.Lesson3
{
    class User
    {
        public string name = "James";
        public string telephoneNumber = "+1 (234) 567-8910";
        public int salary = 1000;
        public void PrintInfo(IPrintable printable)
        {
            printable.Print(this);
        }
    }
    interface IPrintable
    {
        public void Print(User person);

    }
    class NameInfoPrinter : IPrintable
    {
        public void Print(User person) => Console.WriteLine("Name: " + person.name);
    }
    class TelephoneInfoPrinter : IPrintable
    {
        public void Print(User person) => Console.WriteLine("Telephone Number: " + person.telephoneNumber);
    }
    class SalaryInfoPrinter : IPrintable
    {
        public void Print(User person) => Console.WriteLine("Salary: " + person.salary);
    }
    class FullInfoPrinter : IPrintable
    {
        public void Print(User person)
        {
            Console.WriteLine(person.name);
            Console.WriteLine(person.salary);
            Console.WriteLine(person.telephoneNumber);
        }
    }
}
