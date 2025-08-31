namespace SuperPoc.BuildingBlocks.Contracts.Events.Shipments
{
    public record ShipmentDelivered(Guid ShipmentId, Guid OrderId, DateTime DeliveredAtUtc);
}
