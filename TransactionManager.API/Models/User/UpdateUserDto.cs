namespace TransactionManager.API.Models.User
{
    public class UpdateUserDto
    {
        public string? Name { get; set; }
        public string? Password { get; set; }
        public double? AccountBalance { get; set; }
    }
}
