using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.Adapters;

using OnLineShop.Data.Services.Contracts;
using Ninject;
using OnLineShop.Data.Models;
using OnLineShop.Data.Services;
using OnLineShop.Data;
using System.Web.ModelBinding;
using System.IO;
using OnLineShop.MVP.Photos;

namespace OnLineShop.Web.Admin
{
    public partial class ProductDetailsAdminView : System.Web.UI.Page
    {
        private const string ImageRelativePath = "~/Content/Images/";

        private readonly ProductService ps;
        private readonly CategoryService categories;

        private readonly SizeService sizes;
        private readonly BrandService brands;


        public ProductDetailsAdminView()
        {
            this.DbContext = new OnLineShopDbContext();
            this.ps = new ProductService(this.DbContext);
            this.categories = new CategoryService(this.DbContext);
            this.sizes = new SizeService(this.DbContext);
            this.brands = new BrandService(this.DbContext);
        }

        public OnLineShopDbContext DbContext { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params.AllKeys[0] == "id")
            {
                this.FormViewAdminProductDetails.ChangeMode(FormViewMode.Edit);
            }
            else
            {
                this.FormViewAdminProductDetails.ChangeMode(FormViewMode.Insert);
            }
        }

        public Product FormViewAdminProductDetails_GetItem([QueryString]int? id)
        {
            return this.ps.GetById(id);
        }

        public void FormViewAdminProductDetails_InsertItem(object sender, EventArgs e)
        {

            var product = new Product();

            TryUpdateModel(product);

            //  var sizes = this.DropDownSizes_GetData(sender, e);
            //foreach (var item in sizes)
            //{
            //    product.Sizes.Add(item);
            //}

            if (ModelState.IsValid)
            {
                this.ps.Insert(product);
            }

        }

        public void FormViewAdminProductDetails_UpdateItem(int id)
        {
            Product item = null;
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
            return this.categories.GetAll().OrderBy(c => c.Name);
        }

        public IQueryable<Brand> DropDownBrands_GetData()
        {
            return this.brands.GetAll().OrderBy(b => b.Name);
        }

        public IQueryable<Size> DropDownSizes_GetData()
        {
            return this.sizes.GetAll().OrderBy(s => s.Value);
        }

        public void Length_ServerValidate(object sender, ServerValidateEventArgs args)
        {
            args.IsValid = args.Value.Length >= 3 || args.Value.Length <= 20;
        }
        public void DescriptionLength_ServerValidate(object sender, ServerValidateEventArgs args)
        {
            args.IsValid = args.Value.Length >= 10 || args.Value.Length <= 500;
        }

        public void UploadButton1_Click(object sender, EventArgs e)
        {
            FileUpload imageToUpload = (FileUpload)FormViewAdminProductDetails.FindControl("FileUpload1");
            Label StatusLabel = (Label)FormViewAdminProductDetails.FindControl("LabelUploadStatus");
            TextBox filePath = (TextBox)FormViewAdminProductDetails.FindControl("TextBoxFilePath");
            Image imageTodisplay = (Image)FormViewAdminProductDetails.FindControl("DisplayImage");

            if (imageToUpload.HasFile)
            {
                try
                {
                    if (imageToUpload.PostedFile.ContentType == "image/jpeg" || imageToUpload.PostedFile.ContentType == "image/png")
                    {
                        if (imageToUpload.PostedFile.ContentLength < 1024000)
                        {
                            string filename = Path.GetFileName(imageToUpload.FileName);
                            string relativePath = "~/Content/Images/" + filename;
                            imageToUpload.SaveAs(Server.MapPath("~/Content/Images/") + filename);
                            StatusLabel.Text = "Upload status: File uploaded!";
                            filePath.Text = "~/Content/Images/" + filename;
                            imageTodisplay.ImageUrl = ImageRelativePath + filename;

                        }
                        else
                            StatusLabel.Text = "Upload status: The file has to be more than 1000 kb!";
                    }
                    else
                        StatusLabel.Text = "Upload status: Only JPEG files are accepted!";
                }
                catch (Exception ex)
                {
                    StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
        }

        protected void FormViewAdminProductDetails_PageIndexChanging(object sender, FormViewPageEventArgs e)
        {

        }

        protected ICollection<Size> DropDownSizes_GetData(object sender, EventArgs e)
        {
            CheckBoxList sizesCheckBox = (CheckBoxList)FormViewAdminProductDetails.FindControl("CheckBoxListSizes");

            var selectedSizes = new HashSet<Size>();

            for (int i = 0; i < sizesCheckBox.Items.Count; i++)
            {
                ListItem item = sizesCheckBox.Items[i];

                if (item.Selected)
                {
                    int selectedId = int.Parse(item.Value);
                    Size selectedSize = this.sizes.GetById(selectedId);
                    selectedSizes.Add(selectedSize);
                }
            }

            return selectedSizes;
        }
    }
}