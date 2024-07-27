namespace BookApp.Domain.Entities
{
    public enum OrderStatusEnum
    {
        ORDERED = 1,
        PROCESSING = 2,
        PAYED = 3,
        SHIPING = 4,
        SHIPED = 5,
        CANCELD = 6,
        RETURNED = 7,
        REFUNDED = 8
    }
}
