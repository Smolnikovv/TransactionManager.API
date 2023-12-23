using MediatR;
using TransactionManager.API.Models.User;

namespace TransactionManager.API.Queries.UserQueries
{
    public class GetUserByIdQuery : IRequest<UserDto>
    {
        public int Id { get; set; }
        public GetUserByIdQuery(int id) 
        {
            Id = id;
        }
    }
}
