﻿using MediatR;
using ProductsCleanArch.Domain.Entities;

namespace ProductsCleanArch.Application.Products.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }

        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }
}
