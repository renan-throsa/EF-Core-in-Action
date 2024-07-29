using BookApp.Data.Configs;
using BookApp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BookApp.Data.Contexts
{
    public class NoSqlContext : DbContext
    {
        private readonly string _connectionString;
        private readonly string _dataBaseName;

        public DbSet<BookViewModel> Books { get; init; }

        public NoSqlContext(string connectionString = "mongodb://localhost:27017", string dataBaseName = "BooksApp")
        {
            _connectionString = connectionString;
            _dataBaseName = dataBaseName;

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .EnableSensitiveDataLogging()
                .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
                .UseMongoDB(_connectionString, _dataBaseName);

            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookViewModelConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}
