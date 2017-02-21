using System;
using WebFormsMvp;

namespace OnLineShop.MVP.Products.Client
{
    public interface IProductsView : IView<ProductsViewModel>
    {
        event EventHandler OnProductsGetData;
    }
}
