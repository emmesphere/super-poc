namespace SuperPoc.BuildingBlocks.Domain.Events.Orders
{
    public record OrderConfirmed(Guid OrderId, Guid CustomerId, decimal TotalAmount) : DomainEvent;
}
