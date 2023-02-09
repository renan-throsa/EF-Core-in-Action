using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Models
{
    public class StatusType
    {
        public OrderStatusEnum StatusTypeId { get; set; }
        public string StatusName { get; set; }
    }
}
