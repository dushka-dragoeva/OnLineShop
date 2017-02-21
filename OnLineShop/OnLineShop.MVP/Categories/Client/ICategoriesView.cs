using System;
using WebFormsMvp;

namespace OnLineShop.MVP.Categories.Client
{
    public interface ICategoriesView : IView<CategoriesViewModel>
    {
        event EventHandler OnCategoriesGetData;

        //event EventHandler<CategoryAdminEventArgs> OnCategoriesSelectedIndexChanged;
    }
}
