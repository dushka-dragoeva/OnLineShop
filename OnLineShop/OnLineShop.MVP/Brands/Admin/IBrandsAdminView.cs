using System;
using System.Web.ModelBinding;
using WebFormsMvp;

namespace OnLineShop.MVP.Brands.Admin
{
    public interface IBrandsAdminView: IView<BrandsAdminViewModel>
    {
        event EventHandler OnBrandsGetData;

        event EventHandler<BrandAdminEventArgs> OnBrandEdit;

        event EventHandler<BrandIdEventArgs> OnBrandDelite;

        event EventHandler OnBrandCreate;

        ModelStateDictionary ModelState { get; }

        bool TryUpdateModel<TModel>(TModel model) where TModel : class;
    }
}
