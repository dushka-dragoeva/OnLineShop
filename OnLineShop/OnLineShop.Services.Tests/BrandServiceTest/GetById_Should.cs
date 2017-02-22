using Moq;
using NUnit.Framework;
using OnLineShop.Data;
using OnLineShop.Data.Models;
using OnLineShop.Data.Services;
using System.Data.Entity;

namespace OnLineShop.Services.Tests.BrandServiceTest
{

    [TestFixture]
    public class GetById_Should
    {
        [Test]
        public void ReturnNull_WhenIdParameterIsNull()
        {
            // Arrange

            var contextMock = new Mock<IOnLineShopDbContext>();
            BrandService brandService = new BrandService(contextMock.Object);

            // Act
            Brand brandResult = brandService.GetById(null);

            // Assert
            Assert.IsNull(brandResult);
        }

        [Test]
        public void ReturnCategory_WhenIdIsValid()
        {
            // Arrange
            var contextMock = new Mock<IOnLineShopDbContext>();
            var brandSetMock = new Mock<IDbSet<Brand>>();
            contextMock.Setup(c => c.Brands).Returns(brandSetMock.Object);
            int brandId = 1;
            Brand brand = new Brand() { Id = brandId, Name = "Brand 1" };


            brandSetMock.Setup(b => b.Find(brandId)).Returns(brand);

            BrandService brandService = new BrandService(contextMock.Object);

            // Act
            Brand brandResult = brandService.GetById(brandId);

            // Assert
            Assert.AreSame(brand, brandResult);
        }
    }
}

