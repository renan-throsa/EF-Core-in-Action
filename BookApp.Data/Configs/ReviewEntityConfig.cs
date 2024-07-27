using BookApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookApp.Data.Configs
{
    internal class ReviewEntityConfig : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.Property(x => x.Comment).IsRequired().HasMaxLength(256);
            builder.Property(x => x.CreatedOn).HasColumnType("datetime").HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.HasOne(x => x.Book).WithMany(y => y.Reviews);

            List<Review> reviews = new List<Review>()
            {
                new Review {
        ReviewId = 1,
        NumStars = 5,
        Comment = "Great book, easy to understand.",
        BookId = 1,
        CustomerId = 1,
    },
    new Review {
        ReviewId = 2,
        NumStars = 4,
        Comment = "Good information but could be more in-depth.",
        BookId = 2,
        CustomerId = 2,
    },
    new Review {
        ReviewId = 3,
        NumStars = 3,
        Comment = "Informative but could be more engaging",
        BookId = 3,
        CustomerId = 3,
    },
     new Review {
        ReviewId = 4,
        NumStars = 2,
        Comment = "Too basic for my needs",
        BookId = 4,
        CustomerId = 4,
    },
     new Review {
        ReviewId = 5,
        NumStars = 5,
        Comment = "Excellent resource for data science",
        BookId = 5,
        CustomerId = 5,
    },
      new Review {
        ReviewId = 6,
        NumStars = 1,
        Comment = "Poorly written, not useful",
        BookId = 6,
        CustomerId = 6,
    },
      new Review {
        ReviewId = 7,
        NumStars = 4,
        Comment = "Good introduction to AI",
        BookId = 17,
        CustomerId = 7,
    },
    new Review {
        ReviewId = 8,
        NumStars = 3,
        Comment = "Some good insights, but could be more comprehensive",
        BookId = 8,
        CustomerId = 8,
    },
    new Review {
        ReviewId = 9,
        NumStars = 5,
        Comment = "I love this book!",
        BookId = 1,
        CustomerId = 9,
    },
    new Review {
        ReviewId = 10,
        NumStars = 4,
        Comment = "Helpful guide for beginners",
        BookId = 7,
        CustomerId = 1,
    },
    new Review {
        ReviewId = 11,
        NumStars = 2,
        Comment = "Disappointing, not what I was expecting",
        BookId = 15,
        CustomerId = 2,
    },
    new Review {
        ReviewId = 12,
        NumStars = 5,
        Comment = "Great book, easy to understand",
        BookId = 17,
        CustomerId = 4,
    },
    new Review {
        ReviewId = 13,
        NumStars = 4,
        Comment = "Good read, helpful examples",
        BookId = 8,
        CustomerId = 5,
    },
    new Review {
        ReviewId = 14,
        NumStars = 3,
        Comment = "Informative but could be more engaging",
        BookId = 10,
        CustomerId = 6,
    },
    new Review {
        ReviewId = 15,
        NumStars = 2,
        Comment = "Too basic for my needs",
        BookId = 9,
        CustomerId = 7,
    },
    new Review {
        ReviewId = 16,
        NumStars = 1,
        Comment = "Poorly written, not useful",
        BookId = 10,
        CustomerId = 8,
    },
     new Review {
        ReviewId = 17,
        NumStars = 4,
        Comment = "Good introduction to Cloud Native Infrastructure",
        BookId = 16,
        CustomerId = 9,
    },
    new Review {
        ReviewId = 18,
        NumStars = 3,
        Comment = "Informative but could be more comprehensive",
        BookId = 12,
        CustomerId = 1,
    },
    new Review {
        ReviewId = 19,
        NumStars = 2,
        Comment = "Disappointing, not what I was expecting",
        BookId = 13,
        CustomerId = 2,
    },
    new Review {
        ReviewId = 20,
        NumStars = 5,
        Comment = "Excellent resource for data science",
        BookId = 14,
        CustomerId = 3,
    },
     new Review {
        ReviewId = 21,
        NumStars = 4,
        Comment = "Good introduction to Cloud Native Infrastructure",
        BookId = 6,
        CustomerId = 4,
    },
    new Review {
        ReviewId = 22,
        NumStars = 4,
        Comment = "Informative but could be more comprehensive",
        BookId = 7,
        CustomerId = 5,
    },
    new Review {
        ReviewId = 23,
        NumStars = 2,
        Comment = "Disappointing, not what I was expecting",
        BookId = 8,
        CustomerId = 6,
    },
    new Review {
        ReviewId =24,
        NumStars = 5,
        Comment = "Excellent resource for data science",
        BookId = 5,
        CustomerId = 7,
    }

            };

            builder.HasData(reviews);
        }
    }
}
