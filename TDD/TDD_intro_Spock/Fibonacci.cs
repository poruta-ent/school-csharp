using NUnit.Framework;

namespace TDD_intro_Spock
{
    [TestFixture]
    public class Fibonacci
    {
        [SetUp]
        public void FibonacciSetup()
        {
        }

        [Test]
        [TestCase(0,0)]
        [TestCase(1,1)]
        [TestCase(3,2)]
        [TestCase(30, 832040)]
        public void TestFibonacci(int index, int expected)
        {
            Assert.AreEqual(expected,GetFibonacci(index));
        }

        public int GetFibonacci(int index)
        {
            if (index ==0) return 0;
            if (index ==1) return 1;
            return GetFibonacci(index-2) + GetFibonacci(index-1);
        }

    }
}