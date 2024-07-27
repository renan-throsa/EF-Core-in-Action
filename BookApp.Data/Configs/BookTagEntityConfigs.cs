using BookApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookApp.Data.Configs
{
    public class BookTagEntityConfigs : IEntityTypeConfiguration<BookTag>
    {
        public void Configure(EntityTypeBuilder<BookTag> builder)
        {
            builder.HasKey(x => new { x.BookId, x.TagId });

            builder
            .HasOne(x => x.Book)
            .WithMany(y => y.Tags)
            .HasForeignKey(x => x.BookId);

            builder
            .HasOne(x => x.Tag)
            .WithMany(y => y.Books)
            .HasForeignKey(x => x.TagId);

            List<BookTag> BookTags = new List<BookTag>()
{
    new BookTag() { BookId = 1, TagId = 1, },
    new BookTag() { BookId = 1, TagId = 2, },
    new BookTag() { BookId = 1, TagId = 3, },

    new BookTag() { BookId = 2, TagId = 3, },
    new BookTag() { BookId = 2, TagId = 4, },
    new BookTag() { BookId = 2, TagId = 5, },

    new BookTag() { BookId = 3, TagId = 6, },
    new BookTag() { BookId = 3, TagId = 7, },
    new BookTag() { BookId = 3, TagId = 8, },

    new BookTag() { BookId = 4, TagId = 2, },
    new BookTag() { BookId = 4, TagId = 9, },
    new BookTag() { BookId = 4, TagId = 10, },

    new BookTag() { BookId = 5, TagId = 3, },
    new BookTag() { BookId = 5, TagId = 5, },
    new BookTag() { BookId = 5, TagId = 11,},

    new BookTag() { BookId = 6, TagId = 12,},
    new BookTag() { BookId = 6, TagId = 3, },
    new BookTag() { BookId = 6, TagId = 13,},

    new BookTag() { BookId = 7, TagId = 13, },
    new BookTag() { BookId = 7, TagId = 14 },
    new BookTag() { BookId = 7, TagId = 15,},

    new BookTag() { BookId = 8, TagId = 1, },
    new BookTag() { BookId = 8, TagId = 2, },
    new BookTag() { BookId = 8, TagId = 10 },


new BookTag() { BookId = 9, TagId = 3, },
new BookTag() { BookId = 9, TagId = 5, },
new BookTag() { BookId = 9, TagId = 16,},

new BookTag() { BookId = 10,TagId = 3, },
new BookTag() { BookId = 10,TagId = 17, },
new BookTag() { BookId = 10,TagId = 18, },

new BookTag() { BookId = 11,TagId = 2, },
new BookTag() { BookId = 11,TagId = 9, },
new BookTag() { BookId = 11,TagId = 16, },

new BookTag() { BookId = 12,TagId = 6, },

            };


            builder.HasData(BookTags);
        }
    }
}
