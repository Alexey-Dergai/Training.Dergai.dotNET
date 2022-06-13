using System;
using Training.Dergay.Lesson1.Models;

namespace Training.Dergay.Lesson1.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {

            RunTask();
            Enter();
            RunNOD();
            RunSteinNOD();
            Enter();
            MergeSortt();
            Console.ReadKey();
        }

        private static void RunTask()
        {
            Console.WriteLine("Task 1 (GDC): ");
            Console.WriteLine("GDC ({0}, {1}) = {2}", 5, 15, Gdc.Calculate(5, 15));
            Console.WriteLine("GDC ({0}, {1}) = {2}", 0, 7, Gdc.Calculate(0, 7));
            Console.WriteLine("GDC ({0}, {1}) = {2}", 9, 0, Gdc.Calculate(9, 0));
        }

        private static void RunNOD()
        {
            Console.WriteLine("NOD ({0},{1}) = {2}", 3, 9, EuclidsAlgorithm.CalculateNOD(3, 9));
        }

        private static void RunSteinNOD()
        {
            Console.WriteLine("SteinNOD({0},{1}) = {2}", 11, 121, SteinAlgorithm.SteinNOD(11, 121));
        }

        private static void Enter()
        {
            Console.WriteLine("\n\n ");
        }

        private static void MergeSortt()
        { 
            IComparable[] arr = new IComparable[100];
            Random rd = new Random();
            for (int i = 0; i < arr.Length; ++i)
                arr[i] = rd.Next(1, 101);
            Console.WriteLine("Массив перед сортировкой:");
            foreach (int x in arr)
                Console.Write(x + " ");
            arr = MergSort.MergeSort(arr);
            Console.WriteLine("\n\nМассив после сортировки:");
            foreach (int x in arr)
                Console.Write(x + " ");
        }
    }
}
    

