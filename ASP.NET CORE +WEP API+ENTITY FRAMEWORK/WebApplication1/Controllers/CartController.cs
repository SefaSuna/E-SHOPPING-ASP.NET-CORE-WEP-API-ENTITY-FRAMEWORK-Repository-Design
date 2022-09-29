using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Cryptography.Xml;
using WebApplication1.Identıty;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private ICartService _cartService;
        private UserManager<User> _userManager;
        public CartController(ICartService cartService, UserManager<User> userManager)
        {
            _cartService = cartService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var cart = _cartService.GetCart(_userManager.GetUserId(User));
            return View(new CartModel() {
                CartId = cart.Id,
                Total = cart.CartItems.Select(i => i.Product.Quantity * i.Product.Price).Sum(),
                CartItems = cart.CartItems.Select(i => new CartItemModel() {
                    CartItemId = i.Id,
                    ProductId = i.ProductId,
                    Name = i.Product.Name,
                    Price = (double)i.Product.Price,
                    Quantity = i.Quantity,
                    ImageUrl = i.Product.Photo,
                    

                }).ToList(),
            });
        }

        public IActionResult Addcart(CartItem cart)
        {
            var user = _cartService.GetCart(_userManager.GetUserId(User));
            _cartService.AddCart(new CartItem() { CartId=user.Id,Quantity=cart.Quantity,ProductId=cart.Id});

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Deletecart(int Id)
        {
       
            _cartService.DeleteCart(Id);

            return RedirectToAction("Index");
        }

    }
}