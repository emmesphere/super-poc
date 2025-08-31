namespace SuperPoc.BuildingBlocks.Domain.Events.Orders
{
    public record OrderCreated(Guid OrderId, Guid CustomerId, decimal TotalAmount) : DomainEvent;
}
