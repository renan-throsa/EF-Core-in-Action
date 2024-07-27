using BookApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookApp.Data.Configs
{
    internal class BookCustomerEntityConfigs : IEntityTypeConfiguration<BookCustomer>
    {
        public void Configure(EntityTypeBuilder<BookCustomer> builder)
        {
            builder.HasKey(x => new { x.BookId, x.CustomerId });

            builder
            .HasOne(x => x.Book)
            .WithMany(y => y.WishList)
            .HasForeignKey(x => x.BookId);

            builder
            .HasOne(x => x.Customer)
            .WithMany(y => y.WishList)
            .HasForeignKey(x => x.CustomerId);


            List<BookCustomer> BookCustomers = new List<BookCustomer>() {
                new BookCustomer { CustomerId = 1, BookId = 1 },
                new BookCustomer { CustomerId = 2, BookId = 2 },
                new BookCustomer { CustomerId = 3, BookId = 3 },
                new BookCustomer { CustomerId = 4, BookId = 4 },
                new BookCustomer { CustomerId = 5, BookId = 5 },
                new BookCustomer { CustomerId = 6, BookId = 6 },
                new BookCustomer { CustomerId = 7, BookId = 7 },
                new BookCustomer { CustomerId = 8, BookId = 8 },
                new BookCustomer { CustomerId = 9, BookId = 9 },
                new BookCustomer { CustomerId = 10, BookId = 10 },
                new BookCustomer { CustomerId = 10, BookId = 11 },
                new BookCustomer { CustomerId = 1, BookId = 12 },
                new BookCustomer { CustomerId = 2, BookId = 13 },
                new BookCustomer { CustomerId = 2, BookId = 14 },
                new BookCustomer { CustomerId = 4, BookId = 15 },
                new BookCustomer { CustomerId = 5, BookId = 16 },
            };

            builder.HasData(BookCustomers);
        }
    }
}
