using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICartDal : IEntityRepository<Cart>
    {
        Cart GetByUserId(string userId);
        void AddCart(CartItem cartItem);
        void DeleteCart(int Id);
    }
}
