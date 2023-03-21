using MediatR;
using ProductsCleanArch.Domain.Entities;
using System.Collections.Generic;

namespace ProductsCleanArch.Application.Products.Queries
{
    public class GetProductsQuery : IRequest<IEnumerable<Product>>
    { }
}
