using BookApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.Bson.Serialization;
using MongoDB.EntityFrameworkCore.Extensions;


namespace BookApp.Data.Configs
{
    internal class BookViewModelConfig : IEntityTypeConfiguration<BookViewModel>
    {
        public void Configure(EntityTypeBuilder<BookViewModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToCollection("Books");
            //builder.HasData(getList()); // Not adding for some reason.
        }

        private IEnumerable<BookViewModel> getList()
        {
            string jsonString = """

                                [{
                  "_id": {
                    "$oid": "66a7a483737f8f497f2589a3"
                  },
                  "AuthorsName": "Jane Austen",
                  "AveStars": 5,
                  "BookId": 1,
                  "Price": 40.9900016784668,
                  "PromotionNewPrice": 36.89099884033203,
                  "PromotionPromotionalText": "Xmas Season Offer!",
                  "PublishedOn": {
                    "$date": "2008-08-01T03:00:00.000Z"
                  },
                  "Tags": "Agile, Algorithms, Best Practices",
                  "Title": "Clean Code: A Handbook of Agile Software Craftsmanship"
                },
                {
                  "_id": {
                    "$oid": "66a7a483737f8f497f2589a4"
                  },
                  "AuthorsName": "William Shakespeare",
                  "AveStars": 4,
                  "BookId": 2,
                  "Price": 35.9900016784668,
                  "PromotionNewPrice": 28.792001724243164,
                  "PromotionPromotionalText": "Xmas Season Offer!",
                  "PublishedOn": {
                    "$date": "1999-10-20T03:00:00.000Z"
                  },
                  "Tags": "Best Practices, Career Advancement, Clean Code",
                  "Title": "The Pragmatic Programmer: From Journeyman to Master"
                },
                {
                  "_id": {
                    "$oid": "66a7a483737f8f497f2589a5"
                  },
                  "AuthorsName": "Charles Dickens, J.R.R. Tolkien",
                  "AveStars": 3,
                  "BookId": 3,
                  "Price": 33.9900016784668,
                  "PromotionNewPrice": 25.49250030517578,
                  "PromotionPromotionalText": "Xmas Season Offer!",
                  "PublishedOn": {
                    "$date": "2015-07-01T03:00:00.000Z"
                  },
                  "Tags": "Computer Programming, Computer Science, Compiler Design",
                  "Title": "Cracking the Coding Interview: 189 Programming Questions and Solutions"
                },
                {
                  "_id": {
                    "$oid": "66a7a483737f8f497f2589a6"
                  },
                  "AuthorsName": "J.R.R. Tolkien",
                  "AveStars": 2,
                  "BookId": 4,
                  "Price": 45.9900016784668,
                  "PromotionNewPrice": 56.99250030517578,
                  "PromotionPromotionalText": "Xmas Season Offer!",
                  "PublishedOn": {
                    "$date": "1995-10-01T03:00:00.000Z"
                  },
                  "Tags": "Algorithms, C Programming, Data Structures",
                  "Title": "Design Patterns: Elements of Reusable Object-Oriented Software"
                },
                {
                  "_id": {
                    "$oid": "66a7a483737f8f497f2589a7"
                  },
                  "AuthorsName": "Mark Twain",
                  "AveStars": 5,
                  "BookId": 5,
                  "Price": 50.9900016784668,
                  "PromotionNewPrice": 30.59400177001953,
                  "PromotionPromotionalText": "Xmas Season Offer!",
                  "PublishedOn": {
                    "$date": "2004-06-09T03:00:00.000Z"
                  },
                  "Tags": "Best Practices, Clean Code, Design Patterns",
                  "Title": "Code Complete: A Practical Handbook of Software Construction"
                },
                {
                  "_id": {
                    "$oid": "66a7a483737f8f497f2589a8"
                  },
                  "AuthorsName": "Leo Tolstoy",
                  "AveStars": 2.5,
                  "BookId": 6,
                  "Price": 35.9900016784668,
                  "PromotionNewPrice": 26.99250030517578,
                  "PromotionPromotionalText": "Xmas Season Offer!",
                  "PublishedOn": {
                    "$date": "2008-05-08T03:00:00.000Z"
                  },
                  "Tags": "Best Practices, Java, JavaScript",
                  "Title": "Effective Java"
                },
                {
                  "_id": {
                    "$oid": "66a7a483737f8f497f2589a9"
                  },
                  "AuthorsName": "F. Scott Fitzgerald",
                  "AveStars": 4,
                  "BookId": 7,
                  "Price": 25.989999771118164,
                  "PromotionNewPrice": 0,
                  "PromotionPromotionalText": null,
                  "PublishedOn": {
                    "$date": "2008-05-01T03:00:00.000Z"
                  },
                  "Tags": "JavaScript, Job Preparation, Object-Oriented Design",
                  "Title": "JavaScript: The Good Parts"
                },
                {
                  "_id": {
                    "$oid": "66a7a483737f8f497f2589aa"
                  },
                  "AuthorsName": "Ernest Hemingway",
                  "AveStars": 3,
                  "BookId": 8,
                  "Price": 60.9900016784668,
                  "PromotionNewPrice": 30.4950008392334,
                  "PromotionPromotionalText": "Special Offer!",
                  "PublishedOn": {
                    "$date": "2009-07-31T03:00:00.000Z"
                  },
                  "Tags": "Agile, Algorithms, Data Structures",
                  "Title": "Introduction to Algorithms"
                },
                {
                  "_id": {
                    "$oid": "66a7a483737f8f497f2589ab"
                  },
                  "AuthorsName": "Ernest Hemingway",
                  "AveStars": 2,
                  "BookId": 9,
                  "Price": 80.98999786376953,
                  "PromotionNewPrice": 60.74250030517578,
                  "PromotionPromotionalText": "Xmas Season Offer!",
                  "PublishedOn": {
                    "$date": {
                      "$numberLong": "-63151200000"
                    }
                  },
                  "Tags": "Best Practices, Clean Code, Programming Language",
                  "Title": "The Art of Computer Programming"
                },
                {
                  "_id": {
                    "$oid": "66a7a483737f8f497f2589ac"
                  },
                  "AuthorsName": "John Steinbeck",
                  "AveStars": 2,
                  "BookId": 10,
                  "Price": 20.989999771118164,
                  "PromotionNewPrice": 15.742500305175781,
                  "PromotionPromotionalText": "Xmas Season Offer!",
                  "PublishedOn": {
                    "$date": "1995-08-01T03:00:00.000Z"
                  },
                  "Tags": "Best Practices, Programming Languages, Project Management",
                  "Title": "The Mythical Man-Month: Essays on Software Engineering"
                },
                {
                  "_id": {
                    "$oid": "66a7a483737f8f497f2589ad"
                  },
                  "AuthorsName": "John Steinbeck",
                  "AveStars": null,
                  "BookId": 11,
                  "Price": 70.98999786376953,
                  "PromotionNewPrice": 53.24250030517578,
                  "PromotionPromotionalText": "Xmas Season Offer!",
                  "PublishedOn": {
                    "$date": "2006-07-15T03:00:00.000Z"
                  },
                  "Tags": "Algorithms, C Programming, Programming Language",
                  "Title": "Compilers: Principles, Techniques, and Tools"
                },
                {
                  "_id": {
                    "$oid": "66a7a483737f8f497f2589ae"
                  },
                  "AuthorsName": "F. Scott Fitzgerald, Mary Shelley",
                  "AveStars": 3,
                  "BookId": 12,
                  "Price": 30.989999771118164,
                  "PromotionNewPrice": 23.24250030517578,
                  "PromotionPromotionalText": "Xmas Season Offer!",
                  "PublishedOn": {
                    "$date": "1988-02-22T03:00:00.000Z"
                  },
                  "Tags": "Computer Programming",
                  "Title": "The C Programming Language"
                },
                {
                  "_id": {
                    "$oid": "66a7a483737f8f497f2589af"
                  },
                  "AuthorsName": "F. Scott Fitzgerald",
                  "AveStars": 2,
                  "BookId": 13,
                  "Price": 24.989999771118164,
                  "PromotionNewPrice": 0,
                  "PromotionPromotionalText": null,
                  "PublishedOn": {
                    "$date": "2013-03-14T03:00:00.000Z"
                  },
                  "Tags": "",
                  "Title": "Big Data: A Revolution That Will Transform How We Live, Work, and Think"
                },
                {
                  "_id": {
                    "$oid": "66a7a483737f8f497f2589b0"
                  },
                  "AuthorsName": "John Steinbeck",
                  "AveStars": 5,
                  "BookId": 14,
                  "Price": 39.9900016784668,
                  "PromotionNewPrice": 0,
                  "PromotionPromotionalText": null,
                  "PublishedOn": {
                    "$date": "2015-11-09T02:00:00.000Z"
                  },
                  "Tags": "",
                  "Title": "Python for Data Science Handbook"
                },
                {
                  "_id": {
                    "$oid": "66a7a483737f8f497f2589b1"
                  },
                  "AuthorsName": "Mary Shelley",
                  "AveStars": 2,
                  "BookId": 15,
                  "Price": 49.9900016784668,
                  "PromotionNewPrice": 0,
                  "PromotionPromotionalText": null,
                  "PublishedOn": {
                    "$date": "2017-03-16T03:00:00.000Z"
                  },
                  "Tags": "",
                  "Title": "Designing Data-Intensive Applications: The Big Ideas Behind Reliable, Scalable, and Maintainable Systems"
                },
                {
                  "_id": {
                    "$oid": "66a7a483737f8f497f2589b2"
                  },
                  "AuthorsName": "Charles Dickens",
                  "AveStars": 4,
                  "BookId": 16,
                  "Price": 49.9900016784668,
                  "PromotionNewPrice": 0,
                  "PromotionPromotionalText": null,
                  "PublishedOn": {
                    "$date": "2019-06-14T03:00:00.000Z"
                  },
                  "Tags": "",
                  "Title": "Cloud Native Infrastructure: Patterns for Scalable, Reliable Services"
                },
                {
                  "_id": {
                    "$oid": "66a7a483737f8f497f2589b3"
                  },
                  "AuthorsName": "William Shakespeare",
                  "AveStars": 4.5,
                  "BookId": 17,
                  "Price": 39.9900016784668,
                  "PromotionNewPrice": 0,
                  "PromotionPromotionalText": null,
                  "PublishedOn": {
                    "$date": "2018-12-15T02:00:00.000Z"
                  },
                  "Tags": "",
                  "Title": "Artificial Intelligence with Python"
                }]

                """;

            return BsonSerializer.Deserialize<IEnumerable<BookViewModel>>(jsonString);
        }
    }
}
