using OnLineShop.Data;
using OnLineShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OnLineShop.MVP.Models
{
    public class ShoppingCartActions //: IDisposable
    {
    //    public Guid ShoppingCartId { get; set; }

    //    private OnLineShopDbContext dbContext = new OnLineShopDbContext();

    //    public const string CartSessionKey = "CartId";

    //    public void AddToCart(Guid id)
    //    {
    //        // Retrieve the product from the database.           
    //        ShoppingCartId = GetCartId();

    //        var cartItem = this.dbContext.ShoppingCartItems.SingleOrDefault(
    //            c => c.CartId == ShoppingCartId
    //            && c.ProductId == id);
    //        if (cartItem == null)
    //        {
    //            // Create a new cart item if no cart item exists.                 
    //            cartItem = new CartItem
    //            {
    //                Id = Guid.NewGuid(),
    //                ProductId = id,
    //                CartId = ShoppingCartId,
    //                Product = dbContext.Products.SingleOrDefault(
    //               p => p.Id == id),
    //                Quantity = 1,
    //                DateCreated = DateTime.Now
    //            };

    //            dbContext.ShoppingCartItems.Add(cartItem);
    //        }
    //        else
    //        {
    //            // If the item does exist in the cart,                  
    //            // then add one to the quantity.                 
    //            cartItem.Quantity++;
    //        }

    //        dbContext.SaveChanges();
    //    }

    //    public void Dispose()
    //    {
    //        if (_db != null)
    //        {
    //            _db.Dispose();
    //            _db = null;
    //        }
    //    }

    //    public Guid GetCartId()
    //    {
    //        if (HttpContext.Current.Session[CartSessionKey] == null)
    //        {
    //            if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
    //            {
    //                HttpContext.Current.Session[CartSessionKey] = HttpContext.Current.User.Identity.Name;
    //            }
    //            else
    //            {
    //                // Generate a new random GUID using System.Guid class.     
    //                Guid tempCartId = Guid.NewGuid();
    //                HttpContext.Current.Session[CartSessionKey] = tempCartId;
    //            }
    //        }
    //        return HttpContext.Current.Session[CartSessionKey].ToString();
    //    }

    //    public List<CartItem> GetCartItems()
    //    {
    //        ShoppingCartId = GetCartId();

    //        return _db.ShoppingCartItems.Where(
    //            c => c.CartId == ShoppingCartId).ToList();
    //    }
    }
}

