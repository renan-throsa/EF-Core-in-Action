using MongoDB.Bson;

namespace BookApp.Domain.Models
{
    public class BookViewModel
    {
        public ObjectId Id { get; set; }
        public int BookId { get; set; }
        public string Title { get; set; }
        public string AuthorsName { get; set; }
        public DateTime PublishedOn { get; set; }
        public string Tags { get; set; }
        public double? AveStars { get; set; }
        public float Price { get; set; }  
        public float? PromotionNewPrice { get; set; }
        public string? PromotionPromotionalText { get; set; }
        
    }
}
