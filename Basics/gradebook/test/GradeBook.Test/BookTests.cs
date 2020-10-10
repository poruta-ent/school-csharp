using System;
using Xunit;

namespace GradeBook.Test
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
            var book = new InMemoryBook("");
            book.AddGrade(89.1);
            book.AddGrade(77.4);
            book.AddGrade(91.3);

            var stats = book.GetStats();
        
            Assert.Equal(85.9,stats.Average,1);
            Assert.Equal(91.3,stats.High,1);
            Assert.Equal(77.4,stats.Low,1);
            Assert.Equal('B', stats.LetterGrade);

        }
    }
}
