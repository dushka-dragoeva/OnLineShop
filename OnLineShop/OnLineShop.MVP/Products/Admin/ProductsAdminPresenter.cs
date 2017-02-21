using OnLineShop.Data.Services;
using OnLineShop.Data.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace OnLineShop.MVP.Products.Admin
{

    public class ProductsAdminPresenter : Presenter<IProductsAdminView>
    {
        private readonly IProductService productService;

        public ProductsAdminPresenter(IProductsAdminView view, IProductService productService) : 
            base(view)
        {
            this.productService = productService;
            this.View.OnProductDelite += this.View_OnProductDelite;
            this.View.OnProductsGetData += this.View_OnProductsGetData;

        }

        private void View_OnProductsGetData(object sender, EventArgs e)
        {
            this.View.Model.Products = this.productService.GetAllWithCategoryBrand();

        }

        private void View_OnProductDelite(object sender, ProductsAdminEventArgs e)
        {
            this.productService.Delete(e.Id);
        }
    }
}
