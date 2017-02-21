using Ninject;
using OnLineShop.Data;
using OnLineShop.Data.Models;
using OnLineShop.Data.Services;
using OnLineShop.Data.Services.Contracts;
using OnLineShop.MVP.Products.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace OnLineShop.Web.Admin
{
    [PresenterBinding(typeof(ProductsAdminPresenter))]
    public partial class ProducsAdminView : MvpPage<ProductsAdminViewModel>, IProductsAdminView 
    {
       // private readonly ProductService ps = new ProductService(new OnLineShopDbContext());

        public event EventHandler OnProductsGetData;
        public event EventHandler<ProductsAdminEventArgs> OnProductDelite;
                    

        public IQueryable<Product> ListViewProducts_GetData()
        {
            this.OnProductsGetData?.Invoke(this, null);

            return this.Model.Products;
        }
                      
        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewProducts_DeleteItem(int? id)
        {
            this.OnProductDelite?.Invoke(this, new ProductsAdminEventArgs((int)id));
        }
    }
}