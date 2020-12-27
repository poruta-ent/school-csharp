using Microsoft.VisualStudio.TestTools.UnitTesting;
using Commmon;

namespace CommmonTest
{
    [TestClass]
    public class StringHandlerTest
    {
        [TestMethod]
        public void InsertSpacesTestValid()
        {
            //Arrange
            var source = "StringHandlerTest";
            var expected = "String Handler Test";

            //Act
            var actual = source.InsertSpaces();
        
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void InsertSpacesTestWithExistingSpace()
        {
            //Arrange
            var source = "String Handler Test";
            var expected = "String Handler Test";

            //Act
            var actual = source.InsertSpaces();
        
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
