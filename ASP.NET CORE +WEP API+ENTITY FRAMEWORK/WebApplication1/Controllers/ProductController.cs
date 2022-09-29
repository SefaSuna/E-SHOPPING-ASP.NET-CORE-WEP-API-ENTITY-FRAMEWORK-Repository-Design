using Business.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Xml;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productservice;
        private ICategoryService _categoryservice;

        public ProductController(IProductService productservice, ICategoryService categoryservice)
        {
            _productservice = productservice;
            _categoryservice = categoryservice;
        }

        public IActionResult Detail(int id)
        {
            var model = new ProductListViewModel()
            {
                Products =_productservice.GetAll().Where(i=>i.Id == id).ToList(),
            };
            return View(model);
        }
        public IActionResult Phone(string name)
        {

            var model = new ProductListViewModel()
            {
                Products = name == "all" ? _productservice.GetAll().Where(i => i.CategoryId == 1).ToList() : _productservice.GetByCategoryName(name),
                Current = HttpContext.Request.Query["name"]
            };
           
            ViewBag.say = name == "all" ? _productservice.GetAll().Where(i => i.CategoryId == 1).Count() : _productservice.GetByCategoryName(name).Count();
            ViewBag.category = _categoryservice.GetAll().Where(p => p.CategoryId == 1).ToList();
            return View(model);
        }

        public IActionResult Book(string name)
        {

            var model = new ProductListViewModel()
            {
                Products = name == "all" ? _productservice.GetAll().Where(i => i.CategoryId== 2).ToList() : _productservice.GetByCategoryName(name),
                Current = HttpContext.Request.Query["name"]
            };

            ViewBag.say = name == "all" ? _productservice.GetAll().Where(i => i.CategoryId == 2).Count() : _productservice.GetByCategoryName(name).Count();
            ViewBag.category = _categoryservice.GetAll().Where(p => p.CategoryId == 2).ToList();
            return View(model);
        }
        public IActionResult Tv(string name)
        {

            var model = new ProductListViewModel()
            {
                Products = name == "all" ? _productservice.GetAll().Where(i => i.CategoryId == 3).ToList() : _productservice.GetByCategoryName(name),
                Current = HttpContext.Request.Query["name"]
            };

            ViewBag.say = name == "all" ? _productservice.GetAll().Where(i => i.CategoryId == 3).Count() : _productservice.GetByCategoryName(name).Count();
            ViewBag.category = _categoryservice.GetAll().Where(p => p.CategoryId == 3).ToList();
            return View(model);
        }
    }
}

