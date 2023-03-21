using ProductsCleanArch.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsCleanArch.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAsync();
        Task<ProductDTO> GetByIdAsync(int id);
        Task<ProductDTO> AddAsync(ProductDTO productDto);
        Task<ProductDTO> UpdateAsync(ProductDTO productDto);
        Task<bool> RemoveAsync(int id);
        //Task<IEnumerable<ProductDTO>> GetProductsCategoryAsync(int categoryId);
    }
}
