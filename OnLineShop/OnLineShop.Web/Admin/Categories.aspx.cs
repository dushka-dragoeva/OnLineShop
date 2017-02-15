using Ninject;
using OnLineShop.Data.Models;
using OnLineShop.Data.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnLineShop.Web.Admin
{
    public partial class Categories : Page
    {
        [Inject]
        public ICategoryService CategoryService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            //check if the webpage is loaded for the first time. 
            {
                ViewState["PreviousPage"] = Request.UrlReferrer;//Saves the Previous page url in ViewState 
            }
        }
        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Category> GridViewCategories_GetData()
        {
            return this.CategoryService.GetAll().OrderBy(x => x.Name);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewCategories_UpdateItem(int? id)
        {

            var editTitleBox = this.GridViewCategories.Rows[this.GridViewCategories.EditIndex].Controls[0].Controls[0] as TextBox;
            var name = editTitleBox.Text;

            this.CategoryService.UpdateName(id, name);

        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewCategories_DeleteItem(int? id)
        {
            //Category item = this.CategoryService.GetById(id);
            //// Load the item here, e.g. item = MyDataLayer.Find(id);
            //if (item == null)
            //{
            //    // The item wasn't found
            //    ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
            //    return;
            //}
            //TryUpdateModel(item);
            //if (ModelState.IsValid)
            //{
            this.CategoryService.Delete(id);
            //}
        }

        protected void ButtonCreate_Click(object sender, EventArgs e)
        {
            string name = this.CategoryCreate.Text;
            this.CategoryService.Create(name);
            this.Response.Redirect("~/Admin/Categories.aspx");
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            // this.CreareItem.Visible = false;
            // this.ButtonAdd.Visible = true;
            // this.RequiredfieldValidator.IsValid = true;
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