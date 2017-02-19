using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using OnLineShop.Data.Services.Contracts;
using Ninject;
using OnLineShop.Data.Models;
using OnLineShop.Data.Services;
using OnLineShop.Data;
using System.Web.ModelBinding;

namespace OnLineShop.Web.Admin
{
    public partial class ProductDetailsAdminView : System.Web.UI.Page
    {
        public ProductDetailsAdminView()
        {
            this.DbContext = new OnLineShopDbContext();
            this.ps = new ProductService(this.DbContext);
        }

        private readonly ProductService ps;
        private readonly CategoryService categories = new CategoryService(new OnLineShopDbContext());
        private readonly BrandService products = new BrandService(new OnLineShopDbContext());
        private readonly SizeService sizes = new SizeService(new OnLineShopDbContext());
        private readonly BrandService brands = new BrandService(new OnLineShopDbContext());
        private readonly PhotoService photos = new PhotoService(new OnLineShopDbContext());

        public OnLineShopDbContext DbContext { get;  set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params.AllKeys[0]=="id")
            {
                this.FormViewAdminProductDetails.ChangeMode(FormViewMode.Edit);
            }
            else
            {
                this.FormViewAdminProductDetails.ChangeMode(FormViewMode.Insert);
            }
            
        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public Product FormViewAdminProductDetails_GetItem([QueryString]int? id)
        {
            return this.ps.GetById(id);
        }

        public void FormViewAdminProductDetails_InsertItem()
        {
            var product = new Product();
            TryUpdateModel(product);
            if (ModelState.IsValid)
            {
                // Save changes here

            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void FormViewAdminProductDetails_DeleteItem(int id)
        {

        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void FormViewAdminProductDetails_UpdateItem(int id)
        {
            OnLineShop.Data.Models.Product item = null;
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                // Save changes here, e.g. MyDataLayer.SaveChanges();

            }
        }

        public IQueryable<Category> DropDownCategories_GetData()
        {
            return this.categories.GetAll();
        }

        public IQueryable<Brand> DropDownBrands_GetData()
        {
            return this.brands.GetAll();
        }

        public IQueryable<Size> DropDownSizes_GetData()
        {
            return this.sizes.GetAll();
        }

        public void Length_ServerValidate(object sender, ServerValidateEventArgs args)
        {
            args.IsValid = args.Value.Length >= 3 || args.Value.Length <= 20;

            //if (args.Value.Length >= 2 || args.Value.Length <= 20)
            //{

            //    args.IsValid = true;
            //}
            //else
            //{
            //    args.IsValid = false;
            //}

        }
        public void DescriptionLength_ServerValidate(object sender, ServerValidateEventArgs args)
        {
            args.IsValid = args.Value.Length >= 10 || args.Value.Length <= 500;

        }
    }
}