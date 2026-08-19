using Catalog.Application.Responses;
using Catalog.Core.Specification;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Queries
{
    public record GetAllProductsQuery(CatalogSpecParams CatalogSpecParams) : IRequest<Pagination<ProductResponse>>;
    
}
