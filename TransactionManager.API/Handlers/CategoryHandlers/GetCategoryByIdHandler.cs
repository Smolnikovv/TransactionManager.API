using AutoMapper;
using MediatR;
using TransactionManager.API.Configs;
using TransactionManager.API.Models.Category;
using TransactionManager.API.Queries.CategoryQueries;

namespace TransactionManager.API.Handlers.CategoryHandlers
{
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
    {
        private readonly IMapper _mapper;
        private readonly DatabaseContext _context;

        public GetCategoryByIdHandler(IMapper mapper, DatabaseContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var result = _context
                .Categories
                .FirstOrDefault(x => x.Id == request.Id);

            return result != null ? Task.FromResult(_mapper.Map<CategoryDto>(result)) : null;
        }
    }
}
