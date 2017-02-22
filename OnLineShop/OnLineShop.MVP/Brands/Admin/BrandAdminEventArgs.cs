using System;

namespace OnLineShop.MVP.Brands.Admin
{
    public class BrandAdminEventArgs : EventArgs, IBrandIdEventArgs
    {
        public BrandAdminEventArgs(int id, string name, string description, string url)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Url = url;
        }
        
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }
    }
}