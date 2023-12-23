using MediatR;
using TransactionManager.API.Models.User;

namespace TransactionManager.API.Commands.User
{
    public class CreateUserCommand : IRequest<int>
    {
        public CreateUserDto CreateUserDto { get; }
        public CreateUserCommand(CreateUserDto dto) 
        {
            CreateUserDto = dto;
        }
    }
}
