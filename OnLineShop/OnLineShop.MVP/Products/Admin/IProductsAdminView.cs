using System;
using System.Web.ModelBinding;
using WebFormsMvp;

namespace OnLineShop.MVP.Products.Admin
{
    public interface IProductsAdminView:IView<ProductsAdminViewModel>
    {
        event EventHandler OnProductsGetData;

        event EventHandler<ProductsAdminEventArgs> OnProductDelite;

        ModelStateDictionary ModelState { get; }

        bool TryUpdateModel<TModel>(TModel model) where TModel : class;
    }
}
