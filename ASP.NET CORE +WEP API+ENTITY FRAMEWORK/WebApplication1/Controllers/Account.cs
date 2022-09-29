using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Identıty;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class Account : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private ICartService _cartService;
        public Account(UserManager<User> userManager, SignInManager<User> signInManager, ICartService cartService)
        {
           _userManager = userManager  ;
            _signInManager = signInManager;
            _cartService = cartService;


    }





        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user= await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Please Try Again");
                return View();
            }
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, isPersistent: false,true);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Password or E-Mail is incorrect");
            return View(model);
        }



        public IActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Signup(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            
            var user = new User()
            {
                Email = model.Email,
                UserName=model.UserName,
            };
            var result= await _userManager.CreateAsync(user,model.Password);
            if (result.Succeeded) {
                _cartService.Add(new Cart() { UserId = user.Id });
                return RedirectToAction("login","Account");
            }
            else
            {
                result.Errors.ToList().ForEach(e => ModelState.AddModelError(e.Code, e.Description));
            }
            return View(model);
        }
        public async Task<IActionResult> logout(RegisterModel model)
        {
            await _signInManager.SignOutAsync();
            return Redirect("~/");
        }
}
}