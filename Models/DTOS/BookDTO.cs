
using System;
using System.Collections.Generic;


namespace BookApp.Models.DTOS
{
    public class BookDTO
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string AuthorsName { get; set; }
        public DateTime PublishedOn { get; set; }
        public string Tags { get; set; }
        public double? AveStars { get; set; }
        public float Price { get; set; }  
        public float PromotionNewPrice { get; set; }
        public string PromotionPromotionalText { get; set; }
        
    }
}
