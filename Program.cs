using AutoMapper;
using BookApp.Data;
using BookApp.Models;
using BookApp.Models.DTOS;
using BookApp.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookApp
{

    class Program
    {

        static void Main(string[] args)
        {
            //BookAverageVotesWithLinq();
            //BookAverageVotesWithMethod();

            //FromSqlRawQueries();
            bestWayToUpdate();
        }

        static void GetBooksList()
        {
            var configuration = new MapperConfiguration(cfg =>
                        {
                            cfg.CreateMap<Review, ReviewDTO>().ReverseMap();
                            cfg.CreateMap<PriceOffer, BookDTO>().ReverseMap();
                        });

            configuration.AssertConfigurationIsValid();

            var mapper = configuration.CreateMapper();

            using var context = new AppBookContext();
            var query = context.Books.Include(x => x.Promotion).Include(x => x.Reviews);
            var dtoList = mapper.Map<IEnumerable<BookDTO>>(query.ToList());

            foreach (var b in dtoList)
            {
                Console.WriteLine($"{b.Title} for {b.PromotionNewPrice}");
                Console.WriteLine();
                foreach (var r in b.Reviews)
                {
                    Console.WriteLine($"     {r.VoterName} says: {r.Comment}");
                }
            }
        }

        static void BookAverageVotesWithMethod()
        {
            using var context = new AppBookContext();
            var bookAndVotes = context.Books.Select(x => new BookDTO
            {
                BookId = x.BookId,
                Title = x.Title,
                AveVotes = UdfMethods.AverageVotes(x.BookId)
            }).ToList();

            Console.WriteLine("");
            foreach (var item in bookAndVotes)
            {
                Console.WriteLine($"{item.Title} : {item.AveVotes}");
            }
        }

        static void BookAverageVotesWithLinq()
        {
            using var context = new AppBookContext();
            var books = context.Books.Select(x => new { Title = x.Title, Evaluation = (double?)x.Reviews.Average(y => y.NumStars) });
            Console.WriteLine("");
            foreach (var item in books)
            {
                Console.WriteLine($"{item.Title} - {item.Evaluation}");

            }
        }

        static void ToQueryString()
        {
            using var context = new AppBookContext();
            var query = context.Books.Select(x => new { Title = x.Title, Evaluation = (double?)x.Reviews.Average(y => y.NumStars) });
            var sql = query.ToQueryString();
            Console.WriteLine(sql);
        }


        static void FilteredQueries()
        {
            using var context = new AppBookContext();
            var b = context.Books.SingleOrDefault(x => x.ISBN.Equals("078-0201616224"));
            var query = context.Authors.Include(x => x.Books.Where(x => x.Book.Title.StartsWith("T"))).ToQueryString();
            Console.WriteLine(b);
            Console.WriteLine(query);
        }

        static void FromSqlRawQueries()
        {
            using var context = new AppBookContext();
            double minStars = 4;
            var bookAndVotes = context.Books
                .FromSqlRaw(
                   "SELECT * FROM Books b WHERE (SELECT AVG(CAST([NumStars] AS float)) FROM dbo.Reviews AS r WHERE b.BookId = r.BookId) >= {0}", minStars)
                .Include(r => r.Reviews)
                .AsNoTracking()
                .ToList();


            Console.WriteLine("");
            foreach (var item in bookAndVotes)
            {
                Console.WriteLine($"{item.Title}");
            }
        }


        static void bestWayToUpdate()
        {
            using var context = new AppBookContext();
            var b = context.Books.AsNoTracking().First();
            b.ISBN = "978-0134685992";

            context.Books.Update(b);
            context.SaveChanges();
        }

    }
}
