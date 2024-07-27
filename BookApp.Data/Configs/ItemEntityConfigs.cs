using BookApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookApp.Data.Configs
{
    internal class ItemEntityConfigs : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasOne(x => x.Order).WithMany(y => y.Items);
            builder.HasOne(x => x.Book);

            var items = new List<Item>() {
                new Item() { ItemId = 1, OrderId = 1, NumBooks = 1, BookId = 1 ,BookPrice=40.99f*0.9f},
                new Item() { ItemId = 2, OrderId = 1, NumBooks = 1, BookId = 2 ,BookPrice=35.99f*0.8f},

                new Item() { ItemId = 3, OrderId = 3, NumBooks = 1, BookId = 6 ,BookPrice=35.99f*0.75f},
                new Item() { ItemId = 4, OrderId = 4, NumBooks = 1, BookId = 11 , BookPrice = 70.99f * 0.75f},
                new Item() { ItemId = 5, OrderId = 5, NumBooks = 1, BookId = 16 , BookPrice = 49.99f},
                new Item() { ItemId = 6, OrderId = 5, NumBooks = 2, BookId = 1 ,BookPrice=40.99f*0.9f},

                new Item() { ItemId = 7, OrderId = 6, NumBooks = 1, BookId = 5 , BookPrice = 50.99f*0.60f},
                new Item() { ItemId = 8, OrderId = 6, NumBooks = 1, BookId = 6 , BookPrice = 35.99f*0.75f},
                new Item() { ItemId = 9, OrderId = 6, NumBooks = 1, BookId = 7 , BookPrice = 25.99f},

                new Item() { ItemId = 10, OrderId = 7, NumBooks = 2, BookId = 8 , BookPrice = 60.99f*0.5f},
                new Item() { ItemId = 11, OrderId = 7, NumBooks = 1, BookId = 9 , BookPrice = 80.99f * 0.75f},
                new Item() { ItemId = 12, OrderId = 7, NumBooks = 1, BookId = 10 , BookPrice = 20.99f * 0.75f},

                new Item() { ItemId = 13, OrderId = 8, NumBooks = 1, BookId = 11 , BookPrice = 70.99f * 0.75f},
                new Item() { ItemId = 14, OrderId = 9, NumBooks = 1, BookId = 12 , BookPrice = 30.99f * 0.75f},
                new Item() { ItemId = 15, OrderId = 10, NumBooks = 2, BookId = 13 , BookPrice = 24.99f},

                new Item() { ItemId = 16, OrderId = 2, NumBooks = 1, BookId = 17 , BookPrice = 39.99f},
            };

            builder.HasData(items);
        }
    }
}
