using AutoMapper;
using MediatR;
using TransactionManager.API.Commands.User;
using TransactionManager.API.Configs;

namespace TransactionManager.API.Handlers.UserHandlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly DatabaseContext _context;

        public UpdateUserHandler(DatabaseContext context)
        {
            _context = context;
        }

        public Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _context
                .Users
                .FirstOrDefault(x => x.Id == request.Id);

            if(user == null) return Task.FromResult(false);

            user.Name = request.User.Name ?? user.Name;
            user.Password = request.User.Password ?? user.Password;
            user.AccountBalance = request.User.AccountBalance ?? user.AccountBalance;

            _context.SaveChanges();

            return Task.FromResult(true);
        }
    }
}
