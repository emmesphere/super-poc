namespace SuperPoc.BuildingBlocks.Contracts.Events.Orders
{
    public record OrderPlaced(Guid OrderId, Guid CustomerId, decimal TotalAmount, DateTime CreatedAtUtc);
}
