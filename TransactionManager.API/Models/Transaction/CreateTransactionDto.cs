using System.ComponentModel.DataAnnotations;

namespace TransactionManager.API.Models.Transaction
{
    public class CreateTransactionDto
    {
        [Required]
        public string Name { get; set; }
        public double Amount { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
    }
}
