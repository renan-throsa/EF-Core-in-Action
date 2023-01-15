using System;
using System.Collections.Generic;
using System.Linq;
using BookApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace BookApp.Data
{
    public static class Commands
    {
        public static void ListAll()
        {
            using (var db = new AppBookContext())
            {
                foreach (var
                    book
                    in
                    db
                        .Books
                        .AsNoTracking()
                        .Include(book => book.Authors)
                        .ThenInclude(author => author.Author)
                        .Distinct()
                )
                {
                    foreach (var bookAuthor in book.Authors)
                    {
                        Console.WriteLine();
                        var webUrl =
                            bookAuthor.Author.WebUrl ?? "- no web url given -";
                        Console.WriteLine($"{book.Title} by {bookAuthor.Author.Name}");
                        Console
                            .WriteLine("     Published on " +
                            $"{book.PublishedOn:dd-MMM-yyyy}. {webUrl}");
                    }
                }
            }
        }

        public static bool WipeCreateSeed(bool onlyIfNoDatabase = false)
        {
            using (var db = new AppBookContext())
            {
                if (
                    onlyIfNoDatabase &&
                    (
                    db.GetService<IDatabaseCreator>() as
                    RelationalDatabaseCreator
                    ).Exists()
                ) return false;

                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                if (!db.Books.Any())
                {
                    WriteTestData(db);
                    Console.WriteLine("Seeded database");
                }
            }

            return true;
        }

        public static void WriteTestData(this AppBookContext db)
        {
            #region Tags
            var dotnet = new Tag() { TagName = "Microsoft & .NET" };
            var csharp = new Tag() { TagName = "C#" };
            var fsharp = new Tag() { TagName = "F#" };
            var dev = new Tag() { TagName = "Development" };
            var prog = new Tag() { TagName = "Programming" };
            var jav = new Tag() { TagName = "JavaScript" };
            var web = new Tag() { TagName = "Web" };


            var tags = new List<Tag>()                           {
                    dotnet,
                    csharp,
                    fsharp,
                    dev,
                    prog,
                    jav,web
                          };

            db.Tags.AddRange(tags);
            #endregion

            #region Authors
            var martinFowler =
                           new Author
                           {
                               Name = "Martin Fowler",
                               WebUrl = "http://martinfowler.com/"
                           };

            var ericEvans =
                new Author
                {
                    Name = "Eric Evans",
                    WebUrl = "http://domainlanguage.com/"
                };
            var christianHorsdal =
                new Author { Name = "Christian Horsdal Gammelgaard" };
            var jonSkeet = new Author { Name = "Jon Skeet" };

            var dustinMetzgar = new Author { Name = "Dustin Metzgar" };

            var enricoBuonanno = new Author { Name = "Enrico Buonanno" };

            var johnResig = new Author { Name = "John Resig" };
            var bearBibeault = new Author { Name = "Bear Bibeault" };
            var josipMaras = new Author { Name = "Josip Maras" };

            var authors =
                new List<Author>()
                {
                    martinFowler,
                    ericEvans,
                    christianHorsdal,
                    jonSkeet,
                    dustinMetzgar,
                    enricoBuonanno
                };

            db.Authors.AddRange(authors);
            #endregion

            #region Books
            var books =
                new List<Book> {
                    new Book {
                        Title =
                            "Secrets of the JavaScript Ninja, Second Edition",
                        Description =
                            "Essential reading for developers of any discipline ... with powerful techniques to improve your JavaScript.",
                        PublishedOn = new DateTime(2016, 8, 1),
                        Price = 35.0F,
                        Authors =
                            new List<BookAuthor>()
                            {
                                new BookAuthor() { Author = johnResig },
                                new BookAuthor() { Author = bearBibeault },
                                new BookAuthor() { Author = josipMaras }                            },


                    },
                    new Book {
                        Title = "Refactoring",
                        Description = "Improving the design of existing code",
                        PublishedOn = new DateTime(1999, 7, 8),
                        Price = 45.0F,
                    },
                    new Book {
                        Title =
                            "Patterns of Enterprise Application Architecture",
                        Description =
                            "Written in direct response to the stiff challenges",
                        PublishedOn = new DateTime(2002, 11, 15),
                        Price = 32.0F,
                        Promotion = new PriceOffer() { NewPrice = 22.0f },

                    },
                    new Book {
                        Title = "Domain-Driven Design",
                        Description =
                            "Linking business needs to software design",
                        PublishedOn = new DateTime(2003, 8, 30),
                        Price = 28.0F,
                        Promotion = new PriceOffer() { NewPrice = 10.0f },
                    },
                    new Book {
                        Title = "Microservices in .NET, 2nd ed.",
                        Description =
                            "A comprehensive guide to building microservice applications using the .NET stack. The revised edition teaches you practical microservices development skills using ASP.NET.",
                        PublishedOn = new DateTime(2057, 1, 1),
                        Price = 50.0F,
                        Promotion = new PriceOffer() { NewPrice = 30.0f },
                    },
                    new Book {
                        Title = "C# in Depth, Fourth Edition",
                        Description =
                            "This guide is your key to unlocking the powerful new features added to the language in C# 5, 6, and 7. Master asynchronous functions, expression-bodied members, and much more.",
                        PublishedOn = new DateTime(2019, 3, 1),
                        Price = 23.0F,
                        Promotion = new PriceOffer() { NewPrice = 20.0f },
                    },
                    new Book {
                        Title = ".NET Core in Action",
                        Description =
                            "Shows .NET developers how to build professional software applications with .NET Core. Learn how to convert existing .NET code to work on multiple platforms or how to start new projects with knowledge of the tools and capabilities of .NET Core.",
                        PublishedOn = new DateTime(2018, 6, 1),
                        Price = 35.0F,
                        Authors =
                            new List<BookAuthor>()
                            { new BookAuthor() { Author = dustinMetzgar } },
                        Promotion = new PriceOffer() { NewPrice = 30.0f },

                    },
                    new Book {
                        Title = "Functional Programming in C#, 2nd ed.",
                        Description =
                            "In Functional Programming in C#, Second Edition you will learn how to: Use higher-order functions to reduce duplication and do more with less code Use pure functions to write code that is easy to test and optimize",
                        PublishedOn = new DateTime(2021, 12, 1),
                        Price = 30.0F,
                        Promotion = new PriceOffer() { NewPrice = 25.0f },

                    }
                };

            db.Books.AddRange(books);
            #endregion
            db.SaveChanges();
        }
    }
}
