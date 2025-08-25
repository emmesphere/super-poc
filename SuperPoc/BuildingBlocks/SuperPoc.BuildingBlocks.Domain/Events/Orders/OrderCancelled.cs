namespace SuperPoc.BuildingBlocks.Domain.Events.Orders
{
    public record OrderCancelled(Guid OrderId, Guid CustomerId, string Reason) : DomainEvent;
}
