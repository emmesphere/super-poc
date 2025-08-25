namespace SuperPoc.BuildingBlocks.Contracts.Events.Shipments
{
    public record ShipmentStarted(Guid ShipmentId, Guid OrderId, string TrackingCode, DateTime StartedAtUtc);
}
