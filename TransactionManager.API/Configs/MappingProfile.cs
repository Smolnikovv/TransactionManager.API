using AutoMapper;
using TransactionManager.API.Entities;
using TransactionManager.API.Models.Category;
using TransactionManager.API.Models.Transaction;
using TransactionManager.API.Models.User;

namespace TransactionManager.API.Configs
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<Category, CategoryDto>();

            CreateMap<CreateTransactionDto, Transaction>();
            CreateMap<Transaction, TransactionDto>()
                .ForMember(dest=>dest.CategoryName,
                opt=>opt.MapFrom(
                    src=>src.Category.Name));

            CreateMap<CreateUserDto, User>();
            CreateMap<User, UserDto>();
        }
    }
}
