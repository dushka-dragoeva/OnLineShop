using System;
using System.Linq;

using WebFormsMvp.Web;

using OnLineShop.Data.Models;
using OnLineShop.MVP.Categories;
using WebFormsMvp;

namespace OnLineShop.Web.Admin
{
    [PresenterBinding(typeof(CategoriesPresenter))]
    public partial class CategoriesView : MvpPage<CategoriesViewModel>, ICategoriesView
    {
        public event EventHandler OnCategoriesGetData;
        public event EventHandler<CategoryEventArgs> OnCategoryEdit;
        public event EventHandler<CategoryEventArgs> OnCategoryDelite;
        public event EventHandler OnCategoryCreate;

        public CategoryEventArgs categoryEventArgs;

        public IQueryable<Category> CategoryListView_GetData()
        {
            this.OnCategoriesGetData?.Invoke(this, null);
            return this.Model.Categories.OrderBy(x => x.Id);
        }
        public void CategoryListView_UpdateItem(int? id, string name)
        {
            this.OnCategoryEdit?.Invoke(this, new CategoryEventArgs((int)id,name));
        }

        public void CategoryListView_DeleteItem(int? id)
        {
            this.OnCategoryDelite?.Invoke(this, new CategoryEventArgs((int)id, null));
        }

        public void CategoryListView_InsertItem(object sender, EventArgs e)
        {
            this.OnCategoryCreate?.Invoke(this, null);
        }
    }
}