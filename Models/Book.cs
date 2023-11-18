using BookApp.DomainEvents;
using BookApp.Models.Configs;
using System;
using System.Collections.Generic;


namespace BookApp.Models
{
    public class Book : AddEventsToEntity
    {
        public int BookId { get; set; }
        public string ISBN { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishedOn { get; set; }
        public string Publisher { get; set; }
        public float Price { get; set; }
        public string ImageUrl { get; set; }
        public bool Available { get; set; }

        public PriceOffer? Promotion { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<BookTag> Tags { get; set; }
        public ICollection<BookAuthor> Authors { get; set; }

        public ICollection<BookCustomer> WishList { get; set; }


    }
}
