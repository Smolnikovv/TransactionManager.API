using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TransactionManager.API.Entities;

namespace TransactionManager.API.Configs
{
    public class DatabaseChecker
    {
        private readonly DatabaseContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;
        public DatabaseChecker(DatabaseContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            CheckConnection();
            SeedDatabase();
        }
        private void CheckConnection()
        {
            try
            {
                UpdateDatabase();
            }
            catch
            {
                throw new Exception("No connection");
            }
            
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
            var res = _context.Database.GetPendingMigrations().Any();
            return res;
        }
        private void SeedDatabase()
        {
            if(CheckIfEmpty())
            {
                var categories = GetCategories();
                var users = GetUsers();
                _context.Categories.AddRange(categories);
                _context.SaveChanges();
                _context.Users.AddRange(users);
                _context.SaveChanges();

                var transactions = GetTransactions();
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
            var user = new User();
            return new List<User>()
            {
                new User
                {
                    AccountBalance = 3000,
                    Name = "Jan Kowalski",
                    Password = _passwordHasher.HashPassword(user,"test123")
                },
                new User
                {
                    AccountBalance = 4000,
                    Name = "Robert Makłowicz",
                    Password = _passwordHasher.HashPassword(user,"23123RRRRR")
                },
                new User
                {
                    AccountBalance = 1700,
                    Name = "Maryla Rodowicz",
                    Password = _passwordHasher.HashPassword(user,"dkfkdfgsnkfdsgko")
                }
            };
        }
        private List<Transaction> GetTransactions()
        {
            try
            {
                int mak = _context
                    .Users
                    .FirstOrDefault(x => x.Name.Contains("Makłowicz"))
                    .Id;
                int kowal = _context
                    .Users
                    .FirstOrDefault(x => x.Name.Contains("Kowalski"))
                    .Id;
                int rodow = _context
                    .Users
                    .FirstOrDefault(x => x.Name.Contains("Rodowicz"))
                    .Id;

                int jedz = _context
                    .Categories
                    .FirstOrDefault(x => x.Name.Contains("Jedzenie"))
                    .Id;
                int finan = _context
                    .Categories
                    .FirstOrDefault(x => x.Name.Contains("Finanse"))
                    .Id;
                int rozry = _context
                    .Categories
                    .FirstOrDefault(x => x.Name.Contains("Jedzenie"))
                    .Id;
                return new List<Transaction>()
            {
                new Transaction
                {
                    CategoryId = 1,
                    UserId = kowal,
                    Amount = 40,
                    Name = "Restauracja"
                },
                new Transaction
                {
                    CategoryId = 2,
                    UserId = kowal,
                    Amount = 900,
                    Name = "Czynsz"
                },
                new Transaction
                {
                    CategoryId = 3,
                    UserId = mak,
                    Amount = 20,
                    Name = "Kino"
                },
                new Transaction
                {
                    CategoryId = 3,
                    UserId = mak,
                    Amount = 50,
                    Name = "Teatr"
                },
                new Transaction
                {
                    CategoryId = 3,
                    UserId = rodow,
                    Amount = 20,
                    Name = "Koncert"
                },
                new Transaction
                {
                    CategoryId = 1,
                    UserId = rodow,
                    Amount = 60,
                    Name = "Zakupy"
                }
            };

            }
            catch
            {
                throw new Exception("seeder error");
            }
            }
        private bool CheckIfEmpty()
        {
            if (_context.Categories.Any() || _context.Users.Any() || _context.Transactions.Any()) return false;
            return true;
        }
    }
}
