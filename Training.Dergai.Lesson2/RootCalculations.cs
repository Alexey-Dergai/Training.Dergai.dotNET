using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Training.Dergai.Lesson2
{
    public static class RootCalculations
    {
        public static double CalculateRoot(double x, int N)
        {
            x = 1;
            double eps = 1e-15;

            for (; ; )
            {
                double nx = (x + N / x) / 2;
                if (Math.Abs(x - nx) < eps) break;
                x = nx;
            }
            return x;
        }
    }
}
