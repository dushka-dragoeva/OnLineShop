using System;

using WebFormsMvp;

using OnLineShop.Data.Services;
using OnLineShop.Data.Models;
using Bytes2you.Validation;

namespace OnLineShop.MVP.Categories.Admin
{
    public class CategoriesAdminPresenter : Presenter<ICategoriesAdminView>
    {
        private readonly ICategoryService categoryService;

        public CategoriesAdminPresenter(ICategoriesAdminView view, ICategoryService categoryService)
            : base(view)
        {
            Guard.WhenArgument(categoryService, "categoryService").IsNull().Throw();

            this.categoryService = categoryService;

            this.View.OnCategoriesGetData += this.View_OnCategoriesGetData;
            this.View.OnCategoryDelite += this.View_OnCategoriesDelete;
            this.View.OnCategoryEdit += this.View_OnCategoriesEdit;
            this.View.OnCategoryCreate += this.View_OnCategoriesCreate;
        }

        private void View_OnCategoriesCreate(object sender, EventArgs e)
        {
            Category category = new Category();
            this.View.TryUpdateModel(category);
            if (this.View.ModelState.IsValid)
            {
                this.categoryService.Insert(category);
            }
        }

        private void View_OnCategoriesEdit(object sender, CategoryAdminEventArgs e)
        {
            var category = new Category();
            category.Id = e.Id;
            category.Name = e.Name;
            if (this.View.ModelState.IsValid)
            {
                this.categoryService.Update(category);
            }
        }

        private void View_OnCategoriesDelete(object sender, CategoryAdminEventArgs e)
        {

            this.categoryService.Delete(e.Id);
        }

        private void View_OnCategoriesGetData(object sender, EventArgs e)
        {
            this.View.Model.Categories = this.categoryService.GetAll();
        }
    }
}
