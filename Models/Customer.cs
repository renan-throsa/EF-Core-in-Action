using BookApp.Models.Configs;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookApp.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(101)]
        public string FullName { get; private set; }

        public ICollection<Review> Reviews { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<BookCustomer> WishList { get; set; }

    }
}
