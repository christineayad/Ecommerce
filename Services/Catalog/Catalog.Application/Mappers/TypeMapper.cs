using Catalog.Application.Responses;
using Catalog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Mappers
{
    public static  class TypeMapper
    {
        public static TypeResponse ToResponse(this ProductType type)
        {
            return new TypeResponse
            {
                Id = type.Id,
                Name = type.Name
            };
        }
        public static IList<TypeResponse> ToResponseList(
            this IEnumerable<ProductType> types)
        {
            return types.Select(t => t.ToResponse()).ToList();
        }
       
    }
}
