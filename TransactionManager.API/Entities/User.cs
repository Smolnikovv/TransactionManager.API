﻿namespace TransactionManager.API.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public double AccountBalance { get; set; }
    }
}
