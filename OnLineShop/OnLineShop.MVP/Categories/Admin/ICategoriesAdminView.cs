
using System;
using System.Web.ModelBinding;
using WebFormsMvp;

namespace OnLineShop.MVP.Categories.Admin
{
    public interface ICategoriesAdminView : IView<CategoriesAdminViewModel>
    {
        event EventHandler OnCategoriesGetData;
        
        event EventHandler <CategoryAdminEventArgs>OnCategoryEdit;
        
        event EventHandler<CategoryAdminEventArgs> OnCategoryDelite;

        event EventHandler OnCategoryCreate;

        ModelStateDictionary ModelState { get; }

        bool TryUpdateModel<TModel>(TModel model) where TModel : class;
    }
}
