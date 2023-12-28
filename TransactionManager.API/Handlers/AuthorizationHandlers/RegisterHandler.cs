using MediatR;
using Microsoft.AspNetCore.Identity;
using TransactionManager.API.Commands.Authorization;
using TransactionManager.API.Configs;
using TransactionManager.API.Entities;

namespace TransactionManager.API.Handlers.AuthorizationHandlers
{
    public class RegisterHandler : IRequestHandler<RegisterCommand, int>
    {
        private readonly DatabaseContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;
        public RegisterHandler(DatabaseContext context, IPasswordHasher<User> passwordHasher )
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }
        public async Task<int> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = new User()
            {
                Name = request.CreateUserDto.Name,
                AccountBalance = 3000
            };
            string hashedPassword = _passwordHasher.HashPassword(user, request.CreateUserDto.Password);
            user.Password = hashedPassword;
            _context.Users.Add(user);
            _context.SaveChanges();
            return await Task.FromResult(user.Id);
        }
    }
}
