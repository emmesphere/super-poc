namespace SuperPoc.BuildingBlocks.Domain.Enums
{
    public enum OrderStatus
    {
        Pending = 0,
        Confirmed = 1,
        Shipped = 2,
        Delivered = 3,
        Canceled = 4
    }
    public enum PaymentMethod
    {
        CreditCard = 0,
        DebitCard = 1,
        Pix = 2,
        Boleto = 3
    }
    public enum PaymentStatus
    {
        Pending = 0,
        Completed = 1,
        Failed = 2
    }

    public enum ShipmentStatus
    {
        Pending = 0,
        InTransit = 1,
        Delivered = 2,
        Failed = 3
    }
}
