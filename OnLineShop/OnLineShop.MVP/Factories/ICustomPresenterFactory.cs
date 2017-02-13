using System;

using WebFormsMvp;

namespace OnLineShop.MVP.Factories
{
    public interface ICustomPresenterFactory
    {
        IPresenter GetPresenter(Type presenterTipe, IView viewInstance);
    }
}
