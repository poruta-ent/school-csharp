using System;
using NUnit.Framework;

namespace TDD_intro_Spock
{
    public class FizzBuzz
    {
        [SetUp]
        public void FizzBuzzSetup()
        {
        }

        [Test]
        [TestCase("Fizz", 3)]
        [TestCase("Buzz", 5)]
        [TestCase("FizzBuzz", 90)]
        [TestCase("", 31)]
        public void TestFizzBuzz(string expected, int number)
        {
            Assert.AreEqual(expected, GetFizzBuzz(number));
        }

        private string GetFizzBuzz(int number)
        {
            if (number % 3 == 0 && number % 5 == 0) return "FizzBuzz";
            if (number % 3 == 0) return "Fizz";
            if (number % 5 == 0) return "Buzz";
            return "";
        }
    }
}