using NUnit.Framework;

namespace Training.Dergai.Lesson6.Tests
{
    class ComputeFactorialTest
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
}