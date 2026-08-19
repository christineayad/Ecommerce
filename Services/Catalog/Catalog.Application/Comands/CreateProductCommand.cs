using Catalog.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Comands
{
    public record CreateProductCommand:IRequest<ProductResponse>
    {
        public string Name { get; init; }
        public string Summary { get; init; }
        public string Description { get; init; }
        public string ImageFile { get; init; }
        public string Brand { get; init; }
        public string Type { get; init; }  
        public decimal Price { get; init; }
    }
}
