using ProductsCleanArch.Domain.Entities;
using ProductsCleanArch.Domain.Interfaces.Repository;

namespace ProductsCleanArch.Domain.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category, int>
    { }
}
