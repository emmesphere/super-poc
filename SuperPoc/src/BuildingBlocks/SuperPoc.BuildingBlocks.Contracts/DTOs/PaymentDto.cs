using SuperPoc.BuildingBlocks.Contracts.Enums;

namespace SuperPoc.BuildingBlocks.Contracts.DTOs
{
    public record PaymentDto(Guid Id, Guid OrderId, decimal Amout, PaymentMethod PaymentMethod, PaymentStatus PaymentStatus, DateTime ProcessedAt);
}
