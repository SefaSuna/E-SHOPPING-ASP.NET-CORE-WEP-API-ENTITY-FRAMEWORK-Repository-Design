

using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Dtos
{
    public class ProductDetails:IDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

    }
}
