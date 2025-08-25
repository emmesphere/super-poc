namespace SuperPoc.BuildingBlocks.Contracts.Events.Orders
{
    public record OrderShipped(Guid OrderId, Guid ShipmentId, string TrackingCode, DateTime ShippedAtUtc);
}
