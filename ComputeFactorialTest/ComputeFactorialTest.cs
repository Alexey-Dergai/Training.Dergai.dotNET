using NUnit.Framework;
using System;
using Training.Dergai.Lesson6;

namespace Training.Dergai.Lesson6.Test
{
    public class ComputeFactorialTest
    {
        [Test]
        public void factorial_of_7_equals_5040()
        {
            var actual = ComputeFactorial.Factorial(7);
            var expected = 5040;

            Assert.AreEqual(actual, expected, "factorial of 7 = 5040");
        }

        [TestCase((uint)5)]
        public void factorial_of_number(uint value)
        {
            var actual = ComputeFactorial.Factorial(value);
            var expected = 120;

            Assert.AreEqual(actual, expected, "factorial of 5 = 120");
        }
    }

    public class GenerateFibonacciNumbersTest
    {
        [Test]
        public void GenerateFibonacci()
        {
            var actual = GenerateFibonacciNumber.Fibonacci(1);
            var expected = 1;
            Assert.AreEqual(actual, expected, "");
        }

        [TestCase(2)]
        public void GenerateFibonacci2(int value)
        {
            var actual = GenerateFibonacciNumber.Fibonacci(value);
            var expected = 1;
            Assert.AreEqual(actual, expected, "");
        }
    }
}