using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using Catalog.Application.Mappers;

using MediatR;



namespace Catalog.Application.Handler
{
    public class GetAllTypesHandler : IRequestHandler<GetAllTypesQuery, IList<TypeResponse>>
    {
        private readonly ITypeRepository _typeRepository;
        public GetAllTypesHandler(ITypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }
        public async Task<IList<TypeResponse>> Handle(GetAllTypesQuery request, CancellationToken cancellationToken)
        {
           
            var typeList = await _typeRepository.GetAllTypes();
            return typeList.ToResponseList();
        }
    }
}
