using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using OnLineShop.Data;
using OnLineShop.Data.Models;
using OnLineShop.Data.Services;


namespace OnLineShop.Services.Tests.ProductServiceTest
{
    [TestClass]
    public class GetById_Should
    {
        [TestMethod]
        public void ReturnNull_WhenIdParameterIsNull()
        {
            // Arrange
            var contextMock = new Mock<IOnLineShopDbContext>();
            CategoryService categoryService = new CategoryService(contextMock.Object);

            // Act
            Category categoryResult = categoryService.GetById(null);

            // Assert
            Assert.IsNull(categoryResult);
        }

        [TestMethod]
        public void ReturnProduct_WhenIdIsValid()
        {
            // Arrange
            var contextMock = new Mock<IOnLineShopDbContext>();
            var productSetMock = new Mock<IDbSet<Product>>();
            contextMock.Setup(c => c.Products).Returns(productSetMock.Object);
            int productId = 1;
            Product product = new Product() { Id = productId, Name = "Product 1", ModelNumber="1A", Quantity=1, Price = 33.50m};

            productSetMock.Setup(b => b.Find(productId)).Returns(product);

            ProductService productService = new ProductService(contextMock.Object);

            // Act
            Product productResult = productService.GetById(productId);

            // Assert
            Assert.AreSame(product, productResult);
        }
    }
}
