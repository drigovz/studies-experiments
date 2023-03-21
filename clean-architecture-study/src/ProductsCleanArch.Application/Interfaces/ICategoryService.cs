using ProductsCleanArch.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsCleanArch.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetAsync();
        Task<CategoryDTO> GetByIdAsync(int id);
        Task<CategoryDTO> AddAsync(CategoryDTO categoryDto);
        Task<CategoryDTO> UpdateAsync(CategoryDTO categoryDto);
        Task<bool> RemoveAsync(int id);
    }
}
