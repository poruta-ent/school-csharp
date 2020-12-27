using ACMBL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACMBLTest
{ 
    [TestClass]
    public class ProductRepositoryTest
    {
        [TestMethod]
        public void RetrieveValid()
        {
            //Arrange
            var expected = new Product(2)
            {
                ProductName = "Chupa",
                ProductDescription = "Chups",
                CurrentPrice = 15.6M
            };

            //Act
            var actual = new ProductRepository().Retrieve(2);
        
            //Assert
            Assert.AreEqual(expected.ProductId, actual.ProductId);
            Assert.AreEqual(expected.ProductName, actual.ProductName);
            Assert.AreEqual(expected.ProductDescription, actual.ProductDescription);
            Assert.AreEqual(expected.CurrentPrice, actual.CurrentPrice);
        }

        [TestMethod]
        public void SaveValid()
        {
            //Arrange
            var productRepository = new ProductRepository();
            var updatedProduct = new Product(2)
            {
                CurrentPrice = 18M,
                ProductDescription = "fkdoa dadkfpa daffduidknf",
                ProductName = "Tyci",
                HasChanges = true
            };

            //Act
            var actual = productRepository.Save(updatedProduct);

            //Assert
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void SaveMissingPrice()
        {
            //Arrange
            var productRepository = new ProductRepository();
            var updatedProduct = new Product(2)
            {
                CurrentPrice = null,
                ProductDescription = "fkdoa dadkfpa daffduidknf",
                ProductName = "Tyci",
                HasChanges = true
            };

            //Act
            var actual = productRepository.Save(updatedProduct);

            //Assert
            Assert.AreEqual(false, actual);
        }
    }
}
