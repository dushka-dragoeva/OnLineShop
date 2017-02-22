using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using OnLineShop.Data;
using OnLineShop.Data.Models;
using OnLineShop.Data.Services;


namespace OnLineShop.Services.Tests.SizeServiceTests
{
    [TestClass]
    public class GetById_Should
    {
        [TestMethod]
        public void ReturnNull_WhenIdParameterIsNull()
        {
            // Arrange
            var contextMock = new Mock<IOnLineShopDbContext>();
            SizeService sizeService = new SizeService(contextMock.Object);

            // Act
            Size sizeResult = sizeService.GetById(null);

            // Assert
            Assert.IsNull(sizeResult);
        }

        [TestMethod]
        public void ReturnSize_WhenIdIsValid()
        {
            // Arrange
            var contextMock = new Mock<IOnLineShopDbContext>();
            var sizeSetMock = new Mock<IDbSet<Size>>();
            contextMock.Setup(c => c.Sizes).Returns(sizeSetMock.Object);
            int sizeId = 1;
            Size size = new Size() { Id = sizeId, Value = "S" };

            sizeSetMock.Setup(b => b.Find(sizeId)).Returns(size);

            SizeService sizeService = new SizeService(contextMock.Object);

            // Act
            Size sizeResult = sizeService.GetById(sizeId);

            // Assert
            Assert.AreSame(size, sizeResult);
        }
    }
}

