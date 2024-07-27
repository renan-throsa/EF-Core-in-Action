namespace BookApp.Domain.Models
{
    public class ReviewViewModel
    {
        public int ReviewId { get; set; }
        public string VoterName { get; set; }
        public int NumStars { get; set; }
        public string Comment { get; set; }
        public int BookId { get; set; }
    }
}
