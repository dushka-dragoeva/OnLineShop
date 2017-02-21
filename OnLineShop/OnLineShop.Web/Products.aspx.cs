using OnLineShop.Data.Models;
using OnLineShop.MVP.Products.Client;
using System;
using System.Linq;
using System.Web.ModelBinding;
using WebFormsMvp;
using WebFormsMvp.Web;


namespace OnLineShop.Web
{
    [PresenterBinding(typeof(ProductsPresenter))]
    public partial class Products : MvpPage<ProductsViewModel>, IProductsView
    {
        public event EventHandler OnProductsGetData;

        public IQueryable<Product> Products_GetData(object sender, EventArgs e)
        {
            this.OnProductsGetData?.Invoke(this, null);
            return this.Model.Products;
        }
    }
}