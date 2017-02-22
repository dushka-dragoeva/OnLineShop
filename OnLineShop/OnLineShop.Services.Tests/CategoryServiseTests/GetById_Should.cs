using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using OnLineShop.Data;
using OnLineShop.Data.Models;
using OnLineShop.Data.Services;


namespace OnLineShop.Services.Tests.CategoryServiseTests
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
        public void ReturnCategory_WhenIdIsValid()
        {
            // Arrange
            var contextMock = new Mock<IOnLineShopDbContext>();
            var categorySetMock = new Mock<IDbSet<Category>>();
            contextMock.Setup(c => c.Categories).Returns(categorySetMock.Object);
            int categoryId = 1;
            Category category = new Category() { Id = categoryId, Name = "Category 1" };


            categorySetMock.Setup(b => b.Find(categoryId)).Returns(category);

            CategoryService categoryService = new CategoryService(contextMock.Object);

            // Act
            Category categoryResult = categoryService.GetById(categoryId);

            // Assert
            Assert.AreSame(category, categoryResult);
        }
    }
}

