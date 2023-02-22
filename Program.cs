using AutoMapper;
using BookApp.Data;
using BookApp.Models;
using BookApp.Models.DTOS;
using BookApp.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace BookApp
{
    public sealed class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
    }


    class Program
    {
        static void GetBooksList()
        {
            var configuration = new MapperConfiguration(cfg =>
                        {
                            cfg.CreateMap<Review, ReviewDTO>().ReverseMap();
                            cfg.CreateMap<Book, BookDTO>().ReverseMap();
                        });

            configuration.AssertConfigurationIsValid();

            var mapper = configuration.CreateMapper();

            using var context = new AppBookContext();
            var query = context.Books.Include(x => x.Promotion).Include(x => x.Reviews);
            var dtoList = mapper.Map<IEnumerable<BookDTO>>(query.ToList());
            foreach (var b in dtoList)
            {
                System.Console.WriteLine($"{b.Title} for {b.PromotionNewPrice}");
                System.Console.WriteLine();
                foreach (var r in b.Reviews)
                {
                    System.Console.WriteLine($"     {r.VoterName} says: {r.Comment}");
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
            var b  = context.Books.SingleOrDefault(x=> x.ISBN.Equals("078-0201616224"));
            var query = context.Authors.Include(x => x.Books.Where(x => x.Book.Title.StartsWith("T"))).ToQueryString();
            Console.WriteLine(b);
            Console.WriteLine(query);
        }

        static void Main(string[] args)
        {
            //BookAverageVotesWithLinq();
            BookAverageVotesWithMethod();
        }
    }
}
