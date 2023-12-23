using MediatR;
using TransactionManager.API.Models.Transaction;

namespace TransactionManager.API.Commands.Transaction
{
    public class CreateTransactionCommand : IRequest<int>
    {
        public CreateTransactionDto CreateTransactionDto { get; }
        public CreateTransactionCommand(CreateTransactionDto dto)
        {
            CreateTransactionDto = dto;
        }
    }
}
