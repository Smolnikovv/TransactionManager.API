namespace TransactionManager.API.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public double Amount { get; set; }
        public virtual User User { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
