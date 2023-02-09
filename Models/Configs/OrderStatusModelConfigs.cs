using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;

namespace BookApp.Models.Configs
{
    internal class OrderStatusModelConfigs : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<OrderStatus> builder)
        {            
            var convertionV1 = new ValueConverter<OrderStatusEnum, string>(x => x.ToString(), x => (OrderStatusEnum)Enum.Parse(typeof(OrderStatusEnum), x));
            var convertionV2 = new EnumToStringConverter<OrderStatusEnum>();
            builder.Property(x => x.Status).HasConversion(convertionV1);

            var statuses = new List<OrderStatus>() {
                    new OrderStatus() { OrderStatusId=1,Status= OrderStatusEnum.ORDERED, StartDate = System.DateTime.Now, EndDate = System.DateTime.Now.AddDays(1)},
                    new OrderStatus() { OrderStatusId=1,Status= OrderStatusEnum.PAYED, StartDate = System.DateTime.Now.AddDays(1)},
                    new OrderStatus() { OrderStatusId=2,Status= OrderStatusEnum.ORDERED, StartDate = System.DateTime.Now, EndDate = System.DateTime.Now.AddDays(1) },
                    new OrderStatus() { OrderStatusId=2,Status= OrderStatusEnum.PAYED, StartDate = System.DateTime.Now.AddDays(1), EndDate = System.DateTime.Now.AddDays(2) } ,
                    new OrderStatus() { OrderStatusId=2,Status= OrderStatusEnum.SHIPING, StartDate = System.DateTime.Now.AddDays(2), },
                    new OrderStatus() { OrderStatusId=3,Status= OrderStatusEnum.ORDERED, StartDate = System.DateTime.Now, EndDate = System.DateTime.Now.AddDays(1) },
                    new OrderStatus() { OrderStatusId=3,Status= OrderStatusEnum.PAYED, StartDate = System.DateTime.Now.AddDays(1), EndDate = System.DateTime.Now.AddDays(2) } ,
                    new OrderStatus() { OrderStatusId=3,Status= OrderStatusEnum.SHIPING, StartDate = System.DateTime.Now.AddDays(2),EndDate = System.DateTime.Now.AddDays(3) },
                    new OrderStatus() { OrderStatusId=3,Status= OrderStatusEnum.SHIPED, StartDate = System.DateTime.Now.AddDays(10), },
                    new OrderStatus() { OrderStatusId=4,Status= OrderStatusEnum.ORDERED, StartDate = System.DateTime.Now, EndDate = System.DateTime.Now.AddDays(1) },
                    new OrderStatus() { OrderStatusId=4,Status= OrderStatusEnum.PAYED, StartDate = System.DateTime.Now.AddDays(1), EndDate = System.DateTime.Now.AddDays(2) } ,
                    new OrderStatus() { OrderStatusId=4,Status= OrderStatusEnum.SHIPING, StartDate = System.DateTime.Now.AddDays(2),EndDate = System.DateTime.Now.AddDays(10) },
                    new OrderStatus() { OrderStatusId=4,Status= OrderStatusEnum.SHIPED, StartDate = System.DateTime.Now.AddDays(10),EndDate = System.DateTime.Now.AddDays(15) },
                    new OrderStatus() { OrderStatusId=4,Status= OrderStatusEnum.RETURNED, StartDate = System.DateTime.Now.AddDays(15),EndDate = System.DateTime.Now.AddDays(20) },
                    new OrderStatus() { OrderStatusId=4,Status= OrderStatusEnum.RETURNED, StartDate = System.DateTime.Now.AddDays(21)},
                    new OrderStatus() { OrderStatusId = 1,Status= OrderStatusEnum.ORDERED, StartDate = System.DateTime.Now},
                    new OrderStatus() { OrderStatusId = 1,Status= OrderStatusEnum.ORDERED, StartDate = System.DateTime.Now}
            };

        }
    }
}
