using System;

namespace Training.Dergai.Lesson3
{
    class Program
    {
        static void Main(string[] args)
        {
            UserInfo();
        }
        private static void UserInfo()
        {
            User print = new User();
            print.PrintInfo(new SalaryInfoPrinter());
        }
    }
}
