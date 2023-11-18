using System;
using System.Collections.Generic;

namespace BookApp.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public double TotalPrice { get; }
        public DateTime OrderedOn { get; }
        public string OrderNo { get; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public ICollection<Item> Items { get; set; }

        public ICollection<OrderStatus> Statuses { get; set; }

        public string OrderNumber => $"SO{OrderId:D6}";



    }
}