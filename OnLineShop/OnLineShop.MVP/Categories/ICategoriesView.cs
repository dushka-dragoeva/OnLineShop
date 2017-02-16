using System;
using WebFormsMvp;

namespace OnLineShop.MVP.Categories
{
    public interface ICategoriesView : IView<CategoriesViewModel>
    {
        event EventHandler OnCategoriesGetData;

        event EventHandler OnCategoriesEditData;

        event EventHandler OnCategoriesDeliteData;

        event EventHandler OnCategoriesGetById;

    }
}
