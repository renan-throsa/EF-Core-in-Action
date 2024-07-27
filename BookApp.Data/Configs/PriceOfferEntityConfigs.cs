using BookApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookApp.Data.Configs
{
    internal class PriceOfferEntityConfigs : IEntityTypeConfiguration<PriceOffer>
    {
        public void Configure(EntityTypeBuilder<PriceOffer> builder)
        {
            builder.Property(x => x.PromotionalText).IsRequired().HasMaxLength(128);
            builder.HasOne(x => x.Book).WithOne(y => y.Promotion).HasForeignKey<PriceOffer>();

            var offers = new List<PriceOffer>() {
                new PriceOffer() { PriceOfferId = 1, NewPrice = 40.99f * 0.9f, PromotionalText = "Xmas Season Offer!", BookId = 1 },
                new PriceOffer() { PriceOfferId = 2, NewPrice = 35.99f * 0.8f, PromotionalText="Xmas Season Offer!",BookId = 2},
                new PriceOffer() { PriceOfferId = 3, NewPrice = 33.99f * 0.75f, PromotionalText="Xmas Season Offer!",BookId = 3},
                new PriceOffer() { PriceOfferId = 4, NewPrice = 75.99f * 0.75f, PromotionalText="Xmas Season Offer!",BookId = 4},
                new PriceOffer() { PriceOfferId = 5, NewPrice = 50.99f * 0.60f, PromotionalText="Xmas Season Offer!",BookId=5},
                new PriceOffer() { PriceOfferId = 6, NewPrice = 35.99f * 0.75f, PromotionalText="Xmas Season Offer!",BookId=6},
                new PriceOffer() { PriceOfferId = 7, NewPrice = 60.99f * 0.50f, PromotionalText="Special Offer!",BookId=8 },
                new PriceOffer() { PriceOfferId = 8, NewPrice = 80.99f * 0.75f, PromotionalText = "Xmas Season Offer!",BookId=9 },
                new PriceOffer() { PriceOfferId = 9, NewPrice = 20.99f * 0.75f, PromotionalText = "Xmas Season Offer!",BookId=10 },
                new PriceOffer() { PriceOfferId = 10, NewPrice = 70.99f * 0.75f, PromotionalText = "Xmas Season Offer!",BookId=11 },
                new PriceOffer() { PriceOfferId = 11, NewPrice = 30.99f * 0.75f, PromotionalText = "Xmas Season Offer!" ,BookId=12}
            };

            builder.HasData(offers);
        }
    }
}
