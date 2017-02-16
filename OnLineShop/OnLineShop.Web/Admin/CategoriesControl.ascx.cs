using Ninject;
using OnLineShop.Data.Models;
using OnLineShop.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnLineShop.Web.Admin
{
    public partial class CategoriesControl : System.Web.UI.UserControl
    {
        [Inject]
        public ICategoryService CategoryService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        public IQueryable<Category> GridViewCategories_GetData()
        {
            return this.CategoryService.GetAll().OrderBy(x => x.Name);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewCategories_UpdateItem(int? id ,object sender, EventArgs e)
        {          

            var name = ((TextBox)GridViewCategories.Rows[index: 0].FindControl("EditName")).Text;
            
            this.CategoryService.UpdateName(id, name);

        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewCategories_DeleteItem(int? id)
        {
            this.CategoryService.Delete(id);
        }

        protected void ButtonCreate_Click(object sender, EventArgs e)
        {
            string name = this.CategoryCreate.Text;
            this.CategoryService.Create(name);
            this.Response.Redirect("~/Admin/Categories.aspx");
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("~/Admin/Categories.aspx");
        }

        protected void GridViewCategories_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            this.CreareItem.Visible = true;
            this.ButtonAdd.Visible = false;
        }
    }
}