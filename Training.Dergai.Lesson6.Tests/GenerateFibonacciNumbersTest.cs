using NUnit.Framework;

namespace Training.Dergai.Lesson6.Tests
{
    public class GenerateFibonacciNumbersTest
    {
        [Test]
        public void GenerateFibonacci()
        {
            var actual = GenerateFibonacciNumber.Fibonacci(1);
            var expected = 1;
            Assert.AreEqual(actual, expected, "Fibonacci Number of 1 = 1");
        }

        [TestCase(2)]
        public void GenerateFibonacci2(int value)
        {
            var actual = GenerateFibonacciNumber.Fibonacci(value);
            var expected = 1;
            Assert.AreEqual(actual, expected, "Fibonacci Number of 2 = 1");
        }
    }
}
