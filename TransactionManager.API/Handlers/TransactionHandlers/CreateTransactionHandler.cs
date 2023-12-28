using AutoMapper;
using MediatR;
using TransactionManager.API.Commands.Transaction;
using TransactionManager.API.Configs;
using TransactionManager.API.Entities;

namespace TransactionManager.API.Handlers.TransactionHandlers
{
    public class CreateTransactionHandler : IRequestHandler<CreateTransactionCommand, int>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public CreateTransactionHandler(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<int> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = _mapper.Map<Transaction>(request.CreateTransactionDto);

            _context.Transactions.Add(transaction);
            _context.SaveChanges();

            return Task.FromResult(transaction.Id);
        }
    }
}
