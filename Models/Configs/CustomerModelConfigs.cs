using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace BookApp.Models.Configs
{
    public class CustomerModelConfigs : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(x => x.FullName).HasComputedColumnSql("[FirstName] + ' ' + [LastName]", stored: true);
            builder.HasMany(x => x.Reviews).WithOne(y => y.Customer);

            List<Customer> customers = new List<Customer>
            {
                new Customer() { CustomerId = 1, FirstName = "John", LastName = "Smith" },
                new Customer() { CustomerId = 2, FirstName = "Jane", LastName = "Doe" },
                new Customer() { CustomerId = 3, FirstName = "Bob", LastName = "Johnson" },
                new Customer() { CustomerId = 4, FirstName = "Sally", LastName = " Smith" },
                new Customer() { CustomerId = 5, FirstName = "Samuel", LastName = " Jackson" },
                new Customer() { CustomerId = 6, FirstName = "Emily", LastName = " Williams" },
                new Customer() { CustomerId = 7, FirstName = "David", LastName = " Anderson" },
                new Customer() { CustomerId = 8, FirstName = "Rachel", LastName = "Davis" },
                new Customer() { CustomerId = 9, FirstName = "Mark", LastName = "Thompson" },
                new Customer() { CustomerId = 10, FirstName = "Adam", LastName = "Walker" }
            };

            builder.HasData(customers);
        }
    }
}
