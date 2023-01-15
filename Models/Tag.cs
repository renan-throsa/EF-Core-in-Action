using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookApp.Models
{
    public class Tag
    {
        [Key]
        public int TagId { get; set; }

        [Required]
        [MaxLength(40)]
        public string TagName { get; set; }

        public ICollection<BookTag> Books { get; set; }
    }
}
