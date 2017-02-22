﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnLineShop.Data.Models;
using OnLineShop.Data.Services;
using OnLineShop.MVP.Categories.Admin;
using System;
using System.Linq;
using System.Web.ModelBinding;

namespace OnLineShop.Mvp.Tests.Categories.AdminCategoriesPresenterTests
{
    [TestClass]
    public class View_OnCategoriesEdit_Should
    {
        [TestMethod]
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
            viewMock.Raise(v => v.OnCategoryEdit += null, new CategoryAdminEventArgs (categoryId,null));

            // Assert
            Assert.AreEqual(1, viewMock.Object.ModelState[errorKey].Errors.Count);
            StringAssert.AreEqualIgnoringCase(expectedError, viewMock.Object.ModelState[errorKey].Errors[0].ErrorMessage);
        }

        //[TestMethod]
        //public void TryUpdateModelIsNotCalled_WhenItemIsNotFound()
        //{
        //    // Arrange
        //    var viewMock = new Mock<IEditCategoriesView>();
        //    viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());
        //    string errorKey = string.Empty;
        //    Guid categoryId = Guid.NewGuid();
        //    var categoryServiceMock = new Mock<ICategoryService>();
        //    categoryServiceMock.Setup(c => c.GetById(categoryId)).Returns<Category>(null);

        //    EditCategoriesPresenter editCategoriesPresenter = new EditCategoriesPresenter
        //        (viewMock.Object, categoryServiceMock.Object);

        //    // Act
        //    viewMock.Raise(v => v.OnUpdateItem += null, new IdEventArgs(categoryId));

        //    // Assert
        //    viewMock.Verify(v => v.TryUpdateModel(It.IsAny<Category>()), Times.Never());
        //}

        //[TestMethod]
        //public void TryUpdateModelIsCalled_WhenItemIsFound()
        //{
        //    // Arrange
        //    var viewMock = new Mock<IEditCategoriesView>();
        //    viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());
        //    Guid categoryId = Guid.NewGuid();
        //    var categoryServiceMock = new Mock<ICategoryService>();
        //    categoryServiceMock.Setup(c => c.GetById(categoryId)).Returns(new Category() { Id = categoryId });

        //    EditCategoriesPresenter editCategoriesPresenter = new EditCategoriesPresenter
        //        (viewMock.Object, categoryServiceMock.Object);

        //    // Act
        //    viewMock.Raise(v => v.OnUpdateItem += null, new IdEventArgs(categoryId));

        //    // Assert
        //    viewMock.Verify(v => v.TryUpdateModel(It.IsAny<Category>()), Times.Once());
        //}

        //[TestMethod]
        //public void UpdateCategoryIsCalled_WhenItemIsFoundAndIsInValidState()
        //{
        //    // Arrange
        //    var viewMock = new Mock<IEditCategoriesView>();
        //    viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());

        //    Guid categoryId = Guid.NewGuid();
        //    var categoryServiceMock = new Mock<ICategoryService>();
        //    var category = new Category() { Id = categoryId };
        //    categoryServiceMock.Setup(c => c.GetById(categoryId)).Returns(category);

        //    EditCategoriesPresenter editCategoriesPresenter = new EditCategoriesPresenter
        //        (viewMock.Object, categoryServiceMock.Object);

        //    // Act
        //    viewMock.Raise(v => v.OnUpdateItem += null, new IdEventArgs(categoryId));

        //    // Assert
        //    categoryServiceMock.Verify(c => c.UpdateCategory(category), Times.Once());
        //}

        //[TestMethod]
        //public void UpdateCategoryIsNotCalled_WhenItemIsFoundAndIsInInvalidState()
        //{
        //    // Arrange
        //    var viewMock = new Mock<IEditCategoriesView>();
        //    var modelState = new ModelStateDictionary();
        //    modelState.AddModelError("test key", "test message");
        //    viewMock.Setup(v => v.ModelState).Returns(modelState);

        //    Guid categoryId = Guid.NewGuid();
        //    var categoryServiceMock = new Mock<ICategoryService>();
        //    var category = new Category() { Id = categoryId };
        //    categoryServiceMock.Setup(c => c.GetById(categoryId)).Returns(category);

        //    EditCategoriesPresenter editCategoriesPresenter = new EditCategoriesPresenter
        //        (viewMock.Object, categoryServiceMock.Object);

        //    // Act
        //    viewMock.Raise(v => v.OnUpdateItem += null, new IdEventArgs(categoryId));

        //    // Assert
        //    categoryServiceMock.Verify(c => c.UpdateCategory(category), Times.Never());
        //}
    }
}
