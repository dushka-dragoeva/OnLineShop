using NUnit;
using Moq;
using OnLineShop.Data.Models;
using OnLineShop.Data.Services;
using OnLineShop.MVP.Categories.Admin;
using System;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using NUnit.Framework;
using WebFormsMvp;

namespace OnLineShop.Mvp.Tests.Categories.AdminCategoriesPresenterTests
{
    [TestFixture]
    public class View_OnCategoriesEdit_Should
    {
        [Test]
        public void AddModelError_WhenItemIsNotFound()
        {
            // Arrange
            var viewMock = new Mock<ICategoriesAdminView>();
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());
            string errorKey = string.Empty;
            int categoryId = 1;
            string expectedError = String.Format("Item with id {0} was not found", categoryId);
            var categoryServiceMock = new Mock<ICategoryService>();
            categoryServiceMock.Setup(c => c.GetById(categoryId)).Returns<Category>(null);

            CategoriesAdminPresenter editCategoriesPresenter = new CategoriesAdminPresenter
                (viewMock.Object, categoryServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnCategoryEdit += null, new CategoryAdminEventArgs(categoryId, null));

            // Assert
            Assert.AreEqual(1, viewMock.Object.ModelState[errorKey].Errors.Count);
            StringAssert.AreEqualIgnoringCase(expectedError, viewMock.Object.ModelState[errorKey].Errors[0].ErrorMessage);
        }

        [Test]
        public void TryUpdateModelIsNotCalled_WhenItemIsNotFound()
        {
            // Arrange
            var viewMock = new Mock<ICategoriesAdminView>();
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());
            string errorKey = string.Empty;
            int categoryId = 1;
            var categoryServiceMock = new Mock<ICategoryService>();
            categoryServiceMock.Setup(c => c.GetById(categoryId)).Returns<Category>(null);

            CategoriesAdminPresenter editCategoriesPresenter = new CategoriesAdminPresenter
                (viewMock.Object, categoryServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnCategoryEdit += null, new CategoryAdminEventArgs(categoryId,null));

            // Assert
            viewMock.Verify(v => v.TryUpdateModel(It.IsAny<Category>()), Times.Never());
        }

        [Test]
        public void TryUpdateModelIsCalled_WhenItemIsFound()
        {
            // Arrange
            var viewMock = new Mock<ICategoriesAdminView>();
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());
            int categoryId = 1;
            var categoryServiceMock = new Mock<ICategoryService>();
            categoryServiceMock.Setup(c => c.GetById(categoryId)).Returns(new Category() { Id = categoryId });

            CategoriesAdminPresenter editCategoriesPresenter = new CategoriesAdminPresenter
                (viewMock.Object, categoryServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnCategoryEdit += null, new CategoryAdminEventArgs (categoryId,null));

            // Assert
            viewMock.Verify(v => v.TryUpdateModel(It.IsAny<Category>()), Times.Once());
        }

        [Test]
        public void UpdateCategoryIsCalled_WhenItemIsFoundAndIsInValidState()
        {
            // Arrange
            var viewMock = new Mock<ICategoriesAdminView>();
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());

            int categoryId = 1;
            var categoryServiceMock = new Mock<ICategoryService>();
            var category = new Category() { Id = categoryId };
            categoryServiceMock.Setup(c => c.GetById(categoryId)).Returns(category);

            CategoriesAdminPresenter editCategoriesPresenter = new CategoriesAdminPresenter
                (viewMock.Object, categoryServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnCategoryEdit += null, new CategoryAdminEventArgs(categoryId, null));

            // Assert
            categoryServiceMock.Verify(c => c.Update(category), Times.Once());
        }

        [Test]
        public void UpdateCategoryIsNotCalled_WhenItemIsFoundAndIsInInvalidState()
        {
            // Arrange
            var viewMock = new Mock<ICategoriesAdminView>();
            var modelState = new ModelStateDictionary();
            modelState.AddModelError("test key", "test message");
            viewMock.Setup(v => v.ModelState).Returns(modelState);

            int categoryId = 1;
            var categoryServiceMock = new Mock<ICategoryService>();
            var category = new Category() { Id = categoryId };
            categoryServiceMock.Setup(c => c.GetById(categoryId)).Returns(category);

            CategoriesAdminPresenter editCategoriesPresenter = new CategoriesAdminPresenter
                (viewMock.Object, categoryServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnCategoryEdit += null, new CategoryAdminEventArgs(categoryId,null));

            // Assert
            categoryServiceMock.Verify(c => c.Update(category), Times.Never());
        }
    }
}
