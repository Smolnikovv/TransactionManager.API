using Microsoft.EntityFrameworkCore;
using TransactionManager.API.Entities;

namespace TransactionManager.API.Configs
{
    public class DatabaseChecker
    {
        private readonly DatabaseContext _context;
        public DatabaseChecker(DatabaseContext context)
        {
            _context = context;
            CheckConnection();
            SeedDatabase();
        }
        private void CheckConnection()
        {
            if (!_context.Database.CanConnect())
            {
                throw new Exception("No connection");
            }
            UpdateDatabase();
        }
        private void UpdateDatabase()
        {
            if (CheckPendingMigrations())
            {
                _context.Database.Migrate();
            }
        }
        private bool CheckPendingMigrations()
        {
            return _context.Database.GetPendingMigrations().Any();
        }
        private void SeedDatabase()
        {
            if(CheckIfEmpty())
            {
                var categories = GetCategories();
                var users = GetUsers();
                var transactions = GetTransactions();
                _context.Categories.AddRange(categories);
                _context.SaveChanges();
                _context.Users.AddRange(users);
                _context.SaveChanges();
                _context.Transactions.AddRange(transactions);
                _context.SaveChanges();
            }
        }
        private List<Category> GetCategories()
        {
            return new List<Category>()
            {
                new Category
                {
                    Name = "Jedzenie"
                },
                new Category
                {
                    Name = "Finanse"
                },
                new Category
                {
                    Name = "Rozrywka"
                }
            };
            
        }
        private List<User> GetUsers()
        {
            return new List<User>()
            {
                new User
                {
                    AccountBalance = 3000,
                    Name = "Jan Kowalski",
                    Password = "Test123"
                },
                new User
                {
                    AccountBalance = 4000,
                    Name = "Robert Makłowicz",
                    Password = "123RRR"
                },
                new User
                {
                    AccountBalance = 1700,
                    Name = "Maryla Rodowicz",
                    Password = "ASDfASDf"
                }
            };
        }
        private List<Transaction> GetTransactions()
        {
            return new List<Transaction>()
            {
                new Transaction
                {
                    CategoryId = 1,
                    UserId = 1,
                    Amount = 40,
                    Name = "Restauracja"
                },
                new Transaction
                {
                    CategoryId = 2,
                    UserId = 1,
                    Amount = 900,
                    Name = "Czynsz"
                },
                new Transaction
                {
                    CategoryId = 3,
                    UserId = 2,
                    Amount = 20,
                    Name = "Kino"
                },
                new Transaction
                {
                    CategoryId = 3,
                    UserId = 2,
                    Amount = 50,
                    Name = "Teatr"
                },
                new Transaction
                {
                    CategoryId = 3,
                    UserId = 3,
                    Amount = 20,
                    Name = "Koncert"
                },
                new Transaction
                {
                    CategoryId = 1,
                    UserId = 3,
                    Amount = 60,
                    Name = "Zakupy"
                }
            };
        }
        private bool CheckIfEmpty()
        {
            if (_context.Categories.Any() || _context.Users.Any() || _context.Transactions.Any()) return false;
            return true;
        }
    }
}
