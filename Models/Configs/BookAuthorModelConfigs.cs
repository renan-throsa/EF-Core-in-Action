using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace BookApp.Models.Configs
{
    public class BookAuthorModelConfigs : IEntityTypeConfiguration<BookAuthor>
    {
        public void Configure(EntityTypeBuilder<BookAuthor> builder)
        {
            builder.HasKey(x => new { x.BookId, x.AuthorId });

            builder
            .HasOne(x => x.Book)
            .WithMany(y => y.Authors)
            .HasForeignKey(x => x.BookId);

            builder
            .HasOne(x => x.Author)
            .WithMany(y => y.Books)
            .HasForeignKey(x => x.AuthorId);

            List<BookAuthor> bookauthors = new List<BookAuthor>()
            {
                new BookAuthor{BookId=1,AuthorId=1},
                new BookAuthor{BookId=2,AuthorId=2},
                new BookAuthor{BookId=3,AuthorId=3},
                new BookAuthor{BookId=3,AuthorId=4},
                new BookAuthor{BookId=4,AuthorId=4},
                new BookAuthor{BookId=5,AuthorId=5},
                new BookAuthor{BookId=6,AuthorId=6},
                new BookAuthor{BookId=7,AuthorId=7},
                new BookAuthor{BookId=8,AuthorId=8},
                new BookAuthor{BookId=9,AuthorId=8},
                new BookAuthor{BookId=10,AuthorId=9},
                new BookAuthor{BookId=11,AuthorId=9},
                new BookAuthor{BookId=12,AuthorId=10},
                new BookAuthor{BookId=12,AuthorId=7},
                new BookAuthor{BookId=13,AuthorId=7},
                new BookAuthor{BookId=14,AuthorId=9},
                new BookAuthor{BookId=15,AuthorId=10},
                new BookAuthor{BookId=16,AuthorId=3},
                new BookAuthor{BookId=17,AuthorId=2},

            };

            builder.HasData(bookauthors);
        }
    }
}
