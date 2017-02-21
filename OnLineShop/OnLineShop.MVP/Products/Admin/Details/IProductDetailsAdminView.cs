using System;
using System.Web.ModelBinding;
using WebFormsMvp;

namespace OnLineShop.MVP.Products.Admin.Details
{
    public interface IProductDetailsAdminView: IView<ProductDetailsAdminViewModel>
    {
        event EventHandler<ProductDetailsAdminEventArgs> OnProductEdit;

        event EventHandler OnPrioductCreate;

        ModelStateDictionary ModelState { get; }

        bool TryUpdateModel<TModel>(TModel model) where TModel : class;
    }
}
