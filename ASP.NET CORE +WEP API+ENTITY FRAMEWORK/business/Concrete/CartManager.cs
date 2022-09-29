using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entity.Abstract;
using Entity.Concrete;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class CartManager : ICartService
    {
        private ICartDal _cartDal;

        public CartManager(ICartDal cartDal)
        {
            _cartDal = cartDal;
        }

        public void Add(Cart entity)
        {
            _cartDal.Add(entity);
        }

        public void AddCart(CartItem cart)
        {

            using (var context = new WebContext())
            {   //Product Quantity
                var PQuantity = context.Products.Where(i => i.Id == cart.ProductId).Select(i => i.Quantity).Sum();
                //Cart Quantity
                var CQuantity = context.CartItems.Where(i=>i.ProductId==cart.ProductId).Select(i=>i.Quantity).Sum();
                if (CQuantity<=0)
                {
                    if (PQuantity<=cart.Quantity)
                    {
                        cart.Quantity=PQuantity  ;
                        _cartDal.AddCart(cart);
                    }
                    else
                    {
                        _cartDal.AddCart(cart);
                    } 

                 }
                else if (CQuantity <= cart.Quantity)
                {
                    if (PQuantity <= cart.Quantity)
                    {
                       
                        var result = context.CartItems.Where(i => i.ProductId == cart.ProductId).FirstOrDefault();
                        result.Quantity = PQuantity;
                        context.SaveChanges();
                    }
                    else
                    {  var result = context.CartItems.Where(i => i.ProductId == cart.ProductId).FirstOrDefault();
                        result.Quantity = cart.Quantity;
                        context.SaveChanges();

                    }
                    
            
                    
                }

            }

           
        }

        public void Delete(Cart entity)
        {
            _cartDal.Delete(entity);
        }

        public void DeleteCart(int Id)
        {
            _cartDal.DeleteCart(Id);
        }

        public List<Cart> GetAll()
        {
            return _cartDal.GetList();
        }

        public Cart GetCart(string id)
        {
            return _cartDal.GetByUserId(id);
        }

        public void Update(Cart entity)
        {
            _cartDal.Update(entity);
        }
    }
}
