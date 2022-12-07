using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCWProject.Entities.Concrete;

namespace LCWProject.Bussiness.Interfaces
{
    public interface IProductService:IGenericService<Product>
    {
        Task<List<Product>> GetAllProductAsync();
        Task<Product> FindByIdAsync(int id);
        Task AddProductAsync(Product product);
        Task RemoveProductById(int id);
        Task UpdateProduct(Product product);
        Task<Product> GetByNameAsync(Product product);

    }
}
