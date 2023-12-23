using MediatR;
using TransactionManager.API.Models.Transaction;

namespace TransactionManager.API.Queries.TransactionQueries
{
    public class GetTransacationByIdQuery : IRequest<TransactionDto>
    {
        public int Id { get; }
        public GetTransacationByIdQuery(int id)
        {
            Id = id;
        }
    }
}
