using AutoMapper;
using MediatR;
using TransactionManager.API.Commands.User;
using TransactionManager.API.Configs;
using TransactionManager.API.Entities;

namespace TransactionManager.API.Handlers.UserHandlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public CreateUserHandler(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request.CreateUserDto);
            _context.Add(user);
            return Task.FromResult(user.Id);
        }
    }
}
