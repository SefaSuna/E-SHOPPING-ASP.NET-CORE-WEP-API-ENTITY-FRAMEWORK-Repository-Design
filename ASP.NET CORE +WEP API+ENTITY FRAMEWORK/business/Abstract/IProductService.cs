using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete;
namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetByCategoryId(int CategoryId);
        List<Product> GetByCategoryName(string CategoryName);

        //async
        Task<List<Product>> GetListAsync(Expression<Func<Product, bool>> filter = null);
        Task<Product> GetAsync(int id);
        Task<Product> AddAsync(Product entity);
        Task<Product> UpdateAsync(Product entity);
        Task<Product> DeleteAsync(Product entity);

    }
}
