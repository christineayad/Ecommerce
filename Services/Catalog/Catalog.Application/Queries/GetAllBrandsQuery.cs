using Catalog.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Queries
{
    //de message bt2ol 3wza all brands for handler , handeler execute the query and return list of brands
    public record GetAllBrandsQuery:IRequest<List<BrandResponse>>
    {
    }   
}
