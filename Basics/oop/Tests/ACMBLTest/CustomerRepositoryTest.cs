using ACMBL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;

namespace ACMBLTest
{ 
    [TestClass]
    public class CustomerRepositoryTest
    {
        [TestMethod]
        public void RetrieveValid()
        {
            //Arrange
            var expected = new Customer(1)
            {
                FirstName = "Ab",
                LastName = "Ced",
                EmailAddress = "ab@ced.com"
            };

            //Act
            var actual = new CustomerRepository().Retrieve(1);
        
            //Assert
            Assert.AreEqual(expected.CustomerId, actual.CustomerId);
            Assert.AreEqual(expected.FirstName, actual.FirstName);
            Assert.AreEqual(expected.LastName, actual.LastName);
            Assert.AreEqual(expected.EmailAddress, actual.EmailAddress);
        }

        [TestMethod]
        public void RetrieveExistingWIthAddress()
        {
            //arrange
            var customerRepository = new CustomerRepository();
            var expected = new Customer(1)
            {
                FirstName = "Ab",
                LastName = "Ced",
                EmailAddress = "ab@ced.com",
                AddressList = new List<Address>()
                {
                    new Address(1)
                    {
                        Type = AddressType.Home,
                        StreetLine1 = "Warchałowskiego",
                        StreetLine2 = "1/72",
                        City = "Modlin",
                        StateProvince = "wieckie",
                        Country = "SanEscobar",
                        PostalCode = "09234"
                    },
                    new Address(2)
                    {
                        Type = AddressType.Delivery,
                        StreetLine1 = "Proznao",
                        StreetLine2 = "44a",
                        City = "Zabki",
                        StateProvince = "kosie",
                        Country = "SanEscobar",
                        PostalCode = "05534"
                    },
                    new Address(3)
                    {
                        Type = AddressType.Work,
                        StreetLine1 = "Wargo",
                        StreetLine2 = "231",
                        City = "Azkan",
                        StateProvince = "wieckie",
                        Country = "Escobar",
                        PostalCode = "088"
                    }
                }
            };

            //act 
            var actual = customerRepository.Retrieve(1);

            //assert
            Assert.AreEqual(expected.CustomerId, actual.CustomerId);
            Assert.AreEqual(expected.FirstName, actual.FirstName);
            Assert.AreEqual(expected.LastName, actual.LastName);
            Assert.AreEqual(expected.FullName, actual.FullName);
            Assert.AreEqual(expected.EmailAddress, actual.EmailAddress);

            for (int i=0; i<expected.AddressList.Count; i++)
            {
                Assert.AreEqual(expected.AddressList[i].AddressId, actual.AddressList[i].AddressId);
                Assert.AreEqual(expected.AddressList[i].Type, actual.AddressList[i].Type);
                Assert.AreEqual(expected.AddressList[i].StreetLine1, actual.AddressList[i].StreetLine1);
                Assert.AreEqual(expected.AddressList[i].StreetLine2, actual.AddressList[i].StreetLine2);
                Assert.AreEqual(expected.AddressList[i].StateProvince, actual.AddressList[i].StateProvince);
                Assert.AreEqual(expected.AddressList[i].City, actual.AddressList[i].City);
                Assert.AreEqual(expected.AddressList[i].Country, actual.AddressList[i].Country);
                Assert.AreEqual(expected.AddressList[i].PostalCode, actual.AddressList[i].PostalCode);
            }


        }
    }
}
