using SuperPoc.BuildingBlocks.Contracts.Enums;

namespace SuperPoc.BuildingBlocks.Contracts.DTOs
{
    public record ShipmentDto(Guid Id, Guid OrderId, ShipmentStatus Status, string TrackingCode, DateTime CreatedAtUtc);
}
