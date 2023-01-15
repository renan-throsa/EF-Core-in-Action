
using System.Collections.Generic;


namespace BookApp.Models.DTOS
{
    public class BookDTO
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public float Price { get; set; }
        public double? AveVotes { get; set; }

        public float PromotionNewPrice { get; set; }
        public string PromotionPromotionalText { get; set; }

        public ICollection<ReviewDTO> Reviews { get; set; }
    }
}
