﻿using System;

namespace Training.Dergai.Lesson6.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            ComputeFactorial1();
            GenerateFibonacci();
            ArrayList();
            GenericSet();
        }
        private static void ComputeFactorial1()
        {
            Console.WriteLine("Factorial {0} = {1}", 4, ComputeFactorial.Factorial(0));
        }
        private static void GenerateFibonacci()
        {
            Console.WriteLine(" =  Fibonacci of {0} numbers", 7, GenerateFibonacciNumber.Fibonacci(7));
        }
        private static void ArrayList()
        {
            GenericList<int> List = new GenericList<int>();

            List.Add(1);
            List.Add(3);
            List.Add(2);
            List.Add(5);
            List.Remove(2);

        }
        private static void GenericSet()
        {
            var set1 = new GenericSet<int>()
            {
                1, 2, 3, 4, 5, 6
            };

            var set2 = new GenericSet<int>()
            {
                4, 5, 6, 7, 8, 9
            };

            var set3 = new GenericSet<int>()
            {
                2, 3, 4
            };

            var union = GenericSet<int>.Union(set1, set2);
            var difference = GenericSet<int>.Difference(set1, set2);
            var intersection = GenericSet<int>.Intersection(set1, set2);
            var subset1 = GenericSet<int>.Subset(set3, set1);
            var subset2 = GenericSet<int>.Subset(set3, set2);
        }
    }
}
