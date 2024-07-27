namespace BookApp.Domain.Entities
{
    public class BookCustomer
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
