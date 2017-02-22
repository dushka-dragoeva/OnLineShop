using System;
using System.Linq;
using WebFormsMvp;
using WebFormsMvp.Web;

using OnLineShop.Data.Models;
using OnLineShop.MVP.Brands;
using OnLineShop.MVP.Brands.Admin;

namespace OnLineShop.Web.Admin
{
    [PresenterBinding(typeof(BrandsAdminPresenter))]
    public partial class BrandsAdminView : MvpPage<BrandsAdminViewModel>, IBrandsAdminView
    {
        public event EventHandler OnBrandsGetData;
        public event EventHandler<BrandAdminEventArgs> OnBrandEdit;
        public event EventHandler<BrandIdEventArgs> OnBrandDelite;
        public event EventHandler OnBrandCreate;

        public IQueryable<Brand> BrandListView_GetData()
        {
            this.OnBrandsGetData?.Invoke(this, null);
            return this.Model.Brands.OrderBy(x => x.Id);
        }
        public void BrandListView_UpdateItem(int? id, string name, string description ,string imageUrl)
        {
            var u = imageUrl;
            this.OnBrandEdit?.Invoke(this, new MVP.Brands.Admin.BrandAdminEventArgs((int)id, name, description,  imageUrl));
        }

        public void BrandListView_DeleteItem(int? id)
        {
            this.OnBrandDelite?.Invoke(this, new BrandIdEventArgs((int)id));
        }

        public void BrandListView_InsertItem(object sender, EventArgs e)
        {
            this.OnBrandCreate?.Invoke(this, null);
        }
    }
}