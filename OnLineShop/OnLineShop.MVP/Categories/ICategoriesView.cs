using System;
using WebFormsMvp;

namespace OnLineShop.MVP.Categories
{
    public interface ICategoriesView : IView<CategoriesViewModel>
    {
        event EventHandler OnCategoriesGetData;
    }
}
