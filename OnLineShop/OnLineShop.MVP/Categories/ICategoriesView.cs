using System;
using System.Web.ModelBinding;
using WebFormsMvp;

namespace OnLineShop.MVP.Categories
{
    public interface ICategoriesView : IView<CategoriesViewModel>
    {
        event EventHandler OnCategoriesGetData;
        
        event EventHandler <CategoryEventArgs>OnCategoryEdit;
        
        event EventHandler<CategoryEventArgs> OnCategoryDelite;

        event EventHandler OnCategoryCreate;

        ModelStateDictionary ModelState { get; }

        bool TryUpdateModel<TModel>(TModel model) where TModel : class;
    }
}
