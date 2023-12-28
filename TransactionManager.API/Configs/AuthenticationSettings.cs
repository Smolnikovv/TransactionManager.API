namespace TransactionManager.API.Configs
{
    public class AuthenticationSettings
    {
        public string JwtKey { get; set; }
        public int JwtExpireDays { get; set; }
        public string JwtIssuser { get; set; }
    }
}
