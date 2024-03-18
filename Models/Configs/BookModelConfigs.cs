using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System;


namespace BookApp.Models.Configs
{
    public class BookModelConfigs : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(x => x.Title).IsRequired().HasMaxLength(128);
            builder.Property(x => x.Publisher).IsRequired().HasMaxLength(64);
            builder.Property(x => x.PublishedOn).HasColumnType("datetime");
            builder.Property(x => x.ISBN).IsRequired().HasMaxLength(14);
            builder.HasIndex(x => x.ISBN).IsUnique();
            builder.Property(x => x.ImageUrl).IsRequired(false);

            builder.HasOne(x => x.Promotion).WithOne(y => y.Book);
            builder.HasMany(x => x.Reviews).WithOne(y => y.Book);            

            List<Book> books = new List<Book>()
{
    new Book() {
        BookId = 1,
        ISBN = "978-0134685991",
        Title = "Clean Code: A Handbook of Agile Software Craftsmanship",
        Description = "A guide to writing clean and maintainable code",
        PublishedOn = new DateTime(2008, 8, 1),
        Publisher = "Prentice Hall",
        Price = 40.99f, ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/41v0QiEwZ7L._SX397_BO1,204,203,200_.jpg",        
        Available = true },
    new Book() {
        BookId = 2,
        ISBN = "978-0201616224",
        Title = "The Pragmatic Programmer: From Journeyman to Master",
        Description = "A guide to becoming a better programmer",
        PublishedOn = new DateTime(1999, 10, 20),
        Publisher = "Addison-Wesley Professional",
        Price = 35.99f,      
        ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/41yczzw6U0L._SX331_BO1,204,203,200_.jpg",
        Available = true },
    new Book() {
        BookId = 3,
        ISBN = "978-0984782857",
        Title = "Cracking the Coding Interview: 189 Programming Questions and Solutions",
        Description = "A guide to preparing for technical interviews",
        PublishedOn = new DateTime(2015, 7, 1),
        Publisher = "CareerCup",
        Price = 33.99f,
        ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/41rNjZBm3sL._SX331_BO1,204,203,200_.jpg",
        Available = true },
    new Book() {
        BookId = 4,
        ISBN = "978-0201633610",
        Title = "Design Patterns: Elements of Reusable Object-Oriented Software",
        Description = "Design Patterns is a modern classic in the literature of object-oriented development, offering timeless and elegant solutions to common problems in software design. It describes patterns for managing object creation, composing objects into larger structures, and coordinating control flow between objects.",
        PublishedOn = new DateTime(1995, 10, 1),
        Publisher = "Addison-Wesley Professional",
        Price = 45.99f,
        ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/4124eHhdGDL._SX396_BO1,204,203,200_.jpg",
        Available = true },
    new Book() {
        BookId = 5,
        ISBN = "978-0735619670",
        Title = "Code Complete: A Practical Handbook of Software Construction",
        Description = "A guide to software construction principles and practices",
        PublishedOn = new DateTime(2004, 6, 9),
        Publisher = "Microsoft Press",
        Price = 50.99f,
        ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/41yI1Gzv1aL._SX400_BO1,204,203,200_.jpg",
        Available = true },
    new Book() {
        BookId = 6,
        ISBN = "978-0321356680",
        Title = "Effective Java",
        Description = "A guide to best practices for the Java programming language",
        PublishedOn = new DateTime(2008, 5, 8),
        Publisher = "Addison-Wesley Professional",
        Price = 35.99f,
        ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/" },
    new Book() {
        BookId = 7,
        ISBN = "978-0596517748",
        Title = "JavaScript: The Good Parts",
        Description = "This book provides a developer-level introduction along with more advanced and useful features of JavaScript. It covers concepts such as objects, functions, and arrays, and it examines features such as closures, inheritance, and automatic semicolon insertion.",
        PublishedOn = new DateTime(2008, 5, 1),
        Publisher = "O'Reilly Media",
        Price = 25.99f,
        ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/51e6YZU6bxL._SX379_BO1,204,203,200_.jpg",
        Available = true },
    new Book() {
        BookId = 8,
        ISBN = "978-0262033848",
        Title = "Introduction to Algorithms",
        Description = "A comprehensive introduction to algorithms and data structures",
        PublishedOn = new DateTime(2009, 7, 31),
        Publisher = "MIT Press",
        Price = 60.99f,
        ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/51jJOuP--mL._SX398_BO1,204,203,200_.jpg",
        Available = true },
    new Book() {
        BookId = 9,
        ISBN = "978-0134685992",
        Title = "The Art of Computer Programming",
        Description = "A comprehensive guide to computer programming",
        PublishedOn = new DateTime(1968, 1, 1), Publisher = "Addison-Wesley Professional",
        Price = 80.99f,
        ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/51X5rQQ8-3L._SX405_BO1,204,203,200_.jpg",
        Available = true },
    new Book() {
        BookId = 10,
        ISBN = "978-0201835953",
        Title = "The Mythical Man-Month: Essays on Software Engineering",
        Description = "Essays on software engineering and project management",
        PublishedOn = new DateTime(1995, 8, 1), Publisher = "Addison-Wesley Professional",
        Price = 20.99f,
        ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/51OX1rsYvAL._SX331_BO1,204,203,200_.jpg",
        Available = true },
    new Book() {
        BookId = 11,
        ISBN = "978-0321486813",
        Title = "Compilers: Principles, Techniques, and Tools",
        Description = "A guide to compiler design principles and techniques",
        PublishedOn = new DateTime(2006, 7, 15), Publisher = "Addison-Wesley Professional",
        Price = 70.99f,
        ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/51KQc%2B9yJHL._SX379_BO1,204,203,200_.jpg",
        Available = true },
    new Book() {
        BookId = 12,
        ISBN = "978-0131103627",
        Title = "The C Programming Language",
        Description = "A classic introduction to the C programming language",
        PublishedOn = new DateTime(1988, 2, 22),
        Publisher = "Prentice Hall", Price = 30.99f,
        ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/51IS6N8BHPL._SX379_BO1,204,203,200_.jpg",
        Available = true },
    new Book {
        BookId = 13,
        ISBN = "978-1491903996",
        Title = "Big Data: A Revolution That Will Transform How We Live, Work, and Think",
        Description = "Big Data is a book that examines how data-driven technologies are transforming the way we live and work, and how they are creating new opportunities for individuals and organizations to generate value. It also looks at the risks and challenges of data-driven technologies, and how they can be managed.",
        PublishedOn = new DateTime(2013, 03, 14),
        Publisher = "O'Reilly Media",
        Price = 24.99f,
        Available = true
    },
    new Book {
        BookId = 14,
        ISBN = "978-1119293347",
        Title = "Python for Data Science Handbook",
        Description = "Python for Data Science Handbook is a comprehensive introduction to the Python programming language, and its use in data science. It covers the essential tools for data science, including NumPy, Pandas, Matplotlib, and Scikit-learn, and also covers advanced topics such as machine learning and natural language processing.",
        PublishedOn = new DateTime(2015, 11, 09),
        Publisher = "Wiley",
        Price = 39.99f,
        Available = true
    },
    new Book {
        BookId = 15,
        ISBN = "978-1449373320",
        Title = "Designing Data-Intensive Applications: The Big Ideas Behind Reliable, Scalable, and Maintainable Systems",
        Description = "Designing Data-Intensive Applications is a book that examines the principles and practices behind data-intensive systems. It covers topics such as data modeling, data storage, data processing, and data flow, and provides guidance on how to design and implement data-intensive systems that are reliable, scalable, and maintainable.",
        PublishedOn = new DateTime(2017, 03, 16),
        Publisher = "O'Reilly Media",
        Price = 49.99f,
        Available =true },
    new Book {
        BookId = 16,
        ISBN = "978-1492041502",
        Title = "Cloud Native Infrastructure: Patterns for Scalable, Reliable Services",
        Description = "Cloud Native Infrastructure is a book that describes patterns for building infrastructure that is designed to run in the cloud. It covers topics such as containerization, service discovery, load balancing, and auto-scaling, and provides guidance on how to build infrastructure that is scalable, reliable, and easy to operate.",
        PublishedOn = new DateTime(2019, 06, 14),
        Publisher = "O'Reilly Media",
        Price = 49.99f,
        Available = true
    },
    new Book  {
        BookId = 17,
        ISBN = "978-1119550822",
        Title = "Artificial Intelligence with Python",
        Description = "Artificial Intelligence with Python is a book that provides an introduction to the field of artificial intelligence, and its use in Python. It covers the basics of AI, including supervised and unsupervised learning, and also covers advanced topics such as deep learning and natural language processing.",
        PublishedOn = new DateTime(2018, 12, 15),
        Publisher = "Wiley",
        Price = 39.99f,
        Available = true
    },

    };

            builder.HasData(books);
        }
    }
}
