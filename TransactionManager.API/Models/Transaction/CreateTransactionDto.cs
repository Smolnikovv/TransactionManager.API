namespace TransactionManager.API.Models.Transaction
{
    public class CreateTransactionDto
    {
        public string Name { get; set; }
        public double Amount { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
    }
}
