using ACMBL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACMBLTest
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void FullNameTestValid()
        {
            //Arrange
            Customer customer = new Customer
            {
                FirstName = "Gus",
                LastName = "Esposito"
            };
            string expected = "Gus Esposito"; 
            //Act
            string actual = customer.FullName;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FullNameFirstNameEmpty()
        {
            //Arrange
            Customer customer = new Customer
            {
                LastName = "Esposito"
            };
            string expected = "Esposito";
            //Act
            string actual = customer.FullName;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FullNameLastNameEmpty()
        {
            //Arrange
            Customer customer = new Customer
            {
                FirstName = "Gus"
            };
            string expected = "Gus";
            //Act
            string actual = customer.FullName;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StaticTest()
        {
            //Arrange
            Customer c1 = new Customer();
            c1.FirstName = "A";
            Customer.InstanceCount++;

            Customer c2 = new Customer();
            c2.FirstName = "B";
            Customer.InstanceCount++;

            Customer c3 = new Customer();
            c3.FirstName = "C";
            Customer.InstanceCount++;

            //Act
            //Assert
            Assert.AreEqual(3, Customer.InstanceCount);
        }

        [TestMethod]
        public void ValidateValid()
        {
            //Arrange
            var customer = new Customer
            {
                LastName = "Skuterson",
                EmailAddress = "a@b.com"
            };

            var expected = true;

            //Act
            var actual = customer.Validate();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidateMissingLastName()
        {
            //Arrange
            var customer = new Customer
            {
                EmailAddress = "a@b.com"
            };

            var expected = false;
            
            //Act
            var actual = customer.Validate();

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
