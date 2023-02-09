using System;

namespace BookApp.Models
{
    public class OrderStatus
    {
        public int OrderStatusId { get; set; }
        public OrderStatusEnum Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Order Order { get; set; }
    }
}
