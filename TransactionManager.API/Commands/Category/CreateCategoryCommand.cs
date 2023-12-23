using MediatR;
using TransactionManager.API.Models.Category;

namespace TransactionManager.API.Commands.Category
{
    public class CreateCategoryCommand : IRequest<int>
    {
        public CreateCategoryDto CreateCategoryDto { get; set; }
        public CreateCategoryCommand(CreateCategoryDto dto)
        {
            CreateCategoryDto = dto;
        }
    }
}
