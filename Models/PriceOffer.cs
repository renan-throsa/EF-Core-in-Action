using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Models
{
    public class PriceOffer
    {
        public int PriceOfferId { get; set; }
        public float NewPrice { get; set; }
        public string PromotionalText { get; set; }        

        public int BookId { get; set; } 
        public Book Book {get; set;}
    }
}
