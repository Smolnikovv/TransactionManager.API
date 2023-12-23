using AutoMapper;
using MediatR;
using TransactionManager.API.Configs;
using TransactionManager.API.Models.Transaction;
using TransactionManager.API.Queries.TransactionQueries;

namespace TransactionManager.API.Handlers.TransactionHandlers
{
    public class GetAllUserTransactionHandler : IRequestHandler<GetAllUserTransactionsQuery, List<TransactionDto>>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public GetAllUserTransactionHandler(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<List<TransactionDto>>? Handle(GetAllUserTransactionsQuery request, CancellationToken cancellationToken)
        {
            var result = _context
                .Transactions
                .Where(x => x.UserId == request.UserId)
                .ToList();

            return result != null ? Task.FromResult(_mapper.Map<List<TransactionDto>>(result)) : null;
        }
    }
}
