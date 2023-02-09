using BookApp.Models;
using BookApp.Models.Configs;
using BookApp.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace BookApp.Data
{

    public class AppBookContext : DbContext
    {
        private readonly string ConnectionString;

        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Review> Reviews { get; set; } = null!;
        public DbSet<Author> Authors { get; set; } = null!;
        public DbSet<PriceOffer> PriceOffers { get; set; } = null!;
        public DbSet<Tag> Tags { get; set; } = null!;
        public DbSet<Order> Ordes { get; set; } = null!;
        public DbSet<Item> Items { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;

        public AppBookContext()

        {
            ConnectionString = "Server=.\\SQLEXPRESS;Database=BookApp;Trusted_Connection=True;";
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
            modelBuilder.ApplyConfiguration(new AuthorModelConfig());
            modelBuilder.ApplyConfiguration(new BookModelConfigs());
            modelBuilder.ApplyConfiguration(new ReviewModelConfig());
            modelBuilder.ApplyConfiguration(new CustomerModelConfigs());
            modelBuilder.ApplyConfiguration(new TagModelConfigs());
            modelBuilder.ApplyConfiguration(new BookAuthorModelConfigs());
            modelBuilder.ApplyConfiguration(new BookTagModelConfigs());
            modelBuilder.ApplyConfiguration(new OrderModelConfigs());
            modelBuilder.ApplyConfiguration(new OrderStatusModelConfigs());
            modelBuilder.ApplyConfiguration(new ItemModelConfigs());

            modelBuilder.HasDbFunction(() => UdfMethods.AverageVotes(default(int)));
            modelBuilder.HasDbFunction(() => UdfMethods.TotalOrderPrice(default(int)));            

        }
    }
}
