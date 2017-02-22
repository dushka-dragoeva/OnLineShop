using Moq;
using OnLineShop.Data.Models;
using OnLineShop.MVP.Brands.Admin;
using System;
using System.Web.ModelBinding;
using NUnit.Framework;
using OnLineShop.Data.Services.Contracts;

namespace OnLineShop.Mvp.Tests.Categories.AdminCategoriesPresenterTests
{
    [TestFixture]
    public class View_OnBrandsEdit_Should
    {
        [Test]
        public void AddModelError_WhenBrandIsNotFound()
        {
            // Arrange
            var viewMock = new Mock<IBrandsAdminView>();
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());
            string errorKey = string.Empty;
            int brandId = 1;
            string brandName = "Pesho";
            string expectedError = String.Format("Item with id {0} was not found", brandId);
            var brandServiceMock = new Mock<IBrandService>();
            brandServiceMock.Setup(c => c.GetById(brandId)).Returns<Brand>(null);

            BrandsAdminPresenter brandsAdminPresenter = new BrandsAdminPresenter
                (viewMock.Object, brandServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnBrandEdit += null, new BrandAdminEventArgs(brandId, brandName, null, null));

            // Assert
            Assert.AreEqual(1, viewMock.Object.ModelState[errorKey].Errors.Count);
            StringAssert.AreEqualIgnoringCase(expectedError, viewMock.Object.ModelState[errorKey].Errors[0].ErrorMessage);
        }

        [Test]
        public void TryUpdateModelIsNotCalled_WhenBrandIsNotFound()
        {
            // Arrange
            var viewMock = new Mock<IBrandsAdminView>();
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());
            string errorKey = string.Empty;
            int brandId = 1;
            string brandName = "Pesho";
            var brandServiceMock = new Mock<IBrandService>();
            brandServiceMock.Setup(c => c.GetById(brandId)).Returns<Brand>(null);

            BrandsAdminPresenter brandsAdminPresenter = new BrandsAdminPresenter
                (viewMock.Object, brandServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnBrandEdit += null, new BrandAdminEventArgs(brandId, brandName, null, null));

            // Assert
            viewMock.Verify(v => v.TryUpdateModel(It.IsAny<Category>()), Times.Never());
        }

        [Test]
        public void TryUpdateModelIsCalled_WhenBrandIsFound()
        {
            // Arrange
            var viewMock = new Mock<IBrandsAdminView>();
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());

            int brandId = 1;
            string brandName = "Pesho";
            var categoryServiceMock = new Mock<IBrandService>();
            categoryServiceMock.Setup(c => c.GetById(brandId)).Returns(new Brand() { Id = brandId, Name = brandName });

            BrandsAdminPresenter brandsAdminPresenter = new BrandsAdminPresenter
                (viewMock.Object, categoryServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnBrandEdit += null, new BrandAdminEventArgs(brandId, brandName, null, null));

            // Assert
            viewMock.Verify(v => v.TryUpdateModel(It.IsAny<Brand>()), Times.Once());
        }

        [Test]
        public void UpdateIsCalled_WhenBrandIsFoundAndIsInValidState()
        {
            // Arrange
            var viewMock = new Mock<IBrandsAdminView>();
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());
            int brandId = 1;
            string brandName = "Pesho";
            var brandServiceMock = new Mock<IBrandService>();
            var brand = new Brand() { Id = brandId, Name = brandName };
            brandServiceMock.Setup(c => c.GetById(brandId)).Returns(brand);

            BrandsAdminPresenter brandsAdminPresenter = new BrandsAdminPresenter
                (viewMock.Object, brandServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnBrandEdit += null, new BrandAdminEventArgs(brandId, brandName, null, null));

            // Assert
            brandServiceMock.Verify(c => c.Update(brand), Times.Once());
        }

        [Test]
        public void UpdateIsNotCalled_WhenItemIsFoundAndIsInInvalidState()
        {
            // Arrange
            var viewMock = new Mock<IBrandsAdminView>();
            var modelState = new ModelStateDictionary();
            modelState.AddModelError("test key", "test message");
            viewMock.Setup(v => v.ModelState).Returns(modelState);

            int brandId = 1;
            string brandName = "Pesho";
            var brandServiceMock = new Mock<IBrandService>();
            var brand = new Brand() { Id = brandId, Name = brandName };
            brandServiceMock.Setup(c => c.GetById(brandId)).Returns(brand);

            BrandsAdminPresenter brandsAdminPresenter = new BrandsAdminPresenter
                (viewMock.Object, brandServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnBrandEdit += null, new BrandAdminEventArgs(brandId, brandName, null, null));

            // Assert
            brandServiceMock.Verify(c => c.Update(brand), Times.Never());
        }
    }
}
