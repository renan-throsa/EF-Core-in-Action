using BookApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookApp.Data.Configs
{
    internal class AuthorEntityConfig : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {            
            builder.Property(x => x.Name).IsRequired().HasMaxLength(128);

            List<Author> authors = new List<Author>()
            {

            new Author() { AuthorId = 1, Name = "Jane Austen", WebUrl = "https://www.janeausten.org/" },
            new Author() { AuthorId = 2, Name = "William Shakespeare", WebUrl = "https://www.shakespeare.org.uk/" },
            new Author() { AuthorId = 3, Name = "Charles Dickens", WebUrl = "https://www.charlesdickensmuseum.com/" },
            new Author() { AuthorId = 4, Name = "J.R.R. Tolkien", WebUrl = "https://www.tolkiensociety.org/" },
            new Author() { AuthorId = 5, Name = "Mark Twain", WebUrl = "https://www.marktwainhouse.org/" },
            new Author() { AuthorId = 6, Name = "Leo Tolstoy", WebUrl = "https://www.tolstoy.ru/en/" },
            new Author() { AuthorId = 7, Name = "F. Scott Fitzgerald", WebUrl = "https://www.fscottfitzgerald.org/" },
            new Author() { AuthorId = 8, Name = "Ernest Hemingway", WebUrl = "https://www.ernesthemingwayhome.com/" },
            new Author() { AuthorId = 9, Name = "John Steinbeck", WebUrl = "https://www.johnsteinbeck.org/" },
            new Author() { AuthorId = 10, Name = "Mary Shelley", WebUrl = "https://www.maryshelley.org/" }

            };



            builder.HasData(authors);
        }
    }
}
