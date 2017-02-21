using System;
using System.Linq;

using WebFormsMvp.Web;

using OnLineShop.Data.Models;
using OnLineShop.MVP.Categories;
using WebFormsMvp;
using OnLineShop.MVP.Categories.Admin;

namespace OnLineShop.Web.Admin
{
    [PresenterBinding(typeof(CategoriesAdminPresenter))]
    public partial class CategoriesView : MvpPage<CategoriesAdminViewModel>, ICategoriesAdminView
    {
        public event EventHandler OnCategoriesGetData;
        public event EventHandler<CategoryAdminEventArgs> OnCategoryEdit;
        public event EventHandler<CategoryAdminEventArgs> OnCategoryDelite;
        public event EventHandler OnCategoryCreate;

        public IQueryable<Category> CategoryListView_GetData()
        {
            this.OnCategoriesGetData?.Invoke(this, null);
            return this.Model.Categories.OrderBy(x => x.Id);
        }
        public void CategoryListView_UpdateItem(int? id, string name)
        {
            this.OnCategoryEdit?.Invoke(this, new CategoryAdminEventArgs((int)id, name));
        }

        public void CategoryListView_DeleteItem(int? id)
        {
            this.OnCategoryDelite?.Invoke(this, new CategoryAdminEventArgs((int)id, null));
        }

        public void CategoryListView_InsertItem(object sender, EventArgs e)
        {
            this.OnCategoryCreate?.Invoke(this, null);
        }
    }
}