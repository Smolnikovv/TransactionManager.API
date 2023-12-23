using AutoMapper;
using MediatR;
using TransactionManager.API.Commands.Category;
using TransactionManager.API.Configs;
using TransactionManager.API.Entities;

namespace TransactionManager.API.Handlers.CategoryHandlers
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, int>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public CreateCategoryHandler(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request.CreateCategoryDto);
            _context.Add(category);
            _context.SaveChanges();
            return Task.FromResult(category.Id);
        }
    }
}
