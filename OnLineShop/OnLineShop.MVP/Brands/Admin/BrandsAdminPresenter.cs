using System;

using WebFormsMvp;

using OnLineShop.Data.Services.Contracts;
using OnLineShop.Data.Models;

namespace OnLineShop.MVP.Brands.Admin
{
    public class BrandsAdminPresenter: Presenter<IBrandsAdminView>
    {
        private readonly IBrandService BrandService;

        public BrandsAdminPresenter(IBrandsAdminView view, IBrandService BrandService)
            : base(view)
        {
            this.BrandService = BrandService;
            this.View.OnBrandsGetData += this.View_OnBrandGetData;
            this.View.OnBrandDelite += this.View_OnBrandDelete;
            this.View.OnBrandEdit += this.View_OnBrandEdit;
            this.View.OnBrandCreate += this.View_OnBrandCreate;
        }

        private void View_OnBrandCreate(object sender, EventArgs e)
        {
            Brand brand = new Brand();
            this.View.TryUpdateModel(brand);
            if (this.View.ModelState.IsValid)
            {
                this.BrandService.Insert(brand);
            }
        }

        private void View_OnBrandEdit(object sender, BrandAdminEventArgs e)
        {
            Brand brand = this.BrandService.GetById(e.Id);

            if (brand == null)
            {
                // The item wasn't found
                this.View.ModelState.
                    AddModelError("", String.Format("Item with id {0} was not found", e.Id));
                return;
            }

            this.View.TryUpdateModel(brand);
            if (this.View.ModelState.IsValid)
            {
                this.BrandService.Update(brand);
            }
        }

        private void View_OnBrandDelete(object sender, BrandIdEventArgs e)
        {
            this.BrandService.Delete(e.Id);
        }

        private void View_OnBrandGetData(object sender, EventArgs e)
        {
            this.View.Model.Brands = this.BrandService.GetAll();
        }
    }
}
