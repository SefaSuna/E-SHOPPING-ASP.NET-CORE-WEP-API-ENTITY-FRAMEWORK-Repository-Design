
using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Entity.Concrete
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string Photo { get; set; }
        public string ProductCategoryName { get; set; }
        public Category Category { get; set; }
    }
}
