using Catalog.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Queries
{
    public record GetAllProductByBrandQuery(string BrandName):IRequest<IList<ProductResponse>>
    {
    }
}
