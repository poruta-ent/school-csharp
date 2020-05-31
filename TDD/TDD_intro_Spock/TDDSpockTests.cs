using System;
using NUnit.Framework;

namespace TDD_intro_Spock
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(0,0)]
        [TestCase(1,1)]
        [TestCase(1,2)]
        [TestCase(2,3)]
        [TestCase(5,4)]
        public void TestFibonacci(int expected, int index)
        {
            Assert.AreEqual(expected, GetFibonacci(index));
        }

        private int GetFibonacci(int index)
        {
            if (index == 0) return 0;
            if (index == 1) return 1;
            return GetFibonacci(index-2) + GetFibonacci(index-1);
        }
    }
}