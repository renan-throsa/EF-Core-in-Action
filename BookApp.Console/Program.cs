using AutoMapper;
using BookApp.Data.Contexts;
using BookApp.Data.Utils;
using BookApp.Domain.Entities;
using BookApp.Domain.Models;
using Microsoft.EntityFrameworkCore;


//BookAverageVotesWithLinq();
//BookAverageVotesWithMethod();

//FromSqlRawQueries();
//bestWayToUpdate();

printBooksPromotionList(GetBooksList());


static void printBooksPromotionList(IEnumerable<BookViewModel> books)
{
    foreach (var b in books)
    {
        Console.WriteLine($"{b.BookId} - {b.Title}");
        Console.WriteLine($"by {b.AuthorsName}");
        Console.WriteLine($"Published on {b.PublishedOn}");
        Console.WriteLine($"Categories: {b.Tags}");
        Console.WriteLine($"Votes: {b.AveStars}");
        if (b.PromotionNewPrice > 0)
        {
            Console.WriteLine($"Price: {b.PromotionNewPrice} ! Saves $ {b.Price - b.PromotionNewPrice} ! {b.PromotionPromotionalText}");
        }
        else
        {
            Console.WriteLine($"price: {b.Price}");
        }
        Console.WriteLine();
    }
}

static IEnumerable<BookViewModel> GetBooksList()
{
    using var context = new NoSqlContext();

    if (!context.Books.Any()) {
        context.Books.AddRange(GetBooksPromotionList());
        context.SaveChanges();
    }
    return context.Books.ToList(); 
}

static IEnumerable<BookViewModel> GetBooksPromotionList()
{
    var configuration = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<Book, BookViewModel>()
        .ForMember(dest => dest.Id, opt => opt.Ignore())
        .ForMember(dest => dest.AuthorsName, opt => opt.MapFrom(src => string.Join(", ", src.Authors.Select(ba => ba.Author.Name))))
        .ForMember(dest => dest.AveStars, opt => opt.MapFrom(src => (double?)(src.Reviews.Any() ? src.Reviews.Average(y => y.NumStars) : null)))
        .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => string.Join(", ", src.Tags.Select(bt => bt.Tag.TagName))))
        .ForMember(dest => dest.PromotionNewPrice, opt => opt.MapFrom(src => (float?)(src.Promotion != null ? src.Promotion.NewPrice : null)))
        .ForMember(dest => dest.PromotionPromotionalText, opt => opt.MapFrom(src => (src.Promotion != null ? src.Promotion.PromotionalText : null)))
        .ReverseMap();
    });

    configuration.AssertConfigurationIsValid();

    var mapper = configuration.CreateMapper();

    using var context = new SqlContext();

    var query = context.Books.AsNoTracking();

    return mapper.ProjectTo<BookViewModel>(query).ToList();

}

static void BookAverageVotesWithMethod()
{
    using var context = new SqlContext();
    var bookAndVotes = context.Books.Select(x => new BookViewModel
    {
        BookId = x.BookId,
        Title = x.Title,
        AveStars = UdfMethods.AverageVotes(x.BookId)
    }).ToList();

    Console.WriteLine("");
    foreach (var item in bookAndVotes)
    {
        Console.WriteLine($"{item.Title} : {item.AveStars}");
    }
}

static void BookAverageVotesWithLinq()
{
    using var context = new SqlContext();
    var books = context.Books.Select(x => new { x.Title, Evaluation = (double?)x.Reviews.Average(y => y.NumStars) });
    Console.WriteLine("");
    foreach (var item in books)
    {
        Console.WriteLine($"{item.Title} - {item.Evaluation}");

    }
}

static void ToQueryString()
{
    using var context = new SqlContext();
    var query = context.Books.Select(x => new { Title = x.Title, Evaluation = (double?)x.Reviews.Average(y => y.NumStars) });
    var sql = query.ToQueryString();
    Console.WriteLine(sql);
}


static void FilteredQueries()
{
    using var context = new SqlContext();
    var b = context.Books.SingleOrDefault(x => x.ISBN.Equals("078-0201616224"));
    var query = context.Authors.Include(x => x.Books.Where(x => x.Book.Title.StartsWith("T"))).ToQueryString();
    Console.WriteLine(b);
    Console.WriteLine(query);
}

static void FromSqlRawQueries()
{
    using var context = new SqlContext();
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
    using var context = new SqlContext();
    var b = context.Books.First();
    b.ISBN = "978-0134685992";

    context.SaveChanges();
}