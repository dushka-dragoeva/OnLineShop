using OnLineShop.Data.Models;
using System;
using System.Collections.Generic;

namespace OnLineShop.MVP.Products.Admin.Details
{
    public class ProductDetailsAdminEventArgs : EventArgs
    {
        public ProductDetailsAdminEventArgs(
            int id,
            string name,
            string modelNumber,
            string description,
            int quantity,
            decimal price,
            bool isInPromotion,
            decimal? promoPrice,
            string pictureUrl,
            Category category,
            Brand brand,
            ICollection<Size> sizes
            )

        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Quantity = quantity;
            this.Price = price;
            this.PromoPrice = promoPrice;
            this.IsInPromotion = isInPromotion;
            this.PictureUrl = pictureUrl;
            this.Category = category;
            this.Brand = brand;
            this.Sizes = sizes;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string ModelNumber { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal? PromoPrice { get; set; }

        public bool IsInPromotion { get; set; }

        public string PictureUrl { get; set; }

        public Category Category { get; set; }

        public Brand Brand { get; set; }

        public ICollection<Size> Sizes { get; set; }
    }
}
