using BookApp.Data.Contexts;
using BookApp.Data.Utils;
using BookApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace BookApp.Test
{
    public class BooktUnitTest
    {              

        [Fact]
        public void BookAverageVotesWithMethodOk()
        {
            using var context = new SqlContext($"Server=.\\SQLEXPRESS;Database=BooksAppTest_{nameof(BookAverageVotesWithMethodOk)};Trusted_Connection=True;");
            context.Database.Migrate();

            var bookAndVotes = context.Books.Where(x=> x.BookId == 1).Select(x => new BookViewModel
            {
                BookId = x.BookId,
                Title = x.Title,
                AveStars = UdfMethods.AverageVotes(x.BookId)
            }).First();

            context.Database.EnsureDeleted();
            Assert.Equal(5, bookAndVotes.AveStars);
            
        }

        [Fact]
        public void BookAverageVotesWithLinqOk()
        {
            using var context = new SqlContext($"Server=.\\SQLEXPRESS;Database=BooksAppTest_{nameof(BookAverageVotesWithLinqOk)};Trusted_Connection=True;");
            context.Database.Migrate();

            var bookAndVotes = context.Books.Where(x => x.BookId == 1).Select(x => new BookViewModel
            {
                BookId = x.BookId,
                Title = x.Title,
                AveStars = (double?)x.Reviews.Average(y => y.NumStars)
            }).First();

            context.Database.EnsureDeleted();
            Assert.Equal(5, bookAndVotes.AveStars);

        }
    }
}