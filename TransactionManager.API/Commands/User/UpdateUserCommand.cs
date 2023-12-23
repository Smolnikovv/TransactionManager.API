using MediatR;
using TransactionManager.API.Models.User;

namespace TransactionManager.API.Commands.User
{
    public class UpdateUserCommand : IRequest<bool>
    {
        public UpdateUserDto User { get; }
        public int Id { get; }
        public UpdateUserCommand(UpdateUserDto user, int id)
        {
            User = user;
            Id = id;
        }
    }
}
