using AutoMapper;
using ProductsCleanArch.Application.DTOs;
using ProductsCleanArch.Application.Interfaces;
using ProductsCleanArch.Domain.Entities;
using ProductsCleanArch.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsCleanArch.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAsync()
        {
            var categories = await _categoryRepository.GetAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }

        public async Task<CategoryDTO> GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task<CategoryDTO> AddAsync(CategoryDTO categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            var result = await _categoryRepository.AddAsync(category);
            return _mapper.Map<CategoryDTO>(result);
        }

        public async Task<CategoryDTO> UpdateAsync(CategoryDTO categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            var result = await _categoryRepository.UpdateAsync(category);
            return _mapper.Map<CategoryDTO>(result);
        }

        public async Task<bool> RemoveAsync(int id)
            => await _categoryRepository.RemoveAsync(id);
    }
}
