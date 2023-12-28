using MediatR;
using TransactionManager.API.Models.User;

namespace TransactionManager.API.Commands.Authorization
{
    public class RegisterCommand : IRequest<int>
    {
        public CreateUserDto CreateUserDto { get; set; }
        public RegisterCommand(CreateUserDto createUserDto)
        {
            CreateUserDto = createUserDto;
        }
    }
}
