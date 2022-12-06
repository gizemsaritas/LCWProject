using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCWProject.Bussiness.DTO.Product;
using LCWProject.Bussiness.Interfaces;
using LCWProject.DataAccess.Concrete.Context;
using LCWProject.DataAccess.Concrete.Repository;
using LCWProject.DataAccess.Interfaces;
using LCWProject.Entities.Concrete;

namespace LCWProject.Bussiness.Concrete
{
    public class ProductService : GenericRepository<Product>, IProductService
    {
        private readonly IGenericService<Product> _genericDal;
        public ProductService(DemoDbContext context, IGenericService<Product> genericDal) : base(context)
        {
            _genericDal = genericDal;
        }
        public async Task<List<Product>> GetAllProductAsync()
        {
            return await _genericDal.GetAllAsync();
        }

        public async Task<Product> FindByIdAsync(int id)
        {
            return await _genericDal.FindByIdAsync(id);
        }
        public async Task AddProductAsync(Product product)
        {
            await _genericDal.AddAsync(product);
        }
        public async Task RemoveProductById(int id)
        {
            var product = await _genericDal.FindByIdAsync(id);
            await _genericDal.RemoveAsync(product);
        }
        public async Task UpdateProduct(Product product)
        {
            await _genericDal.UpdateAsync(product);
        }

    }
}
