using MediatR;
using TransactionManager.API.Models.Transaction;

namespace TransactionManager.API.Queries.TransactionQueries
{
    public class GetAllUserTransactionsQuery : IRequest<List<TransactionDto>>
    {
        public int UserId { get; }
        public GetAllUserTransactionsQuery(int userId)
        {
            UserId = userId;
        }
    }
}
