namespace TransactionManager.API.Models.Transaction
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
