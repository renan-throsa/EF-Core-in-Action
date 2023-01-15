using AutoMapper;
using BookApp.Data;
using BookApp.Models;
using BookApp.Models.DTOS;
using BookApp.Utils;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BookApp
{
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

        static void BookAverageVotes()
        {
            using var context = new AppBookContext();
            var bookAndVotes = context.Books.Select(x => new BookDTO
            {
                BookId = x.BookId,
                Title = x.Title,
                AveVotes = UdfMethods.AverageVotes(x.BookId)
            }).ToList();

            System.Console.WriteLine("");
            foreach (var item in bookAndVotes)
            {
                System.Console.WriteLine($"{item.Title} : {item.AveVotes}");
            }
        }
        static void Main(string[] args)
        {
            using var context = new AppBookContext();
            var orders = context.Ordes.ToList();
            foreach (var item in orders)
            {
                System.Console.WriteLine(item.OrderNumber);
               
            }
        }
    }
}
