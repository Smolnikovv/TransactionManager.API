using System.ComponentModel.DataAnnotations;

namespace TransactionManager.API.Models.Category
{
    public class CreateCategoryDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
