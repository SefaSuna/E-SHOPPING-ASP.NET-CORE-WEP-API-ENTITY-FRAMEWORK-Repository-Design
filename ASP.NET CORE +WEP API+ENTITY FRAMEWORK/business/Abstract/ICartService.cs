using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICartService
    {
        void Add(Cart cart);
        void AddCart(CartItem cart);
        void DeleteCart(int Id);

        void Update(Cart cart);
        void Delete(Cart cart);
        List<Cart> GetAll();
        Cart GetCart(string id);

    }
}
