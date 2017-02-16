using System;
using System.Linq;
using System.Web.UI.WebControls;

using Ninject;

using WebFormsMvp.Web;

using OnLineShop.Data.Models;
using OnLineShop.Data.Services;
using OnLineShop.MVP.Categories;
using WebFormsMvp;

namespace OnLineShop.Web.Admin
{
    [PresenterBinding(typeof(CategoriesPresenter))]
    public partial class CategoriesView : MvpPage<CategoriesViewModel>, ICategoriesView
    {
        [Inject]
        public ICategoryService CategoryService { get; set; }

        public event EventHandler OnCategoriesGetData;
        public event EventHandler OnCategoriesEditData;
        public event EventHandler OnCategoriesDeliteData;
        public event EventHandler OnCategoriesGetById;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)

            {
                ViewState["PreviousPage"] = Request.UrlReferrer;
            }
        }

        public IQueryable<Category> GridViewCategories_GetData()
        {
            this.OnCategoriesGetData?.Invoke(this, null);
            return this.Model.Categories.OrderBy(x => x.Id);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewCategories_UpdateItem(int? id)
        {
            var name = ((TextBox)GridViewCategories.Rows[index: 0].FindControl("EditName")).Text;
            this.CategoryService.UpdateName(id, name);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewCategories_DeleteItem(int? id)
        {
            this.OnCategoriesDeliteData?.Invoke(this, null);
        }

        protected void ButtonCreate_Click(object sender, EventArgs e)
        {
            string name = this.CategoryCreate.Text;
            this.CategoryService.Create(name);
            this.Response.Redirect("~/Admin/CategoriesView.aspx");
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("~/Admin/CategoriesView.aspx");
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