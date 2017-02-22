using System;
using System.Linq;

using WebFormsMvp;

using OnLineShop.Data.Services;

namespace OnLineShop.MVP.Categories.Client
{
    public class CategoriesPresenter: Presenter<ICategoriesView>
    {
        private readonly ICategoryService categoryService;

        public CategoriesPresenter (ICategoriesView view, ICategoryService categoryService)
            : base(view)
        {
            this.categoryService = categoryService;
            this.View.OnCategoriesGetData += this.View_OnCategoriesGetData;
           // this.View.OnCategoriesSelectedIndexChanged += this.View_OnCategoriesIndexChangedData;
        }

        //private void View_OnCategoriesIndexChangedData(object sender, CategoryEventArgs e)
        //{
        //    this.View.Model.Category = this.categoryService.GetById(e.Id);
        //}

        private void View_OnCategoriesGetData(object sender, EventArgs e)
        {
           this.View.Model.Categories = this.categoryService.GetAllWithProducts().OrderBy(c=>c.Name);
        }
    }
}
