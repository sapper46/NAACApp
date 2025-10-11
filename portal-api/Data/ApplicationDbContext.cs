using Microsoft.EntityFrameworkCore;
using PortalApi.Models;

namespace PortalApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<TableARow> TableA { get; set; }
        public DbSet<TableBRow> TableB { get; set; }
        public DbSet<TableCRow> TableC { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Users table
            modelBuilder.Entity<User>().HasData(
                new User 
                { 
                    UserId = 1, 
                    Username = "admin", 
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin123"), 
                    CreatedDate = DateTime.UtcNow 
                }
            );

            // Seed TableA with random numbers
            var random = new Random(42); // Fixed seed for consistent data
            var tableAData = new List<TableARow>();
            for (int i = 1; i <= 5; i++)
            {
                tableAData.Add(new TableARow
                {
                    Id = i,
                    ColumnA = Math.Round(random.NextDouble() * 100, 2),
                    ColumnB = Math.Round(random.NextDouble() * 100, 2),
                    ColumnC = Math.Round(random.NextDouble() * 100, 2),
                    ColumnD = Math.Round(random.NextDouble() * 100, 2),
                    ColumnE = Math.Round(random.NextDouble() * 100, 2)
                });
            }
            modelBuilder.Entity<TableARow>().HasData(tableAData);

            // Seed TableB with animal names
            var animals = new[] { "Bird", "Dog", "Cat", "Rabbit", "Hamster" };
            var tableBData = new List<TableBRow>();
            for (int i = 1; i <= 5; i++)
            {
                tableBData.Add(new TableBRow
                {
                    Id = i,
                    ColumnA = animals[random.Next(animals.Length)],
                    ColumnB = animals[random.Next(animals.Length)],
                    ColumnC = animals[random.Next(animals.Length)],
                    ColumnD = animals[random.Next(animals.Length)],
                    ColumnE = animals[random.Next(animals.Length)]
                });
            }
            modelBuilder.Entity<TableBRow>().HasData(tableBData);

            // Seed TableC with correlated data
            var tableCData = new List<TableCRow>();
            for (int i = 1; i <= 20; i++)
            {
                var baseValue = random.NextDouble() * 80 + 10; // Base value between 10-90
                var columnA = Math.Round(baseValue, 2);
                var columnB = Math.Round(baseValue + (random.NextDouble() * 20 - 10), 2); // Correlated but with some variation
                tableCData.Add(new TableCRow
                {
                    Id = i,
                    ColumnA = columnA,
                    ColumnB = Math.Max(0, Math.Min(100, columnB)) // Ensure it stays between 0-100
                });
            }
            modelBuilder.Entity<TableCRow>().HasData(tableCData);
        }
    }
}