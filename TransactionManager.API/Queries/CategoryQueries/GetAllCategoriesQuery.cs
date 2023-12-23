using MediatR;
using TransactionManager.API.Models.Category;

namespace TransactionManager.API.Queries.CategoryQueries
{
    public class GetAllCategoriesQuery : IRequest<List<CategoryDto>>
    {
    }
}
