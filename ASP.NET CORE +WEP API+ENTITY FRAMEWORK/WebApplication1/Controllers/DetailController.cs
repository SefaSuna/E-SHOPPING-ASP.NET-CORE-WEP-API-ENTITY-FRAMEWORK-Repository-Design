using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class DetailController : Controller
    {
        private IProductService _productservice;
        private ICategoryService _categoryservice;

        public DetailController(IProductService productservice, ICategoryService categoryservice)
        {
            _productservice = productservice;
            _categoryservice = categoryservice;
        }
        public IActionResult Phone()
        {
            return View();
        }


        public IActionResult Car()
        {
            return View();
        }


        public IActionResult Tv()
        {
            return View();
        }
    }
}
