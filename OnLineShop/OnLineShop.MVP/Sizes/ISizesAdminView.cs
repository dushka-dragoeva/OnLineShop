using System;
using System.Web.ModelBinding;
using WebFormsMvp;

namespace OnLineShop.MVP.Sizes
{
    public interface ISizesAdminView :IView<SizesAdminViewModel>
    {
        event EventHandler OnSizesGetData;

        event EventHandler<SizeEventArgs> OnSizeEdit;

        event EventHandler<SizeEventArgs> OnSizeDelite;

        event EventHandler OnSizeCreate;

        ModelStateDictionary ModelState { get; }

        bool TryUpdateModel<TModel>(TModel model) where TModel : class;
    }
}

