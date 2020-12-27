using Microsoft.VisualStudio.TestTools.UnitTesting;
using Commmon;
using System.Collections.Generic;

namespace CommmonTest
{
    [TestClass]
    public class LoggingServiceTest
    {
        [TestMethod]
        public void WriteToFileTest()
        {
            //Arrange
            var items = new List<ILoggable>();
            var customer = new Customer(1)
            {
                EmailAddress = "a@b.com",
                FirstName = "Ab",
                LastName = "Bc",
                AddressList = null
            };
            items.Add(customer);

            var product = new Product(2)
            {
                ProductName = "xXx",
                ProductDescritption = "vno dafda tjjfs",
                PrductPrice = 10.9M
            };
            items.Add(product);

            //Act
            LoggingService.WriteToFile(items);

            //Assert
            //check file
        }
    }
}
