namespace SuperPoc.BuildingBlocks.Domain.Events.Orders
{
    public record OrderShipped(Guid OrderId, string TrackingNumber) : DomainEvent;
}
