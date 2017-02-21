using OnLineShop.Data.Services;
using OnLineShop.Data.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace OnLineShop.MVP.Products.Client
{
    public class ProductsPresenter : Presenter<IProductsView>
    {
        private readonly IProductService productService;


        public ProductsPresenter(IProductsView view, IProductService productService ) 
            : base(view)
        {
            this.productService = productService;
            this.View.OnProductsGetData += this.View_OnProductsGetData;
        }

        private void View_OnProductsGetData(object sender, EventArgs e)
        {
            this.View.Model.Products = this.productService.GetAllWithCategoryBrand();
        }
       
    }
}
