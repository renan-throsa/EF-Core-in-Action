﻿using BookApp.Data.Configs;
using BookApp.Data.Utils;
using BookApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookApp.Data.Contexts
{
    public class SqlContext : DbContext
    {
        private readonly string _connectionString;

        public DbSet<Book> Books { get; init; }
        public DbSet<Review> Reviews { get; init; }
        public DbSet<Author> Authors { get; init; }
        public DbSet<PriceOffer> PriceOffers { get; init; }
        public DbSet<Tag> Tags { get; init; }
        public DbSet<Order> Orders { get; init; }
        public DbSet<Item> Items { get; init; }
        public DbSet<Customer> Customers { get; init; }
        
        public SqlContext(string connectionString = "Server=.\\SQLEXPRESS;Database=BooksApp;Trusted_Connection=true;TrustServerCertificate=true;")
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .EnableSensitiveDataLogging()
                .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
                .UseSqlServer(_connectionString);

            base.OnConfiguring(optionsBuilder);
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
