using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebFormsMvp;

using OnLineShop.Data.Services;
using OnLineShop.Data.Services.Contracts;
using OnLineShop.Data.Models;
using WebFormsMvp.Web;

namespace OnLineShop.MVP.Sizes
{
    public class SizesAdminPresenter : Presenter<ISizesAdminView>
    {
        private readonly ISizeService sizeService;

        public SizesAdminPresenter(ISizesAdminView view, ISizeService sizeService)
            : base(view)
        {
            this.sizeService = sizeService;
            this.View.OnSizesGetData += this.View_OnSizesGetData;
            this.View.OnSizeDelite += this.View_OnSizesDelete;
            this.View.OnSizeEdit += this.View_OnSizesEdit;
            this.View.OnSizeCreate += this.View_OnSizesCreate;
        }

        private void View_OnSizesCreate(object sender, EventArgs e)
        {
            Size size = new Size();
            this.View.TryUpdateModel(size);
            if (this.View.ModelState.IsValid)
            {
                this.sizeService.Insert(size);
            }
        }

        private void View_OnSizesEdit(object sender, SizeEventArgs e)
        {
            var Size = new Size();
            Size.Id = e.Id;
            Size.Value = e.Value;
            if (this.View.ModelState.IsValid)
            {
                this.sizeService.Update(Size);
            }
        }

        private void View_OnSizesDelete(object sender, SizeEventArgs e)
        {

            this.sizeService.Delete(e.Id);
        }

        private void View_OnSizesGetData(object sender, EventArgs e)
        {
            this.View.Model.Sizes = this.sizeService.GetAll();
        }
    }
}
