using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransactionManager.API.Configs;
using TransactionManager.API.Models.Transaction;
using TransactionManager.API.Queries.TransactionQueries;

namespace TransactionManager.API.Handlers.TransactionHandlers
{
    public class GetTransactionByIdHandler : IRequestHandler<GetTransacationByIdQuery, TransactionDto>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public GetTransactionByIdHandler(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<TransactionDto> Handle(GetTransacationByIdQuery request, CancellationToken cancellationToken)
        {
            var result = _context
                .Transactions
                .Include(x => x.Category)
                .FirstOrDefault(x => x.Id == request.Id);

            return result != null ? Task.FromResult(_mapper.Map<TransactionDto>(result)) : null;
        }
    }
}
