using Entity.Concrete;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class ProductListViewModel
    {
      
        public List<Product> Products { get; set; }
        public string Current { get; set; }
    }
}
