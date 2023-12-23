using AutoMapper;
using MediatR;
using TransactionManager.API.Configs;
using TransactionManager.API.Models.Category;
using TransactionManager.API.Queries.CategoryQueries;

namespace TransactionManager.API.Handlers.CategoryHandlers
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryDto>>
    {
        private readonly IMapper _mapper;
        private readonly DatabaseContext _context;

        public GetAllCategoriesHandler(IMapper mapper, DatabaseContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public Task<List<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var result = _context
                .Categories
                .ToList();

            return Task.FromResult(_mapper.Map<List<CategoryDto>>(result));
        }
    }
}
