using AutoMapper;
using MediatR;
using TransactionManager.API.Configs;
using TransactionManager.API.Models.User;
using TransactionManager.API.Queries.UserQueries;

namespace TransactionManager.API.Handlers.UserHandlers
{
    public class GetUserByIdHandelr : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public GetUserByIdHandelr(DatabaseContext databaseContext, IMapper mapper)
        {
            _context = databaseContext;
            _mapper = mapper;
        }

        public Task<UserDto>? Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var result = _context
                .Users
                .FirstOrDefault(x => x.Id == request.Id);

            return result != null ? Task.FromResult(_mapper.Map<UserDto>(result)) : null;

        }
    }
}
