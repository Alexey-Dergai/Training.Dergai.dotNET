using NUnit.Framework;
using System;

namespace RootCalculation
{
    public class CalculateRootTests
    {
        [Test]
        public void _2roots_of_3equals_1_732()
        {
            var actual = Training.Dergai.Lesson2.RootCalculations.CalculateRoot(2, 3);
            var expected = 1.7320508075688772;
            Assert.AreEqual(expected, actual, "2 roots of 3 equals = 1.732....");
        }

        [Test]
        public void _2roots_of_negative_number()
        {
            var inputValue1 = 2;
            var inputValue2 = -9;
            Assert.Throws<ArgumentException>(() => Training.Dergai.Lesson2.RootCalculations.CalculateRoot(inputValue1, inputValue2));
        }

        [TestCase(2, 225)]
        public void Test1(int value, int value1)
        {
            var actual = Training.Dergai.Lesson2.RootCalculations.CalculateRoot(value, value1);
            var expected = 15;
            Assert.AreEqual(actual, expected);
        }
    }
}