using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace BookApp.Models.Configs
{
    internal class ItemModelConfigs : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasOne(x => x.Order).WithMany(y => y.Items);

            var items = new List<Item>() {
                new Item() { ItemId = 1, OrderId = 1, NumBooks = 1, BookId = 1 ,BookPrice=30.99},
                new Item() { ItemId = 2, OrderId = 2, NumBooks = 1, BookId = 2 ,BookPrice=35.99},
                new Item() { ItemId = 3, OrderId = 3, NumBooks = 1, BookId = 6 ,BookPrice=35.99},
                new Item() { ItemId = 4, OrderId = 4, NumBooks = 1, BookId = 11 , BookPrice = 50.99},
                new Item() { ItemId = 5, OrderId = 5, NumBooks = 1, BookId = 16 , BookPrice = 35.99},
                new Item() { ItemId = 6, OrderId = 6, NumBooks = 2, BookId = 1 ,BookPrice=30.99},
                new Item() { ItemId = 7, OrderId = 6, NumBooks = 1, BookId = 4 , BookPrice = 40.99},
            };

            builder.HasData(items);
        }
    }
}
