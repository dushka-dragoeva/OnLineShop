using Ninject;
using OnLineShop.Data;
using OnLineShop.Data.Models;
using OnLineShop.Data.Services;
using OnLineShop.Data.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnLineShop.Web.Admin
{
    public partial class ProducsAdminView : System.Web.UI.Page
    {
        private readonly ProductService ps = new ProductService(new OnLineShopDbContext());

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ListViewProducts.InsertItemPosition = InsertItemPosition.LastItem;
        }

        public IQueryable<Product> ListViewProducts_GetData()
        {
            return this.ps.GetAllWithCategoryBrandPhotos().OrderBy(p => p.Id);
        }
                      
        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewProducts_DeleteItem(int id)
        {
            this.ps.Delete(id);
        }
    }
}