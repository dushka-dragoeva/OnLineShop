using Microsoft.Owin;
using OnLineShop.Data.Models;
using OnLineShop.MVP.Categories.Admin;
using OnLineShop.MVP.Categories.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace OnLineShop.Web
{

    [PresenterBinding(typeof(CategoriesPresenter))]
    public partial class Categories : MvpPage<CategoriesViewModel>, ICategoriesView
    {
        public event EventHandler OnCategoriesGetData;
      //  public event EventHandler<CategoryAdminEventArgs> OnCategoriesSelectedIndexChanged;

        public IQueryable<Category> CategoryListView_GetData()
        {
            this.OnCategoriesGetData?.Invoke(this, null);
            return this.Model.Categories;
        }


        //public IQueryable<Product> Categories_SelectedIndexChanged([QueryString] int id)
        //{
        //    this.OnCategoriesSelectedIndexChanged?.Invoke(this, new CategoryAdminEventArgs(id, null));
        //    return this.Model.Category.Products as IQueryable<Product>;
        //}

        //public IQueryable<Product> Categories_SelectedIndexChanged(object sender, EventArgs args)
        //{
            
        //   // this.OnCategoriesSelectedIndexChanged?.Invoke(this, a);

        //    return this.Model.Category.Products as IQueryable<Product>;
        //}

    }
}