using OnLineShop.MVP.Sizes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

using OnLineShop.Data.Models;

namespace OnLineShop.Web.Admin
{
    [PresenterBinding(typeof(SizesAdminPresenter))]
    public partial class SizesAdminView : MvpPage<SizesAdminViewModel>, ISizesAdminView
    {
        public event EventHandler OnSizeCreate;
        public event EventHandler<SizeEventArgs> OnSizeDelite;
        public event EventHandler<SizeEventArgs> OnSizeEdit;
        public event EventHandler OnSizesGetData;

        public IQueryable<Size> SizeListView_GetData()
        {
            this.OnSizesGetData?.Invoke(this, null);
            return this.Model.Sizes.OrderBy(x => x.Id);
        }
        public void SizeListView_UpdateItem(int? id, string value)
        {
            this.OnSizeEdit?.Invoke(this, new SizeEventArgs((int)id, value));
        }

        public void SizeListView_DeleteItem(int? id)
        {
            this.OnSizeDelite?.Invoke(this, new SizeEventArgs((int)id, null));
        }

        public void SizeListView_InsertItem(object sender, EventArgs e)
        {
            this.OnSizeCreate?.Invoke(this, null);
        }
    }
}