using System;
using static System.Math;

namespace Training.Dergai.Lesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            RunCalculateRoot();
        }
        private static void RunCalculateRoot()
        {
            Console.WriteLine("ROOT CALCULATION ( Степень корня: {0}, Число под корнем: {1}) = {2}", 2, 3, RootCalculations.CalculateRoot(2, 3));
        }
    }
}
