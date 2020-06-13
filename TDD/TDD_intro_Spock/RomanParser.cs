
using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace TDD_intro_Spock
{
    [TestFixture]
    public class TestRomanParser
    {
        [Test]
        [TestCase(1,"I")]
        [TestCase(3,"III")]
        [TestCase(400,"CD")]
        [TestCase(499,"ID")]
        [TestCase(9,"IX")]
        [TestCase(8,"VIII")]
        public void Parse(int expected, string roman)
        {
            Assert.AreEqual(expected, Roman.Parse(roman));
        }
    }

    internal class Roman
    {
        public static Dictionary<char, int> map = 
            new Dictionary<char, int> {
                {'I', 1},
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},
                {'M', 1000}
            }; 
        
        public static int Parse(string roman)
        {
            int result = 0;
            
            for (int i = 0; i < roman.Length; i++)
            {
                if (i + 1 < roman.Length && map[roman[i]] < map[roman[i+1]])
                {
                    result -= map[roman[i]];
                }
                else
                {
                    result += map[roman[i]];
                }
            }
            
            return result;
        }
    }
}