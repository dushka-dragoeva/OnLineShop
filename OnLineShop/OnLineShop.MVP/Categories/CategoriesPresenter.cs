using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebFormsMvp;

using OnLineShop.Data.Services;

namespace OnLineShop.MVP.Categories
{
    public class CategoriesPresenter : Presenter<ICategoriesView>
    {
        private readonly ICategoryService categoryService;


        public CategoriesPresenter(ICategoriesView view, ICategoryService categoryService)
            : base(view)
        {
            this.categoryService = categoryService;
            this.View.OnCategoriesGetData += this.View_OnCategoriesGetData;
            this.View.OnCategoriesDeliteData += this.View_OnCategoriesDeleteData;
        }

        private void View_OnCategoriesDeleteData(object sender, EventArgs e)
        {
           // this.View.Model.Category = this.categoryService.Delete();
        }

        private void View_OnCategoriesGetData(object sender, EventArgs e)
        {
            this.View.Model.Categories = this.categoryService.GetAll();
        }



    }
}
