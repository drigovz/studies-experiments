using ProductsCleanArch.Domain.Entities;
using ProductsCleanArch.Domain.Interfaces.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsCleanArch.Domain.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product, int>
    {
        Task<IEnumerable<Product>> GetProductsCategoryAsync(int categoryId);
    }
}
