using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCartDal : EfEntityRepositoryBase<Cart, WebContext>, ICartDal
    {
        public Cart GetByUserId(string userId)
        {
            using(var context = new WebContext())
            {
                return context.Carts.Include(i => i.CartItems).ThenInclude(a => a.Product).FirstOrDefault(i => i.UserId == userId);

            }
        }

        public void AddCart(CartItem cartItem)
        {
            using (var context = new WebContext())
            {
                context.CartItems.Add(cartItem);
                context.SaveChanges();
            }
        }
        public void DeleteCart(int Id)
        {
            using (var context = new WebContext())
            {
                context.CartItems.RemoveRange(context.CartItems.Where(i=>i.ProductId==Id));
         
                context.SaveChanges();
            }
        }
    }
}
