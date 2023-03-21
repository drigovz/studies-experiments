using Microsoft.EntityFrameworkCore;
using ProductsCleanArch.Domain.Entities;
using ProductsCleanArch.Domain.Interfaces;
using ProductsCleanArch.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsCleanArch.Infra.Data.Repository
{
    public class ProductRepository : BaseRepository<Product, int>, IProductRepository
    {
        private readonly DbSet<Product> _dataset;

        public ProductRepository(AppDbContext context)
            : base(context)
        {
            _dataset = context.Set<Product>();
        }

        public async Task<IEnumerable<Product>> GetProductsCategoryAsync(int categoryId)
            => await _dataset.Include(x => x.Category).Where(x => x.CategoryId == categoryId).ToListAsync();
    }
}
