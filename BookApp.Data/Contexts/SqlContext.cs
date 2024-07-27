using BookApp.Data.Configs;
using BookApp.Data.Utils;
using BookApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookApp.Data.Contexts
{
    public class SqlContext: DbContext
    {
        private readonly string ConnectionString;

        public DbSet<Book> Books { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<PriceOffer> PriceOffers { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public SqlContext()
        {
            ConnectionString = "Server=.\\SQLEXPRESS;Database=BooksApp;Trusted_Connection=True;";
        }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .EnableSensitiveDataLogging()
                .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
                .UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorEntityConfig());
            modelBuilder.ApplyConfiguration(new BookEntityConfigs());
            modelBuilder.ApplyConfiguration(new PriceOfferEntityConfigs());
            modelBuilder.ApplyConfiguration(new ReviewEntityConfig());
            modelBuilder.ApplyConfiguration(new CustomerEntityConfigs());
            modelBuilder.ApplyConfiguration(new TagEntityConfigs());
            modelBuilder.ApplyConfiguration(new BookAuthorEntityConfigs());
            modelBuilder.ApplyConfiguration(new BookTagEntityConfigs());
            modelBuilder.ApplyConfiguration(new BookCustomerEntityConfigs());
            modelBuilder.ApplyConfiguration(new OrderEntityConfigs());
            modelBuilder.ApplyConfiguration(new OrderStatusEntityConfigs());
            modelBuilder.ApplyConfiguration(new ItemEntityConfigs());

            modelBuilder.HasDbFunction(() => UdfMethods.AverageVotes(default(int)));
            modelBuilder.HasDbFunction(() => UdfMethods.TotalOrderPrice(default(int)));
        }
    }
}
