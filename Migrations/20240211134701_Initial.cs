﻿using System;
using BookApp.Utils;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            const string UdfAverageVotes = nameof(UdfMethods.AverageVotes);
            const string UdfTotalOrder = nameof(UdfMethods.TotalOrderPrice);

            migrationBuilder.Sql(
    $"CREATE FUNCTION {UdfAverageVotes} (@bookId int)" +
    @"  RETURNS float
      AS
      BEGIN
      DECLARE @result AS float
      SELECT @result = AVG(CAST([NumStars] AS float)) 
           FROM dbo.Reviews AS r
           WHERE @bookId = r.BookId
      RETURN @result
      END");

            migrationBuilder.Sql(
    $"CREATE FUNCTION {UdfTotalOrder} (@orderId int)" +
    @"  RETURNS float
      AS
      BEGIN
      DECLARE @result AS float
      SELECT @result = SUM(Items.BookPrice*Items.NumBooks) FROM Items WHERE Items.OrderId = @orderId
      RETURN @result
      END");

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    WebUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ISBN = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Available = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(101)", maxLength: 101, nullable: false, computedColumnSql: "[FirstName] + ' ' + [LastName]", stored: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    TagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TagId);
                });

            migrationBuilder.CreateTable(
                name: "BookAuthor",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthor", x => new { x.BookId, x.AuthorId });
                    table.ForeignKey(
                        name: "FK_BookAuthor_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthor_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PriceOffers",
                columns: table => new
                {
                    PriceOfferId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewPrice = table.Column<float>(type: "real", nullable: false),
                    PromotionalText = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceOffers", x => x.PriceOfferId);
                    table.ForeignKey(
                        name: "FK_PriceOffers_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookCustomer",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCustomer", x => new { x.BookId, x.CustomerId });
                    table.ForeignKey(
                        name: "FK_BookCustomer_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCustomer_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalPrice = table.Column<double>(type: "float", nullable: false, computedColumnSql: "dbo.TotalOrderPrice([OrderId])"),
                    OrderedOn = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    OrderNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumStars = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Reviews_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookTag",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookTag", x => new { x.BookId, x.TagId });
                    table.ForeignKey(
                        name: "FK_BookTag_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookTag_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumBooks = table.Column<short>(type: "smallint", nullable: false),
                    BookPrice = table.Column<double>(type: "float", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Items_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatus",
                columns: table => new
                {
                    OrderStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatus", x => x.OrderStatusId);
                    table.ForeignKey(
                        name: "FK_OrderStatus_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "Name", "WebUrl" },
                values: new object[,]
                {
                    { 1, "Jane Austen", "https://www.janeausten.org/" },
                    { 2, "William Shakespeare", "https://www.shakespeare.org.uk/" },
                    { 3, "Charles Dickens", "https://www.charlesdickensmuseum.com/" },
                    { 4, "J.R.R. Tolkien", "https://www.tolkiensociety.org/" },
                    { 5, "Mark Twain", "https://www.marktwainhouse.org/" },
                    { 6, "Leo Tolstoy", "https://www.tolstoy.ru/en/" },
                    { 7, "F. Scott Fitzgerald", "https://www.fscottfitzgerald.org/" },
                    { 8, "Ernest Hemingway", "https://www.ernesthemingwayhome.com/" },
                    { 9, "John Steinbeck", "https://www.johnsteinbeck.org/" },
                    { 10, "Mary Shelley", "https://www.maryshelley.org/" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Available", "Description", "ISBN", "ImageUrl", "Price", "PublishedOn", "Publisher", "Title" },
                values: new object[,]
                {
                    { 1, true, "A guide to writing clean and maintainable code", "978-0134685991", "https://images-na.ssl-images-amazon.com/images/I/41v0QiEwZ7L._SX397_BO1,204,203,200_.jpg", 40.99f, new DateTime(2008, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prentice Hall", "Clean Code: A Handbook of Agile Software Craftsmanship" },
                    { 2, true, "A guide to becoming a better programmer", "978-0201616224", "https://images-na.ssl-images-amazon.com/images/I/41yczzw6U0L._SX331_BO1,204,203,200_.jpg", 35.99f, new DateTime(1999, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Addison-Wesley Professional", "The Pragmatic Programmer: From Journeyman to Master" },
                    { 3, true, "A guide to preparing for technical interviews", "978-0984782857", "https://images-na.ssl-images-amazon.com/images/I/41rNjZBm3sL._SX331_BO1,204,203,200_.jpg", 33.99f, new DateTime(2015, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CareerCup", "Cracking the Coding Interview: 189 Programming Questions and Solutions" },
                    { 4, true, "Design Patterns is a modern classic in the literature of object-oriented development, offering timeless and elegant solutions to common problems in software design. It describes patterns for managing object creation, composing objects into larger structures, and coordinating control flow between objects.", "978-0201633610", "https://images-na.ssl-images-amazon.com/images/I/4124eHhdGDL._SX396_BO1,204,203,200_.jpg", 45.99f, new DateTime(1995, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Addison-Wesley Professional", "Design Patterns: Elements of Reusable Object-Oriented Software" },
                    { 5, true, "A guide to software construction principles and practices", "978-0735619670", "https://images-na.ssl-images-amazon.com/images/I/41yI1Gzv1aL._SX400_BO1,204,203,200_.jpg", 50.99f, new DateTime(2004, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Microsoft Press", "Code Complete: A Practical Handbook of Software Construction" },
                    { 6, false, "A guide to best practices for the Java programming language", "978-0321356680", "https://images-na.ssl-images-amazon.com/images/I/", 35.99f, new DateTime(2008, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Addison-Wesley Professional", "Effective Java" },
                    { 7, true, "This book provides a developer-level introduction along with more advanced and useful features of JavaScript. It covers concepts such as objects, functions, and arrays, and it examines features such as closures, inheritance, and automatic semicolon insertion.", "978-0596517748", "https://images-na.ssl-images-amazon.com/images/I/51e6YZU6bxL._SX379_BO1,204,203,200_.jpg", 25.99f, new DateTime(2008, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "O'Reilly Media", "JavaScript: The Good Parts" },
                    { 8, true, "A comprehensive introduction to algorithms and data structures", "978-0262033848", "https://images-na.ssl-images-amazon.com/images/I/51jJOuP--mL._SX398_BO1,204,203,200_.jpg", 60.99f, new DateTime(2009, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "MIT Press", "Introduction to Algorithms" },
                    { 9, true, "A comprehensive guide to computer programming", "978-0134685992", "https://images-na.ssl-images-amazon.com/images/I/51X5rQQ8-3L._SX405_BO1,204,203,200_.jpg", 80.99f, new DateTime(1968, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Addison-Wesley Professional", "The Art of Computer Programming" },
                    { 10, true, "Essays on software engineering and project management", "978-0201835953", "https://images-na.ssl-images-amazon.com/images/I/51OX1rsYvAL._SX331_BO1,204,203,200_.jpg", 20.99f, new DateTime(1995, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Addison-Wesley Professional", "The Mythical Man-Month: Essays on Software Engineering" },
                    { 11, true, "A guide to compiler design principles and techniques", "978-0321486813", "https://images-na.ssl-images-amazon.com/images/I/51KQc%2B9yJHL._SX379_BO1,204,203,200_.jpg", 70.99f, new DateTime(2006, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Addison-Wesley Professional", "Compilers: Principles, Techniques, and Tools" },
                    { 12, true, "A classic introduction to the C programming language", "978-0131103627", "https://images-na.ssl-images-amazon.com/images/I/51IS6N8BHPL._SX379_BO1,204,203,200_.jpg", 30.99f, new DateTime(1988, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prentice Hall", "The C Programming Language" },
                    { 13, true, "Big Data is a book that examines how data-driven technologies are transforming the way we live and work, and how they are creating new opportunities for individuals and organizations to generate value. It also looks at the risks and challenges of data-driven technologies, and how they can be managed.", "978-1491903996", null, 24.99f, new DateTime(2013, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "O'Reilly Media", "Big Data: A Revolution That Will Transform How We Live, Work, and Think" },
                    { 14, true, "Python for Data Science Handbook is a comprehensive introduction to the Python programming language, and its use in data science. It covers the essential tools for data science, including NumPy, Pandas, Matplotlib, and Scikit-learn, and also covers advanced topics such as machine learning and natural language processing.", "978-1119293347", null, 39.99f, new DateTime(2015, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wiley", "Python for Data Science Handbook" },
                    { 15, true, "Designing Data-Intensive Applications is a book that examines the principles and practices behind data-intensive systems. It covers topics such as data modeling, data storage, data processing, and data flow, and provides guidance on how to design and implement data-intensive systems that are reliable, scalable, and maintainable.", "978-1449373320", null, 49.99f, new DateTime(2017, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "O'Reilly Media", "Designing Data-Intensive Applications: The Big Ideas Behind Reliable, Scalable, and Maintainable Systems" },
                    { 16, true, "Cloud Native Infrastructure is a book that describes patterns for building infrastructure that is designed to run in the cloud. It covers topics such as containerization, service discovery, load balancing, and auto-scaling, and provides guidance on how to build infrastructure that is scalable, reliable, and easy to operate.", "978-1492041502", null, 49.99f, new DateTime(2019, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "O'Reilly Media", "Cloud Native Infrastructure: Patterns for Scalable, Reliable Services" },
                    { 17, true, "Artificial Intelligence with Python is a book that provides an introduction to the field of artificial intelligence, and its use in Python. It covers the basics of AI, including supervised and unsupervised learning, and also covers advanced topics such as deep learning and natural language processing.", "978-1119550822", null, 39.99f, new DateTime(2018, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wiley", "Artificial Intelligence with Python" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "John", "Smith" },
                    { 2, "Jane", "Doe" },
                    { 3, "Bob", "Johnson" },
                    { 4, "Sally", " Smith" },
                    { 5, "Samuel", " Jackson" },
                    { 6, "Emily", " Williams" },
                    { 7, "David", " Anderson" },
                    { 8, "Rachel", "Davis" },
                    { 9, "Mark", "Thompson" },
                    { 10, "Adam", "Walker" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "TagId", "TagName" },
                values: new object[,]
                {
                    { 1, "Agile" },
                    { 2, "Algorithms" },
                    { 3, "Best Practices" },
                    { 4, "Career Advancement" },
                    { 5, "Clean Code" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "TagId", "TagName" },
                values: new object[,]
                {
                    { 6, "Computer Programming" },
                    { 7, "Computer Science" },
                    { 8, "Compiler Design" },
                    { 9, "C Programming" },
                    { 10, "Data Structures" },
                    { 11, "Design Patterns" },
                    { 12, "Java" },
                    { 13, "JavaScript" },
                    { 14, "Job Preparation" },
                    { 15, "Object-Oriented Design" },
                    { 16, "Programming Language" },
                    { 17, "Programming Languages" },
                    { 18, "Project Management" },
                    { 19, "Software Construction" },
                    { 20, "Software Design" },
                    { 21, "Software Development" },
                    { 22, "Software Development Process" },
                    { 23, "Software Engineering" },
                    { 24, "Technical Interviews" },
                    { 25, "Web Development" }
                });

            migrationBuilder.InsertData(
                table: "BookAuthor",
                columns: new[] { "AuthorId", "BookId", "Order" },
                values: new object[,]
                {
                    { 1, 1, (byte)0 },
                    { 2, 2, (byte)0 },
                    { 3, 3, (byte)0 },
                    { 4, 3, (byte)0 },
                    { 4, 4, (byte)0 },
                    { 5, 5, (byte)0 },
                    { 6, 6, (byte)0 },
                    { 7, 7, (byte)0 },
                    { 8, 8, (byte)0 },
                    { 8, 9, (byte)0 },
                    { 9, 10, (byte)0 },
                    { 9, 11, (byte)0 },
                    { 7, 12, (byte)0 },
                    { 10, 12, (byte)0 },
                    { 7, 13, (byte)0 },
                    { 9, 14, (byte)0 },
                    { 10, 15, (byte)0 },
                    { 3, 16, (byte)0 },
                    { 2, 17, (byte)0 }
                });

            migrationBuilder.InsertData(
                table: "BookCustomer",
                columns: new[] { "BookId", "CustomerId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 },
                    { 10, 10 },
                    { 11, 10 },
                    { 12, 1 },
                    { 13, 2 },
                    { 14, 2 },
                    { 15, 4 },
                    { 16, 5 }
                });

            migrationBuilder.InsertData(
                table: "BookTag",
                columns: new[] { "BookId", "TagId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 3 },
                    { 2, 4 },
                    { 2, 5 },
                    { 3, 6 }
                });

            migrationBuilder.InsertData(
                table: "BookTag",
                columns: new[] { "BookId", "TagId" },
                values: new object[,]
                {
                    { 3, 7 },
                    { 3, 8 },
                    { 4, 2 },
                    { 4, 9 },
                    { 4, 10 },
                    { 5, 3 },
                    { 5, 5 },
                    { 5, 11 },
                    { 6, 3 },
                    { 6, 12 },
                    { 6, 13 },
                    { 7, 13 },
                    { 7, 14 },
                    { 7, 15 },
                    { 8, 1 },
                    { 8, 2 },
                    { 8, 10 },
                    { 9, 3 },
                    { 9, 5 },
                    { 9, 16 },
                    { 10, 3 },
                    { 10, 17 },
                    { 10, 18 },
                    { 11, 2 },
                    { 11, 9 },
                    { 11, 16 },
                    { 12, 6 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CustomerId", "OrderNo" },
                values: new object[,]
                {
                    { 1, 1, "9832a41b-b662-4361-b185-114f2797fbdc" },
                    { 2, 1, "4218cbb3-e59d-4809-ab31-e9f239f65de0" },
                    { 3, 2, "0ab8004e-4933-494f-a244-c3752388166f" },
                    { 4, 3, "98fe131f-9aaa-4fb5-8dcb-77b2cc252025" },
                    { 5, 4, "1e266153-e2cd-4dcc-bd5e-a3a3cd99fb4b" },
                    { 6, 5, "da517fcd-5d2f-4fd0-bb6d-03468b9d3e37" },
                    { 7, 6, "ba7ca152-d9c1-4593-8991-ec2edeaf2a15" },
                    { 8, 6, "b98b66c3-b4ec-406b-9f11-fa57d0194a7a" },
                    { 9, 8, "fd6facbf-8f0a-48a8-bbde-1d7a695c3908" },
                    { 10, 10, "bda5cb9a-ad62-4378-9162-67a380921e61" }
                });

            migrationBuilder.InsertData(
                table: "PriceOffers",
                columns: new[] { "PriceOfferId", "BookId", "NewPrice", "PromotionalText" },
                values: new object[,]
                {
                    { 1, 1, 36.891f, "Xmas Season Offer!" },
                    { 2, 2, 28.792002f, "Xmas Season Offer!" },
                    { 3, 3, 25.4925f, "Xmas Season Offer!" },
                    { 4, 4, 56.9925f, "Xmas Season Offer!" },
                    { 5, 5, 30.594002f, "Xmas Season Offer!" }
                });

            migrationBuilder.InsertData(
                table: "PriceOffers",
                columns: new[] { "PriceOfferId", "BookId", "NewPrice", "PromotionalText" },
                values: new object[,]
                {
                    { 6, 6, 26.9925f, "Xmas Season Offer!" },
                    { 7, 8, 30.495f, "Special Offer!" },
                    { 8, 9, 60.7425f, "Xmas Season Offer!" },
                    { 9, 10, 15.7425f, "Xmas Season Offer!" },
                    { 10, 11, 53.2425f, "Xmas Season Offer!" },
                    { 11, 12, 23.2425f, "Xmas Season Offer!" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "BookId", "Comment", "CustomerId", "NumStars" },
                values: new object[,]
                {
                    { 1, 1, "Great book, easy to understand.", 1, 5 },
                    { 2, 2, "Good information but could be more in-depth.", 2, 4 },
                    { 3, 3, "Informative but could be more engaging", 3, 3 },
                    { 4, 4, "Too basic for my needs", 4, 2 },
                    { 5, 5, "Excellent resource for data science", 5, 5 },
                    { 6, 6, "Poorly written, not useful", 6, 1 },
                    { 7, 17, "Good introduction to AI", 7, 4 },
                    { 8, 8, "Some good insights, but could be more comprehensive", 8, 3 },
                    { 9, 1, "I love this book!", 9, 5 },
                    { 10, 7, "Helpful guide for beginners", 1, 4 },
                    { 11, 15, "Disappointing, not what I was expecting", 2, 2 },
                    { 12, 17, "Great book, easy to understand", 4, 5 },
                    { 13, 8, "Good read, helpful examples", 5, 4 },
                    { 14, 10, "Informative but could be more engaging", 6, 3 },
                    { 15, 9, "Too basic for my needs", 7, 2 },
                    { 16, 10, "Poorly written, not useful", 8, 1 },
                    { 17, 16, "Good introduction to Cloud Native Infrastructure", 9, 4 },
                    { 18, 12, "Informative but could be more comprehensive", 1, 3 },
                    { 19, 13, "Disappointing, not what I was expecting", 2, 2 },
                    { 20, 14, "Excellent resource for data science", 3, 5 },
                    { 21, 6, "Good introduction to Cloud Native Infrastructure", 4, 4 },
                    { 22, 7, "Informative but could be more comprehensive", 5, 4 },
                    { 23, 8, "Disappointing, not what I was expecting", 6, 2 },
                    { 24, 5, "Excellent resource for data science", 7, 5 }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "BookId", "BookPrice", "NumBooks", "OrderId" },
                values: new object[,]
                {
                    { 1, 1, 36.890998840332031, (short)1, 1 },
                    { 2, 2, 28.792001724243164, (short)1, 1 },
                    { 3, 6, 26.992500305175781, (short)1, 3 },
                    { 4, 11, 53.242500305175781, (short)1, 4 },
                    { 5, 16, 49.990001678466797, (short)1, 5 },
                    { 6, 1, 36.890998840332031, (short)2, 5 },
                    { 7, 5, 30.594001770019531, (short)1, 6 },
                    { 8, 6, 26.992500305175781, (short)1, 6 },
                    { 9, 7, 25.989999771118164, (short)1, 6 },
                    { 10, 8, 30.495000839233398, (short)2, 7 },
                    { 11, 9, 60.742500305175781, (short)1, 7 },
                    { 12, 10, 15.742500305175781, (short)1, 7 },
                    { 13, 11, 53.242500305175781, (short)1, 8 },
                    { 14, 12, 23.242500305175781, (short)1, 9 },
                    { 15, 13, 24.989999771118164, (short)2, 10 },
                    { 16, 17, 39.990001678466797, (short)1, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthor_AuthorId",
                table: "BookAuthor",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BookCustomer_CustomerId",
                table: "BookCustomer",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_ISBN",
                table: "Books",
                column: "ISBN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookTag_TagId",
                table: "BookTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_BookId",
                table: "Items",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_OrderId",
                table: "Items",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderStatus_OrderId",
                table: "OrderStatus",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceOffers_BookId",
                table: "PriceOffers",
                column: "BookId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BookId",
                table: "Reviews",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_CustomerId",
                table: "Reviews",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthor");

            migrationBuilder.DropTable(
                name: "BookCustomer");

            migrationBuilder.DropTable(
                name: "BookTag");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "OrderStatus");

            migrationBuilder.DropTable(
                name: "PriceOffers");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
