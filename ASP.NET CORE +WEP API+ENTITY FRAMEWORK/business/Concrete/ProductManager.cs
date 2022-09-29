
using System;
using System.Collections.Generic;
using System.Text;
using Entity.Concrete;
using DataAccess.Abstract;
using Business.Abstract;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public async Task<Product> AddAsync(Product entity)
        {
           await _productDal.AddAsync(entity);
            return entity;
        }

        public async Task<Product> DeleteAsync(Product entity)
        {
            await _productDal.DeleteAsync(entity);
            return entity;
        }

        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        public async Task<Product> GetAsync(int id)
        {
            return await _productDal.GetAsync(id);
        }

        public  List<Product> GetByCategoryId(int categoryId)
        {
            return _productDal.GetList(filter:p=>p.CategoryId==categoryId);
        }

        public List<Product> GetByCategoryName(string CategoryName)
        {
            return _productDal.GetList(filter: p => p.ProductCategoryName== CategoryName);
        }

        public async Task<List<Product>> GetListAsync(Expression<Func<Product, bool>> filter = null)
        {
            return await _productDal.GetListAsync(filter);
        }

        public async Task<Product> UpdateAsync(Product entity)
        {
            await _productDal.UpdateAsync(entity);
            return entity;
        }

    
    }
}

