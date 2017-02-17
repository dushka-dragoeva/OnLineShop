using System;

namespace OnLineShop.MVP.Brands
{
    public class BrandIdEventArgs:EventArgs,IBrandIdEventArgs
    {
        public BrandIdEventArgs(int id)

        {
            this.Id = id;
        }

        public int Id { get; set; }
    }
}
