using AutoMapper;
using MediatR;
using ProductsCleanArch.Application.DTOs;
using ProductsCleanArch.Application.Interfaces;
using ProductsCleanArch.Application.Products.Commands;
using ProductsCleanArch.Application.Products.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsCleanArch.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProductService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<ProductDTO>> GetAsync()
        {
            var products = await _mediator.Send(new GetProductsQuery());
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<ProductDTO> GetByIdAsync(int id)
        {
            var result = await _mediator.Send(new GetProductByIdQuery(id));

            return _mapper.Map<ProductDTO>(result);
        }

        public async Task<ProductDTO> AddAsync(ProductDTO productDto)
        {
            var product = _mapper.Map<ProductCreateCommand>(productDto);
            var result = await _mediator.Send(product);
            return _mapper.Map<ProductDTO>(result);
        }

        public async Task<ProductDTO> UpdateAsync(ProductDTO productDto)
        {
            var product = _mapper.Map<ProductUpdateCommand>(productDto);
            var result = await _mediator.Send(product);
            return _mapper.Map<ProductDTO>(result);
        }

        public async Task<bool> RemoveAsync(int id)
            => await _mediator.Send(new ProductRemoveCommand(id));

        //public async Task<IEnumerable<ProductDTO>> GetProductsCategoryAsync(int categoryId)
        //{
        //    var products = await _productRepository.GetProductsCategoryAsync(categoryId);
        //    return _mapper.Map<IEnumerable<ProductDTO>>(products);
        //}
    }
}
