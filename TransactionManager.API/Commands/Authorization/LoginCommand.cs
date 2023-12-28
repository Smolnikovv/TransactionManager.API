using MediatR;
using TransactionManager.API.Models.User;

namespace TransactionManager.API.Commands.Authorization
{
    public class LoginCommand : IRequest<string>
    {
        public LoginDto LoginDto { get; set; }
        public LoginCommand(LoginDto loginDto)
        {
            LoginDto = loginDto;
        }       
       
    }
}
