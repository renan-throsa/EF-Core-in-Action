using System.ComponentModel.DataAnnotations;

namespace BookApp.Models
{
    public class Item
    {
        public int ItemId { get; set; }

        [Range(1, 5, ErrorMessage = "This order is over the limit of 5 books.")]
        public short NumBooks { get; set; }

        public double BookPrice { get; set; }


        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}