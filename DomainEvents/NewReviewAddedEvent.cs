using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.DomainEvents
{
    public class NewReviewAddedEvent : IDomainEvent
    {
        public int BookId { get; }
        public string ReviewerName { get; }

        public NewReviewAddedEvent(int bookId, string reviewerName)
        {
            BookId = bookId;
            ReviewerName = reviewerName;
        }
    }

}
