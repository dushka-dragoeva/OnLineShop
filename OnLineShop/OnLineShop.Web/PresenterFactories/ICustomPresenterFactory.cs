using System;
using WebFormsMvp;

namespace OnLineShop.Web.PresenterFactories
{
    public interface ICustomPresenterFactory
    {
        IPresenter GetPresenter(Type presenterType, IView viewInstance);
    }
}
