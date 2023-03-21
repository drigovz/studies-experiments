using ProductsCleanArch.Domain.Entities;
using ProductsCleanArch.Domain.Interfaces;
using ProductsCleanArch.Infra.Data.Context;

namespace ProductsCleanArch.Infra.Data.Repository
{
    public class CategoryRepository : BaseRepository<Category, int>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context)
            : base(context)
        {
        }
    }
}
