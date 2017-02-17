using System;

namespace OnLineShop.MVP.Brands.Admin
{
    public class BrandEventArgs : EventArgs, IBrandIdEventArgs
    {
        public BrandEventArgs(int id, string name, string description, string url)
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