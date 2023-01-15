using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace BookApp.Models.Configs
{
    internal class AuthorModelConfig : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            List<Author> authors = new List<Author>();

            authors.Add(new Author() { AuthorId = 1, Name = "Jane Austen", WebUrl = "https://www.janeausten.org/" });
            authors.Add(new Author() { AuthorId = 2, Name = "William Shakespeare", WebUrl = "https://www.shakespeare.org.uk/" });
            authors.Add(new Author() { AuthorId = 3, Name = "Charles Dickens", WebUrl = "https://www.charlesdickensmuseum.com/" });
            authors.Add(new Author() { AuthorId = 4, Name = "J.R.R. Tolkien", WebUrl = "https://www.tolkiensociety.org/" });
            authors.Add(new Author() { AuthorId = 5, Name = "Mark Twain", WebUrl = "https://www.marktwainhouse.org/" });
            authors.Add(new Author() { AuthorId = 6, Name = "Leo Tolstoy", WebUrl = "https://www.tolstoy.ru/en/" });
            authors.Add(new Author() { AuthorId = 7, Name = "F. Scott Fitzgerald", WebUrl = "https://www.fscottfitzgerald.org/" });
            authors.Add(new Author() { AuthorId = 8, Name = "Ernest Hemingway", WebUrl = "https://www.ernesthemingwayhome.com/" });
            authors.Add(new Author() { AuthorId = 9, Name = "John Steinbeck", WebUrl = "https://www.johnsteinbeck.org/" });
            authors.Add(new Author() { AuthorId = 10, Name = "Mary Shelley", WebUrl = "https://www.maryshelley.org/" });



            builder.HasData(authors);
        }
    }
}
