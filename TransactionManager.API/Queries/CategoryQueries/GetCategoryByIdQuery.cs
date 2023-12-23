using MediatR;
using TransactionManager.API.Models.Category;

namespace TransactionManager.API.Queries.CategoryQueries
{
    public class GetCategoryByIdQuery : IRequest<CategoryDto>
    {
        public int Id { get; }
        public GetCategoryByIdQuery(int id)
        {
            Id = id;
        }
    }
}
