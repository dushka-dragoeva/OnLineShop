using Bytes2you.Validation;
using OnLineShop.Data.Models;
using OnLineShop.Data.Services.Contracts;
using System;
using WebFormsMvp;

namespace OnLineShop.MVP.Products.Admin.Details
{
    public class ProductDetailsAdminPresenter : Presenter<IProductDetailsAdminView>
    {
        private readonly IProductService productService;

        public ProductDetailsAdminPresenter(IProductDetailsAdminView view, IProductService productService)
            : base(view)
        {
            Guard.WhenArgument(productService, "productService").IsNull().Throw();

            this.productService = productService;

            this.View.OnPrioductCreate += this.View_OnPrioductCreate;
            this.View.OnProductEdit += this.View_OnProductEdit;

        }

        private void View_OnProductEdit(object sender, ProductDetailsAdminEventArgs e)
        {
            Product item = this.productService.GetById(e.Id);
            if (item == null)
            {
                // The item wasn't found
                this.View.ModelState.
                    AddModelError("", String.Format("Item with id {0} was not found", e.Id));
                return;
            }

            this.View.TryUpdateModel(item);
            if (this.View.ModelState.IsValid)
            {
                this.productService.Update(item);
            }
        }

        private void View_OnPrioductCreate(object sender, EventArgs e)
        {
           
            Product product = new Product();
            this.View.TryUpdateModel(product);
            if (this.View.ModelState.IsValid)
            {
                this.productService.Insert(product);
            }
        }
    }
}
