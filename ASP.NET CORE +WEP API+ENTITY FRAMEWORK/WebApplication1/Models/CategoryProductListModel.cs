using Entity.Concrete;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class CategoryProductListModel
    {
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
    }
}
