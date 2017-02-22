using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using OnLineShop.Data.Models;
using OnLineShop.Data.Services;
using OnLineShop.MVP.Categories.Client;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnLineShop.Mvp.Tests.Categories.ClientCategoriesPresenterTests
{
    [TestClass]
    public class View_OnCategoriesGetData_Should
    {
        [TestMethod]
        public void AddCategoriesToViewModel_WhenOnCategoriesGetDataEventIsRaised()
        {
            // Arrange
            var viewMock = new Mock<ICategoriesView>();
            viewMock.Setup(v => v.Model).Returns(new CategoriesViewModel());

            var categories = GetCategoriesWithProducts();
            var categoryServiceMock = new Mock<ICategoryService>();
            categoryServiceMock.Setup(c => c.GetAllWithProducts())
                .Returns(categories);

            CategoriesPresenter categoryPresenter = new CategoriesPresenter(viewMock.Object, categoryServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnCategoriesGetData += null, EventArgs.Empty);

            // Assert
            CollectionAssert.AreEqual(categories.ToList(), viewMock.Object.Model.Categories.ToList());
        }

        private IQueryable<Category> GetCategoriesWithProducts()
        {
            return new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    Name = "Category 1",
                    Products = new List<Product>() { new Product() { Id =1 } }
                },
                new Category()
                {
                    Id = 2,
                    Name = "Category 2"
                }
            }.AsQueryable();
        }
    }
}
