using System;
using static System.Math;
using System.Collections.Generic;
using static Training.Dergai.Lesson2.SortExtension;

namespace Training.Dergai.Lesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            RunCalculateRoot();
            GenericQueue();
            IEnumerableSort();
        }
        private static void RunCalculateRoot()
        {
            Console.WriteLine("ROOT CALCULATION ( Степень корня: {0}, Число под корнем: {1}) = {2}", 2, 3, RootCalculations.CalculateRoot(2, 3));
        }
        private static void GenericQueue()
        {
            GenericQueue q = new GenericQueue(4);
            q.queueDisplay();

            q.queueEnqueue(20);
            q.queueEnqueue(30);
            q.queueEnqueue(40);
            q.queueEnqueue(50);

            q.queueDisplay();

            q.queueEnqueue(60);

            q.queueDisplay();

            q.queueDequeue();
            q.queueDequeue();
            Console.Write("\nAfter two node deletion\n");

            q.queueDisplay();

            q.queueFront();
            Console.WriteLine(Environment.NewLine);

        }
        private static void IEnumerableSort()
        {
            var testCollection = new List<int> { 3, 6, 9, 1, 0, 12, -5 };

            var sortedCollection = testCollection.Sort<int>(SortDirection.Ascending);

            foreach (var item in sortedCollection)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(Environment.NewLine);
        }
        
    }
}
